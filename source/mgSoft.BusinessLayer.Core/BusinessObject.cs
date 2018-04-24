using mgSoft.BusinessLayer.Core.Attributes;
using mgSoft.BusinessLayer.Core.Interfaces;
using mgSoft.BusinessLayer.Core.Results;
using mgSoft.DataLayer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;

namespace mgSoft.BusinessLayer.Core
{
    [DataContract]
    public abstract class BusinessObject<TDataContract>
            : IDisposable, IDataStoreConsumer, IBusinessObject<TDataContract> where TDataContract : class, IDataItem, new()
    {
        private TDataContract _dataContract;
        private BusinessObjectFactory _factory;

        #region Constants

        /// <summary>
        /// The Constant for a duplicate record error message.
        /// </summary>
        public const string DuplicateRecordMessage = "Duplicate Record";

        #endregion Constants

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessObject{TDataContract}"/> class.
        /// </summary>
        /// <remarks>This constructor is required for LINQ queries.</remarks>
        protected BusinessObject()
        {
            DataContract = new TDataContract();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessObject{TDataContract}"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is required to support the User object constructor with the same signature.
        /// </remarks>
        /// <param name="store">The store.</param>
        /// <param name="dataContract">The data contract.</param>
        protected BusinessObject(TDataContract dataContract)
        {
            DataContract = dataContract;
        }

        #endregion Constructors

        #region IBusinessObject Implementation

        public virtual string DisplayName => GetType().ToString();

        /// <summary>
        /// Gets the data contract identifier.
        /// </summary>
        /// <value>
        /// The data contract identifier.
        /// </value>
        public long DataContractId => DataContract?.Id ?? 0;

        /// <summary>
        /// Gets the business object data.
        /// </summary>
        /// <value>
        /// The business object data.
        /// </value>
        internal TDataContract BusinessObjectData => DataContract;

        /// <summary>
        /// Gets or sets the data contract.
        /// </summary>
        /// <value>
        /// The data contract.
        /// </value>
        [SkipCopy]
        protected TDataContract DataContract
        {
            get => _dataContract;
            set
            {
                UnsubscribeDataContractEvents();
                _dataContract = null;

                _dataContract = value;
                SubscribeToDataContractEvents();
            }
        }

        /// <summary>
        /// The data store to use with the business object
        /// </summary>
        [SkipCopy]
        public IDataStore Store { get; set; }

        /// <summary>
        /// Validates and saves the business object
        /// </summary>
        /// <returns>
        /// A <see cref="BusinessResult{IBusinessObject}"/> class indicating success or errors
        /// </returns>
        public BusinessResult<IBusinessObject> Save()
        {
            var businessResult = new BusinessResult<IBusinessObject>();
            businessResult.Messages.AddRange(ValidateForSave());

            if (businessResult.Messages.Count == 0)
            {
                BusinessResult<IBusinessObject> saveBusinessObjectResults = SaveBusinessObject();
                if (saveBusinessObjectResults.Messages.Count > 0)
                {
                    businessResult.Messages.AddRange(saveBusinessObjectResults.Messages);
                    businessResult.ResultType = saveBusinessObjectResults.ResultType;
                }
                businessResult.IsSuccessful = saveBusinessObjectResults.IsSuccessful &&
                                              saveBusinessObjectResults.ResultType == ResultType.Success;
                businessResult.Result = saveBusinessObjectResults.Result;
            }
            else
            {
                businessResult.ResultType = ResultType.ValidationFailure;
            }

            return businessResult;
        }

        public void Load(long primaryKey)
        {
            DataContract = Store.GetItem<TDataContract>(primaryKey);
            SetKeyFieldsFromId();
            OnLoaded();
        }

        public void LoadByKey(string key)
        {
            var contracts = Store.GetItems(KeySearchFunction(key));
            if (contracts != null && contracts.Any())
            {
                DataContract = contracts.FirstOrDefault();
                SetKeyFieldsFromId();
                OnLoaded();
            }
        }

        public virtual void GetIdValues()
        {
        }

        /// <summary>
        /// Validate the business object instance.
        /// This virtual base implementation performs required field validation.
        /// </summary>
        /// <returns>
        /// A <see cref="List{ResultMessage}"/> containing any validation errors.
        /// </returns>
        public List<ResultMessage> Validate()
        {
            List<ResultMessage> resultMessages = new List<ResultMessage>();

            List<ResultMessage> objectPropertyMessages = ValidateObjectProperties();
            if (objectPropertyMessages.Count > 0)
            {
                resultMessages.AddRange(objectPropertyMessages);
            }

            List<ResultMessage> customValidationMessages = ValidateObject();
            if (customValidationMessages.Count > 0)
            {
                resultMessages.AddRange(customValidationMessages);
            }

            return resultMessages;
        }

        /// <summary>
        /// Delete the business object from the data store
        /// </summary>
        /// <returns>
        /// Object indicating the results of the delete
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual DeleteResults Delete()
        {
            var deleteResults = new DeleteResults();
            try
            {
                if (DataContract.Id > 0)
                {
                    Store.DeleteItem(DataContract);
                }
            }
            catch (Exception ex)
            {
                deleteResults.AddMessage(ex.Message);
            }

            return deleteResults;
        }

        #endregion IBusinessObject Implementation

        #region IDisposable Implementation

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public
        void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnsubscribeDataContractEvents();
                _dataContract = null;
            }
        }

