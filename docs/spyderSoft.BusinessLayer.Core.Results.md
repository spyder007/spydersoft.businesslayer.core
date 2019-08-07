## `ActionResult`

Class ActionResult.  Implements the [spyderSoft.BusinessLayer.Core.Results.IResultMessage](spyderSoft.BusinessLayer.Core.Results.md#iresultmessage)
```csharp
public class spyderSoft.BusinessLayer.Core.Results.ActionResult
    : IResultMessage

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Exception` | Exception | Gets or sets the exception. | 
| `String` | Message | Gets or Sets the Message to be displayed | 
| `ResultMessageType` | MessageType | Gets or Sets the type of message | 
| `ResultActionType` | ResultAction | Gets or sets the result action. | 
| `String` | ShortMessage | Gets or Sets a abbreviated version of the message | 


## `BusinessResult<TResult>`

Creates a Result from a data operation for a Business Object.  Implements the [spyderSoft.BusinessLayer.Core.Results.IResult`1](spyderSoft.BusinessLayer.Core.Results.md#iresult`1)
```csharp
public class spyderSoft.BusinessLayer.Core.Results.BusinessResult<TResult>
    : IResult<TResult>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | IsSuccessful | Gets or sets the IsSuccessful. | 
| `List<IResultMessage>` | Messages | Gets or sets the messages. | 
| `TResult` | Result | Gets or sets the results. | 
| `ResultActionType` | ResultAction | Gets or sets the result action. | 
| `ResultType` | ResultType | Gets or sets the type of the result. | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | ToString() | Returns a `System.String` that represents this instance. | 


## `DeleteResults`

Results from a Delete
```csharp
public class spyderSoft.BusinessLayer.Core.Results.DeleteResults

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | IsSuccessful | Indicated is the delete succeeded.  Read Only | 
| `String` | Messages | Messages as a string - Read Only | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | AddMessage(`String` message) | Add a message to the delete results | 


## `IResult<TResult>`

Interface for a Result returned from a data operation
```csharp
public interface spyderSoft.BusinessLayer.Core.Results.IResult<TResult>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | IsSuccessful | Gets or sets the IsSuccessful. | 
| `List<IResultMessage>` | Messages | Gets or sets the messages. | 
| `TResult` | Result | Gets or sets the Result. | 
| `ResultType` | ResultType | Gets or sets the type of the result. | 


## `IResultMessage`

An interface to define messages to be returned
```csharp
public interface spyderSoft.BusinessLayer.Core.Results.IResultMessage

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Message | Gets or Sets the Message to be displayed | 
| `ResultMessageType` | MessageType | Gets or Sets the type of message | 
| `String` | ShortMessage | Gets or Sets a abbreviated version of the message | 


## `ResultActionType`

Used to indicate a action needed after a save has been executed
```csharp
public enum spyderSoft.BusinessLayer.Core.Results.ResultActionType
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | None | The none | 
| `1` | Success | The success | 
| `2` | Error | The error | 
| `3` | Warning | The warning | 
| `4` | PromptForAction | The prompt for action | 
| `5` | Cancel | The cancel | 


## `ResultMessage`

A validation or general message from trying to save.  Implements the [spyderSoft.BusinessLayer.Core.Results.IResultMessage](spyderSoft.BusinessLayer.Core.Results.md#iresultmessage)
```csharp
public class spyderSoft.BusinessLayer.Core.Results.ResultMessage
    : IResultMessage

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Message | The message to be shown | 
| `ResultMessageType` | MessageType | The type of message | 
| `String` | PropertyName | The property name of the field in error, if any. | 
| `String` | ShortMessage | A short version of the message | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | ToString() | Returns a `System.String` that represents this instance. | 


## `ResultMessageType`

The type of the message or Severity
```csharp
public enum spyderSoft.BusinessLayer.Core.Results.ResultMessageType
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | Information | The information | 
| `1` | Warning | The warning | 
| `2` | Error | The error | 
| `3` | Alert | The alert | 
| `4` | Cancel | The cancel | 


## `ResultType`

Used to indicate the result of the save.
```csharp
public enum spyderSoft.BusinessLayer.Core.Results.ResultType
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | Success | The success | 
| `1` | GeneralFailure | The general failure | 
| `2` | ValidationFailure | The validation failure | 


