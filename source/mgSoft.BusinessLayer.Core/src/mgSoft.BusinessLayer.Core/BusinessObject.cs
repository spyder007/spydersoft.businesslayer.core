using mgSoft.BusinessLayer.Core.Events;
using mgSoft.BusinessLayer.Core.Results;
using mgSoft.DataLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mgSoft.BusinessLayer.Core
{
    /// <summary>
    /// Class BusinessObject.
    /// </summary>
    /// <typeparam name="TDataContract">The type of the t data contract.</typeparam>
    /// TODO Edit XML Comment Template for BusinessObject`1
    public abstract class BusinessObject<TDataContract> : Interfaces.IDataStoreConsumer, Interfaces.IBusinessObject
        where TDataContract : DataItem, new()
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessObject{TDataContract}"/> class.
        /// </summary>
        /// TODO Edit XML Comment Template for #ctor
        public BusinessObject()
        {
            DataItem = new TDataContract();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessObject{TDataContract}"/> class.
        /// </summary>
        /// <param name="dataContract">The data contract.</param>
        /// TODO Edit XML Comment Template for #ctor
        public BusinessObject(TDataContract dataContract)
        {
            DataItem = dataContract;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the data item.
        /// </summary>
        /// <value>The data item.</value>
        /// TODO Edit XML Comment Template for DataItem
        public TDataContract DataItem
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the data store.
        /// </summary>
        /// <value>The data store.</value>
        /// TODO Edit XML Comment Template for DataStore
        protected IDataStore DataStore
        {
            get;
            private set;
        }

        #endregion Properties

        #region Events

        public delegate void BusinessObjectSavingEventHandler(object sender, BusinessObjectSavingEventArgs args);

        public event BusinessObjectSavingEventHandler BusinessObjectSaving;

        public delegate void BusinesObjectSavedEventHandler(object sender, BusinessObjectSavedEventArgs args);

        public event BusinesObjectSavedEventHandler BusinessObjectSaved;

        #endregion Events

        #region IBusinessObject Implementation

        /// <summary>
        /// Load the business object base on the given primary key
        /// </summary>
        /// <param name="primaryKey">primary key</param>
        /// <returns>true if object loaded, false otherwise</returns>
        public bool LoadByPrimaryKey(long primaryKey)
        {
            var dc = DataStore.GetItem<TDataContract>(primaryKey);
            DataItem = dc ?? new TDataContract();
            return (dc != null);
        }

        /// <summary>
        /// Loads the business object based on the given external key.
        /// </summary>
        /// <param name="externalKey">The external key.  In most cases, this will be <i>Segment Name</i>-<i>ExternalId</i></param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool LoadByExternalKey(string externalKey)
        {
            var dc = GetDataItem(externalKey);
            DataItem = dc ?? new TDataContract();
            return (dc != null);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// TODO Edit XML Comment Template for Save
        public IEnumerable<ActionResult> Save()
        {
            var businessObjectSavingEventArgs = new BusinessObjectSavingEventArgs(this);
            OnBusinessObjectSaving(businessObjectSavingEventArgs);

            if (businessObjectSavingEventArgs.Cancel)
            {
                return new List<ActionResult>() {
                    new ActionResult {
                                        ResultType = ActionResultType.CANCEL,
                                        Message = "Save cancelled by BusinessObjectSaving event"
                                     }
                        };
            }

            var beforeSaveResults = BeforeSave();
            if (beforeSaveResults != null && beforeSaveResults.HasHaltingMessages())
            {
                return beforeSaveResults;
            }


            var validateResults = Validate().ToList();
            if (validateResults != null && validateResults.HasHaltingMessages())
            {
                return validateResults;
            }

            var results = beforeSaveResults.ToList();
            results.AddRange(validateResults);

            if (DataStore != null)
            {
                try
                {
                    DataItem = DataStore.SaveItem(DataItem);
                    results.Add(new ActionResult
                    {
                        ResultType = ActionResultType.SUCCESS
                    });
                    OnBusinessObjectSaved(new BusinessObjectSavedEventArgs(this));
                    var afterSaveResults = AfterSave();
                    if (afterSaveResults != null)
                    {
                        results.AddRange(afterSaveResults);
                    }
                }
                catch (Exception ex)
                {
                    results.Add(new ActionResult
                    {
                        ResultType = ActionResultType.ERROR,
                        Message = $"An error occurred on save for ${GetType()}",
                        Exception = ex
                    });
                }
            }

            return results;
        }

        #endregion IBusinessObject Implementation

        #region BusinessObject Interface

        public virtual IEnumerable<ActionResult> BeforeSave()
        {
            return new List<ActionResult>();
        }

        public virtual IEnumerable<ActionResult> AfterSave()
        {
            return new List<ActionResult>();
        }

        public abstract IEnumerable<ActionResult> Validate();

        public abstract TDataContract GetDataItem(string externalKey);

        #endregion BusinessObject Interface

        #region IDataStoreConsumer Implementation

        /// <summary>
        /// Sets the data store.
        /// </summary>
        /// <param name="dataStore">The data store.</param>
        /// TODO Edit XML Comment Template for SetDataStore
        public void SetDataStore(IDataStore dataStore)
        {
            DataStore = dataStore;
        }

        #endregion IDataStoreConsumer Implementation

        #region Private Methods

        private void OnBusinessObjectSaving(BusinessObjectSavingEventArgs args)
        {
            if (BusinessObjectSaving != null)
            {
                BusinessObjectSaving(this, args);
            }
        }

        private void OnBusinessObjectSaved(BusinessObjectSavedEventArgs args)
        {
            if (BusinessObjectSaved != null)
            {
                BusinessObjectSaved(this, args);
            }
        }

        #endregion Private Methods
    }
}