        #endregion IDisposable Implementation

        #region IDataStoreConsumer Implementation

        /// <summary>
        /// Sets the data store.
        /// </summary>
        /// <param name="store">The store.</param>
        public void SetDataStore(IDataStore store)
        {
            Store = store;
            _factory = new BusinessObjectFactory(Store);
            GetIdValues();
        }

        #endregion IDataStoreConsumer Implementation

        #region BusinessObject Interface

        public abstract string Key { get; }

        [SkipCopy]
        public abstract DateTimeOffset DateCreated { get; set; }

        [SkipCopy]
        public abstract DateTimeOffset DateUpdated { get; set; }

        public void SetIdFromKeyFields()
        {
            var lookupFields = GetType().GetTypeInfo().DeclaredProperties.Where(x => x.CanRead && x.GetCustomAttributes<LookupFieldAttribute>().Any()).ToList();
            foreach (PropertyInfo lookupFieldProperty in lookupFields)
            {
                if (lookupFieldProperty.GetMethod.ReturnType != typeof(string))
                {
                    System.Diagnostics.Debug.WriteLine("Non string lookup fields are not supported");
                    continue;
                }

                var lookupAttribute = lookupFieldProperty.GetCustomAttributes<LookupFieldAttribute>().FirstOrDefault();
                if (lookupAttribute == null)
                {
                    System.Diagnostics.Debug.WriteLine("Could not find LookupField attribute");
                    continue;
                }

                var propertyToSet =
                    GetType()
                        .GetTypeInfo()
                        .DeclaredProperties.FirstOrDefault(x => x.CanWrite && x.Name == lookupAttribute.PropertyName);
                if (propertyToSet == null)
                {
                    System.Diagnostics.Debug.WriteLine("Could not find Property to set");
                }
                string lookupFieldValue = lookupFieldProperty.GetMethod.Invoke(this, null) as string;
                long key = GetIdFromKey(lookupAttribute.LookupType, lookupFieldValue);
                propertyToSet.SetMethod.Invoke(this, new object[] { key });
            }
        }

        public void SetKeyFieldsFromId()
        {
            var lookupKeyFields = GetType().GetTypeInfo().DeclaredProperties.Where(x => x.CanWrite && x.GetCustomAttributes<LookupFieldAttribute>().Any()).ToList();
            foreach (PropertyInfo lookupKeyField in lookupKeyFields)
            {
                if (lookupKeyField.GetMethod.ReturnType != typeof(string))
                {
                    System.Diagnostics.Debug.WriteLine("Non string lookup fields are not supported");
                    continue;
                }

                var lookupAttribute = lookupKeyField.GetCustomAttributes<LookupFieldAttribute>().FirstOrDefault();
                if (lookupAttribute == null)
                {
                    System.Diagnostics.Debug.WriteLine("Could not find LookupField attribute");
                    continue;
                }

                var idField =
                    GetType()
                        .GetTypeInfo()
                        .DeclaredProperties.FirstOrDefault(x => x.CanRead && x.Name == lookupAttribute.PropertyName);
                if (idField == null)
                {
                    System.Diagnostics.Debug.WriteLine("Could not find ID Property");
                    continue;
                }

                long? idValue;
                if (idField.PropertyType == typeof(long))
                {
                    idValue = (long)idField.GetMethod.Invoke(this, null);
                }
                else if (idField.PropertyType == typeof(long?))
                {
                    idValue = (long?)idField.GetMethod.Invoke(this, null);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("ID Fields for LookupField must be long or Nullable<long> ");
                    continue;
                }

                if (!idValue.HasValue || idValue.Value <= 0)
                {
                    continue;
                }

                string key = GetKeyForId(lookupAttribute.LookupType, idValue.Value);
                lookupKeyField.SetMethod.Invoke(this, new object[] { key });
            }
        }

