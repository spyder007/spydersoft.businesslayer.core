## `IBusinessObject`

The Business Object interface  Implements the [spyderSoft.BusinessLayer.Core.Interfaces.IBusinessObject](spyderSoft.BusinessLayer.Core.Interfaces.md#ibusinessobject)
```csharp
public interface spyderSoft.BusinessLayer.Core.Interfaces.IBusinessObject

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int64` | DataContractId | Gets the data contract identifier. | 
| `DateTimeOffset` | DateCreated | Gets or sets the date created. | 
| `DateTimeOffset` | DateUpdated | Gets or sets the date updated. | 
| `String` | DisplayName | Gets the display name. | 
| `String` | Key | Gets the key. | 
| `IDataStore` | Store | The data store to use with the business object | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `DeleteResults` | Delete() | Deletes this instance. | 
| `void` | Load(`Int64` id) | Loads the specified identifier. | 
| `void` | LoadByKey(`String` key) | Loads the by key. | 
| `BusinessResult<IBusinessObject>` | Save() | Saves this instance. | 
| `void` | SetIdFromKeyFields() | Sets the identifier from key fields. | 
| `void` | SetKeyFieldsFromId() | Sets the key fields from identifier. | 


## `IBusinessObject<TDataContract>`

Provides an interface to relate a data contract to the BO interface.  Implements the [spyderSoft.BusinessLayer.Core.Interfaces.IBusinessObject](spyderSoft.BusinessLayer.Core.Interfaces.md#ibusinessobject)
```csharp
public interface spyderSoft.BusinessLayer.Core.Interfaces.IBusinessObject<TDataContract>
    : IBusinessObject

```

## `IBusinessObjectFactory`

Interface IBusinessObjectFactory
```csharp
public interface spyderSoft.BusinessLayer.Core.Interfaces.IBusinessObjectFactory

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `TBusinessObject` | GetBusinessObject(`TDataContract` contract) | Gets the business object. | 
| `TBusinessObject` | GetNew() | Gets the new. | 
| `void` | InjectServices(`IBusinessObject` businessObject) | Injects the services. | 
| `TBusinessObject` | Load(`Int64` id) | Loads the specified identifier. | 
| `TBusinessObject` | Load(`String` key) | Loads the specified identifier. | 


## `IBusinessObjectFactoryConsumer`

Interface IBusinessObjectFactoryConsumer
```csharp
public interface spyderSoft.BusinessLayer.Core.Interfaces.IBusinessObjectFactoryConsumer

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | SetBusinessObjectFactory(`BusinessObjectFactory` factory) | Sets the business object factory. | 


## `IDataStoreConsumer`

Interface IDataStoreConsumer
```csharp
public interface spyderSoft.BusinessLayer.Core.Interfaces.IDataStoreConsumer

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | SetDataStore(`IDataStore` dataStore) | Sets the data store. | 


## `IServiceInjector`

Interface IServiceInjector
```csharp
public interface spyderSoft.BusinessLayer.Core.Interfaces.IServiceInjector

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | InjectServices(`IBusinessObject` businessObject) | Injects the services. | 


