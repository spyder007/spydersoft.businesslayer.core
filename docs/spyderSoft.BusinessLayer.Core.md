## `BusinessObject<TDataContract>`

Class BusinessObject.  Implements the `System.IDisposable`  Implements the [spyderSoft.BusinessLayer.Core.Interfaces.IDataStoreConsumer](spyderSoft.BusinessLayer.Core.Interfaces.md#idatastoreconsumer)  Implements the [spyderSoft.BusinessLayer.Core.Interfaces.IBusinessObject`1](spyderSoft.BusinessLayer.Core.Interfaces.md#ibusinessobject`1)
```csharp
public abstract class spyderSoft.BusinessLayer.Core.BusinessObject<TDataContract>
    : IDisposable, IDataStoreConsumer, IBusinessObject<TDataContract>, IBusinessObject

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `TDataContract` | BusinessObjectData | Gets the business object data. | 
| `TDataContract` | DataContract | Gets or sets the data contract. | 
| `Int64` | DataContractId | Gets the data contract identifier. | 
| `DateTimeOffset` | DateCreated | Gets or sets the date created. | 
| `DateTimeOffset` | DateUpdated | Gets or sets the date updated. | 
| `String` | DisplayName | Gets the display name. | 
| `String` | Key | Gets the key. | 
| `IDataStore` | Store | The data store to use with the business object | 


Events

| Type | Name | Summary | 
| --- | --- | --- | 
| `EventHandler<PropertyChangedEventArgs>` | BusinessPropertyChanged | The value of the field specified by Id has changed. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | AfterInsert() | Can be overridden in a sub class to execute code after a new item is successfully saved. Executes before AfterSave is called. | 
| `void` | AfterSave() | Can be overridden in a sub class to execute code after successful save and after AfterInsert is called | 
| `DeleteResults` | Delete() | Delete the business object from the data store | 
| `void` | Dispose() | Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources. | 
| `void` | Dispose(`Boolean` disposing) | Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources. | 
| `Int64` | GetIdFromKey(`String` code) | Gets the identifier from key. | 
| `Int64` | GetIdFromKey(`Type` type, `String` code) | Gets the identifier from key. | 
| `void` | GetIdValues() | Gets the identifier values. | 
| `String` | GetKeyForId(`Int64` codeId) | Gets the key for identifier. | 
| `String` | GetKeyForId(`Type` type, `Int64` codeId) | Gets the key for identifier. | 
| `Expression<Func<TDataContract, Boolean>>` | KeySearchFunction(`String` searchString) | Keys the search function. | 
| `void` | Load(`Int64` primaryKey) | Loads the specified primary key. | 
| `void` | LoadByKey(`String` key) | Loads the by key. | 
| `void` | LoadDefaults() | Loads the defaults. | 
| `void` | OnBusinessPropertyChanged(`String` propertyName) | Called when [business property changed]. | 
| `void` | OnLoaded() | Called when [loaded]. | 
| `void` | OnSaved() | Called when [saved]. | 
| `void` | OnSaving() | Called when [saving]. | 
| `void` | ResetDataAndLists() | Resets the data and lists. | 
| `BusinessResult<IBusinessObject>` | Save() | Validates and saves the business object | 
| `BusinessResult<IBusinessObject>` | SaveBusinessObject() | Saves the business object.  This is overridable. | 
| `void` | SetDataStore(`IDataStore` store) | Sets the data store. | 
| `void` | SetIdFromKeyFields() | Sets the identifier from key fields. | 
| `void` | SetKeyFieldsFromId() | Sets the key fields from identifier. | 
| `void` | SubscribeToDataContractEvents() | Subscribes to data contract events. | 
| `void` | UnsubscribeDataContractEvents() | Unsubscribes the data contract events. | 
| `List<ResultMessage>` | Validate() | Validate the business object instance.  This virtual base implementation performs required field validation. | 
| `List<IResultMessage>` | ValidateForSave() | Validates for save. | 
| `List<ResultMessage>` | ValidateObject() | Validates the object. | 
| `List<ResultMessage>` | ValidateObjectProperties() | Validate that the required fields have values and that they are appropriate.  The required fields are determined via virtual method GetRequiredFields and that should be overridden for each business object implementation. | 


Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | DuplicateRecordMessage | The Constant for a duplicate record error message. | 


## `BusinessObjectFactory`

Class BusinessObjectFactory.  Implements the [spyderSoft.BusinessLayer.Core.Interfaces.IBusinessObjectFactory](spyderSoft.BusinessLayer.Core.Interfaces.md#ibusinessobjectfactory)
```csharp
public class spyderSoft.BusinessLayer.Core.BusinessObjectFactory
    : IBusinessObjectFactory

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `IServiceInjector` | ServiceInjector | Gets or sets the service injector. | 
| `IDataStore` | Store | Gets or sets the store. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `TBusinessObject` | GetBusinessObject(`TDataContract` contract) | Gets the business object. | 
| `TBusinessObject` | GetNew() | Gets the new. | 
| `void` | InjectServices(`IBusinessObject` businessObject) | Injects the services. | 
| `TBusinessObject` | Load(`Int64` id) | Loads the specified identifier. | 
| `TBusinessObject` | Load(`String` key) | Loads the specified identifier. | 


## `ExtensionMethods`

Class ExtensionMethods.
```csharp
public static class spyderSoft.BusinessLayer.Core.ExtensionMethods

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | CopyPropertiesTo(this `T` source, `T` dest) | Copies the properties to. | 
| `Boolean` | HasHaltingMessages(this `IEnumerable<ActionResult>` results) | Determines whether [has halting messages] [the specified results]. | 