        /// <summary>
        /// Saves the business object.  This is overridable.
        /// </summary>
        /// <returns>
        /// A <see cref="BusinessResult{IBusinessObject}"/> indicating success or errors
        /// </returns>
        protected virtual BusinessResult<IBusinessObject> SaveBusinessObject()
        {
            var saveBusinessObjectResults = new BusinessResult<IBusinessObject>
            {
                IsSuccessful = true
            };

            try
            {
                GetIdValues();
                SetTimeStampFields(DataContractId == 0);
                OnSaving();
                DataContract = Store.SaveItem(DataContract);
                OnSaved();
                saveBusinessObjectResults.Result = this;
            }
            catch (Exception ex)
            {
                saveBusinessObjectResults.Messages.Add(new ResultMessage(ResultMessageType.Error, ex.Message, ex.Message));
                saveBusinessObjectResults.ResultType = ResultType.GeneralFailure;
                saveBusinessObjectResults.IsSuccessful = false;
            }

            return saveBusinessObjectResults;
        }

        /// <summary>
        /// Can be overridden in a sub class to execute code after a new item is successfully saved. Executes before AfterSave is called.
        /// </summary>
        protected virtual void AfterInsert()
        {
        }

        /// <summary>
        /// Can be overridden in a sub class to execute code after successful save and after AfterInsert is called
        /// </summary>
        protected virtual void AfterSave()
        {
        }

        /// <summary>
        /// Called when [saving].
        /// </summary>
        /// TODO Edit XML Comment Template for OnSaving
        protected virtual void OnSaving()
        {
        }

        /// <summary>
        /// Called when [saved].
        /// </summary>
        /// TODO Edit XML Comment Template for OnSaved
        protected virtual void OnSaved()
        {
        }

        /// <summary>
        /// Called when [loaded].
        /// </summary>
        /// TODO Edit XML Comment Template for OnLoaded
        protected virtual void OnLoaded()
        {
        }

        protected virtual List<ResultMessage> ValidateObject()
        {
            return new List<ResultMessage>();
        }

        protected abstract Expression<Func<TDataContract, bool>> KeySearchFunction(string searchString);

        /// <summary>
        /// Loads the defaults.
        /// </summary>
        protected abstract void LoadDefaults();

        /// <summary>
        /// Resets the data and lists.
        /// </summary>
        protected virtual void ResetDataAndLists()
        {
            LoadDefaults();
        }

        #endregion BusinessObject Interface

        #region Public Methods

        /// <summary>
        /// Validates for save.
        /// </summary>
        /// <returns>
        /// A <see cref="List{ResultMessage}"/> containing any validation errors.
        /// </returns>
        public List<IResultMessage> ValidateForSave()
        {
            var allMessages = new List<IResultMessage>();

            // We first check if the object is read only and prevent saving if it is.
            // We only execute the other validations when it is even possible for the object to be saved.
            allMessages.AddRange(Validate());

            return allMessages;
        }

        /// <summary>
        /// Validate that the required fields have values and that they are appropriate.
        /// The required fields are determined via virtual method GetRequiredFields and that should be overridden for each business object implementation.
        /// </summary>
        /// <returns>
        /// A <see cref="List{ResultMessage}"/> containing any validation errors.
        /// </returns>
        public List<ResultMessage> ValidateObjectProperties()
        {
            List<ValidationResult> results = new List<ValidationResult>();
            Validator.TryValidateObject(this, new ValidationContext(this), results);

            var resultList = new List<ResultMessage>();
            foreach (var result in results)
            {
                resultList.Add(new ResultMessage()
                {
                    MessageType = ResultMessageType.Error,
                    Message = result.ErrorMessage,
                    ShortMessage = result.ErrorMessage,
                    PropertyName = result.MemberNames.FirstOrDefault()
                });
            }

            TypeInfo myTypeInfo = GetType().GetTypeInfo();

            var keyProperties =
                myTypeInfo.DeclaredProperties.Where(prop => prop.GetCustomAttributes<PublicKeyAttribute>(true).FirstOrDefault() != null);

            if (!keyProperties.Any())
            {
                return resultList;
            }

            PropertyInfo keyProperty = keyProperties.First();

            var sameKeyItems = Store.GetItems(KeySearchFunction((string)keyProperty.GetValue(this)));
            if (sameKeyItems != null && sameKeyItems.Any())
            {
                if (sameKeyItems.First().Id != DataContractId)
                {
                    resultList.Add(new ResultMessage()
                    {
                        MessageType = ResultMessageType.Error,
                        Message = $"{keyProperty.Name} is already in use."
                    });
                }
            }

            return resultList;
            //var resultList = new List<ResultMessage>();

            //foreach (var property in requiredProperties)
            //{
            //    if (property.PropertyType == typeof(string))
            //    {
            //        if (string.IsNullOrWhiteSpace((string) property.GetValue(this)))
            //        {
            //            resultList.Add(new ResultMessage()
            //            {
            //                MessageType = RESULT_MESSAGE_TYPE.ERROR,
            //                PropertyName = property.Name,
            //                ShortMessage = $"{property.Name} is required."
            //            });
            //        }
            //    }

            //    if (property.PropertyType == typeof(DateTimeOffset))
            //    {
            //        var value = (DateTimeOffset) property.GetValue(this);
            //        if (value == DateTimeOffset.MinValue)
            //        {
            //            resultList.Add(new ResultMessage()
            //            {
            //                MessageType = RESULT_MESSAGE_TYPE.ERROR,
            //                PropertyName = property.Name,
            //                ShortMessage = $"{property.Name} is required."
            //            });
            //        }
            //    }

            //    if (property.PropertyType == typeof(DateTimeOffset?))
            //    {
            //        var value = property.GetValue(this) as DateTimeOffset?;
            //        if (value == null)
            //        {
            //            resultList.Add(new ResultMessage()
            //            {
            //                MessageType = RESULT_MESSAGE_TYPE.ERROR,
            //                PropertyName = property.Name,
            //                ShortMessage = $"{property.Name} is required."
            //            });
            //        }
            //    }

            //}

            //return resultList;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Subscribes to data contract events.
        /// </summary>
        protected void SubscribeToDataContractEvents()
        {
            if (DataContract != null)
            {
                DataContract.ValueChanged += DataContract_ValueChanged;
            }
        }

        /// <summary>
        /// Unsubscribes the data contract events.
        /// </summary>
        protected void UnsubscribeDataContractEvents()
        {
            if (DataContract != null)
            {
                DataContract.ValueChanged -= DataContract_ValueChanged;
            }
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Stamps the date fields.
        /// </summary>
        /// <param name="isCreate">if set to <c>true</c> [is create].</param>
        /// TODO Edit XML Comment Template for StampDateFields
        private void SetTimeStampFields(bool isCreate)
        {
            DateUpdated = DateTimeOffset.UtcNow;
            if (isCreate)
            {
                DateCreated = DateTimeOffset.UtcNow;
            }
        }

        private void DataContract_ValueChanged(object sender, DataItemEventArgs e)
        {
            OnBusinessPropertyChanged(e.PropertyName);
        }

        private bool LoadBusinessObject(int primaryKey)
        {
            var dc = Store.GetItem<TDataContract>(primaryKey);
            DataContract = dc ?? new TDataContract();
            return (dc != null);
        }

        protected string GetKeyForId<T>(long codeId) where T : IBusinessObject
        {
            T lookupObject = _factory.Load<T>(codeId);

            if (lookupObject != null && lookupObject.DataContractId > 0)
            {
                return lookupObject.Key;
            }

            return null;
        }

        protected string GetKeyForId(Type type, long codeId)
        {
            MethodInfo method = typeof(BusinessObjectFactory).GetTypeInfo().GetDeclaredMethods("Load").First(m => m.GetParameters()[0].ParameterType == typeof(long));
            MethodInfo genericMethod = method.MakeGenericMethod(type);
            IBusinessObject returnValue = genericMethod.Invoke(_factory, new object[] { codeId }) as IBusinessObject;

            return returnValue?.Key;
        }

        protected long GetIdFromKey<T>(string code) where T : IBusinessObject
        {
            T lookupObject = _factory.Load<T>(code);

            if (lookupObject != null && lookupObject.DataContractId > 0)
            {
                return lookupObject.DataContractId;
            }

            return 0;
        }

        protected long GetIdFromKey(Type type, string code)
        {
            MethodInfo method = typeof(BusinessObjectFactory).GetTypeInfo().GetDeclaredMethods("Load").First(m => m.GetParameters()[0].ParameterType == typeof(string));
            MethodInfo genericMethod = method.MakeGenericMethod(type);
            IBusinessObject returnValue = genericMethod.Invoke(_factory, new object[] { code }) as IBusinessObject;

            if (returnValue != null)
            {
                return returnValue.DataContractId;
            }
            return 0;
        }

        #endregion Private Methods

        #region Events

        /// <summary>
        /// The value of the field specified by Id has changed.
        /// </summary>
        public event EventHandler<PropertyChangedEventArgs> BusinessPropertyChanged;

        /// <summary>
        /// Called when [business property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnBusinessPropertyChanged(string propertyName)
        {
            var handler = BusinessPropertyChanged;
            if (handler != null)
            {
                BusinessPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Events
    }
}