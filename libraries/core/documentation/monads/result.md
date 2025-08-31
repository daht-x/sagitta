# `Result<TFailure, TSuccess>`

[exception]: https://learn.microsoft.com/en-us/dotnet/api/system.exception
[invalid-operation-exception]: https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception
[bool]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool

***[home](../../../../readme.md) / packages /  [core](../../readme.md) / monads /***

```cs
public sealed class Result<TFailure, TSuccess> : IEquatable<Result<TFailure, TSuccess>>
 ```

- Description: Encapsulates both a possible failure and an expected success for a given action.
- Remarks: Type intended to handle both value and reference types.

## Table of contents

1. [Generics](#generics)
   - [`TFailure`](#tfailure)
   - [`TSuccess`](#tsuccess)
2. [Properties](#properties)
   - [`IsFailed`](#isfailed)
   - [`Failure`](#failure)
   - [`IsSuccessful`](#issuccessful)
   - [`Success`](#success)
3. [Constructors](#constructors)
    - [`Result(failure)`](#resultfailure)
    - [`Result(success)`](#resultsuccess)
4. [Operators](#operators)
    - [`Equality operator ==`](#equality-operator-)
    - [`Inequality operator !=`](#inequality-operator-)
    - [`True operator`](#true-operator)
    - [`False operator`](#false-operator)
    - [`Logical negation operator !`](#logical-negation-operator-)
    - [`Logical OR operator |`](#logical-or-operator-)
5. [Implicit operators](#implicit-operators)
   - [`TFailure(result)`](#tfailureresult)
   - [`TSuccess(result)`](#tsuccessresult)
   - [`Result<TFailure, TSuccess>(failure)`](#resulttfailure-tsuccessfailure)
   - [`Result<TFailure, TSuccess>(success)`](#resulttfailure-tsuccesssuccess)
6. [Methods](#methods)
   - [`Deconstruct(isFailed, failure, success)`](#deconstructisfailed-failure-success)
   - [`TryGetFailure(output)`](#trygetfailureoutput)
   - [`TryGetSuccess(output)`](#trygetsuccessoutput)
   - [`Catch<TException>(execute, createFailure)`](#catchtexceptionexecute-createfailure)
   - [`Catch<TException>(createSuccess, createFailure)`](#catchtexceptioncreatesuccess-createfailure)
   - [`Ensure(predicate, failure)`](#ensurepredicate-failure)
   - [`Ensure(predicate, createFailure)`](#ensurepredicate-createfailure)
   - [`Ensure<TAuxiliary>(auxiliary, predicate, createFailure)`](#ensuretauxiliaryauxiliary-predicate-createfailure)
   - [`Ensure<TAuxiliary>(createAuxiliary, predicate, createFailure)`](#ensuretauxiliarycreateauxiliary-predicate-createfailure)
   - [`DoOnFailure(execute)`](#doonfailureexecute)
   - [`DoOnSuccess(execute)`](#doonsuccessexecute)
   - [`Match(doOnFailure, doOnSuccess)`](#matchdoonfailure-doonsuccess)
   - [`MapFailure<TNewFailure>(create)`](#mapfailuretnewfailurecreate)
   - [`MapSuccess<TNewSuccess>(create)`](#mapsuccesstnewsuccesscreate)
   - [`Bind<TNewSuccess>(create)`](#bindtnewsuccesscreate)
   - [`Reset<TNewSuccess>(success)`](#resettnewsuccesssuccess)
   - [`Reset<TNewSuccess>(result)`](#resettnewsuccessresult)
   - [`Discard`](#discard)
   - [`Reduce<TReducer>(reduceFailure, reduceSuccess)`](#reducetreducerreducefailure-reducesuccess)
   - [`Equals(obj)`](#equalsobj)
   - [`Equals(other)`](#equalsother)
   - [`GetHashCode`](#gethashcode)
   - [`ToString`](#tostring)
7. [See also](#see-also)
8. [Additional resources](#additional-resources)

---

### Generics

#### `TFailure`

Type of possible failure.

***[Top](#resulttfailure-tsuccess)***

#### `TSuccess`

Type of expected success.

***[Top](#resulttfailure-tsuccess)***

---

### Properties

#### `IsFailed`

- Signature

  ```cs
  public bool IsFailed { get; }
  ```

- Description: Indicates whether the state is failed.

***[Top](#resulttfailure-tsuccess)***

#### `Failure`

- Signature

  ```cs
  public TFailure Failure { get; }
  ```

- Description: The possible failure.
- Remarks: If the result is not failed, accessing [`Failure`](#failure) throws an [`InvalidOperationException`][invalid-operation-exception].

***[Top](#resulttfailure-tsuccess)***

#### `IsSuccessful`

- Signature

  ```cs
  public bool IsSuccessful { get; }
  ```

- Description: Indicates whether the state is successful.

***[Top](#resulttfailure-tsuccess)***

#### `Success`

- Signature

  ```cs
  public TSuccess Success { get; }
  ```

- Description: The expected success.
- Remarks: If the result is not successful, accessing [`Success`](#success) throws an [`InvalidOperationException`][invalid-operation-exception].

***[Top](#resulttfailure-tsuccess)***

---

### Constructors

#### `Result(failure)`

- Signature:

  ```cs
  public Result(TFailure failure)
  ```

- Description: Creates a new failed result.
- Parameters:

  | Name      | Description          |
  |:----------|:---------------------|
  | `failure` | The possible failure |

- Returns: A new failed result.

***[Top](#resulttfailure-tsuccess)***

#### `Result(success)`

- Signature:

  ```cs
  public Result(TSuccess success)
  ```

- Description: Creates a new successful result.
- Parameters:

  | Name      | Description          |
  |:----------|:---------------------|
  | `success` | The expected success |

- Returns: A new successful result.

***[Top](#resulttfailure-tsuccess)***

---

### Operators

#### `Equality operator ==`

- Signature:

  ```cs
  public static bool operator ==(Result<TFailure, TSuccess>? left, Result<TFailure, TSuccess>? right)
  ```

- Description: Determines whether the left result is equal to the right result.
- Parameters:

  | Name    | Description           |
  |:--------|:----------------------|
  | `left`  | The main result       |
  | `right` | The result to compare |

- Returns: [`true`][bool] if the left result is equal to the right result; otherwise, [`false`][bool].

***[Top](#resulttfailure-tsuccess)***

#### `Inequality operator !=`

- Signature:

  ```cs
  public static bool operator !=(Result<TFailure, TSuccess>? left, Result<TFailure, TSuccess>? right)
  ```

- Description: Determines whether the left result is not equal to the right result.
- Parameters:

  | Name    | Description           |
  |:--------|:----------------------|
  | `left`  | The main result       |
  | `right` | The result to compare |

- Returns: [`true`][bool] if the left result is not equal to the right result; otherwise, [`false`][bool].

***[Top](#resulttfailure-tsuccess)***

#### `True operator`

- Signature:

  ```cs
  public static bool operator true(Result<TFailure, TSuccess> result)
  ```

- Description: Indicates whether the state is successful.
- Parameters:

  | Name     | Description        |
  |:---------|:-------------------|
  | `result` | The current result |

- Returns: [`true`][bool] if the current result is successful; otherwise, [`false`][bool].

***[Top](#resulttfailure-tsuccess)***

#### `False operator`

- Signature:

  ```cs
  public static bool operator false(Result<TFailure, TSuccess> result)
  ```

- Description: Indicates whether the state is failed.
- Parameters:

  | Name     | Description        |
  |:---------|:-------------------|
  | `result` | The current result |

- Returns: [`true`][bool] if the current result is failed; otherwise, [`false`][bool].

***[Top](#resulttfailure-tsuccess)***

#### `Logical negation operator !`

- Signature:

  ```cs
  public static bool operator !(Result<TFailure, TSuccess> result)
  ```

- Description: Indicates whether the state is failed.
- Parameters:

  | Name     | Description        |
  |:---------|:-------------------|
  | `result` | The current result |

- Returns: [`true`][bool] if the current result is failed; otherwise, [`false`][bool].

***[Top](#resulttfailure-tsuccess)***

#### `Logical OR operator |`

- Signature:

  ```cs
  public static Result<TFailure, TSuccess> operator |(
    Result<TFailure, TSuccess> result, Func<TSuccess, Result<TFailure, TSuccess>> create
  )
  ```

- Description: Binds the previous result to a new one.
- Parameters:

  | Name     | Description                                   |
  |:---------|:----------------------------------------------|
  | `result` | The current result                            |
  | `create` | Creates a new result with the current success |

- Returns: A new result with a different expected success.

***[Top](#resulttfailure-tsuccess)***

---

### Implicit operators

#### `TFailure(result)`

- Signature:

  ```cs
  public static implicit operator TFailure(Result<TFailure, TSuccess> result)
  ```

- Description: Gets the possible failure.
- Remarks: If the result is not failed, an [`InvalidOperationException`][invalid-operation-exception] will be thrown.
- Parameters:

  | Name     | Description        |
  |:---------|:-------------------|
  | `result` | The current result |

- Returns: The possible failure.

***[Top](#resulttfailure-tsuccess)***

#### `TSuccess(result)`

- Signature:

  ```cs
  public static implicit operator TSuccess(Result<TFailure, TSuccess> result)
  ```

- Description: Gets the expected success.
- Remarks: If the result is not successful, an [`InvalidOperationException`][invalid-operation-exception] will be thrown.
- Parameters:

  | Name     | Description        |
  |:---------|:-------------------|
  | `result` | The current result |

- Returns: The expected success.

***[Top](#resulttfailure-tsuccess)***

#### `Result<TFailure, TSuccess>(failure)`

- Signature:

  ```cs
  public static implicit operator Result<TFailure, TSuccess>(TFailure failure)
  ```

- Description: Creates a new failed result.
- Parameters:

  | Name      | Description          |
  |:----------|:---------------------|
  | `failure` | The possible failure |

- Returns: A new failed result.

***[Top](#resulttfailure-tsuccess)***

#### `Result<TFailure, TSuccess>(success)`

- Signature:

  ```cs
  public static implicit operator Result<TFailure, TSuccess>(TSuccess success)
  ```

- Description: Creates a new successful result.
- Parameters:

  | Name      | Description          |
  |:----------|:---------------------|
  | `success` | The expected success |

- Returns: A new successful result.

***[Top](#resulttfailure-tsuccess)***

---

### Methods

#### `Deconstruct(isFailed, failure, success)`

- Signature:

  ```cs
  public void Deconstruct(out bool isFailed, out TFailure? failure, out TSuccess? success)
  ```

- Description: Deconstructs the root state of the result.
- Parameters:

  | Name       | Description                           |
  |:-----------|:--------------------------------------|
  | `isFailed` | Indicates whether the state is failed |
  | `failure`  | The possible failure                  |
  | `success`  | The expected success                  |

***[Top](#resulttfailure-tsuccess)***

#### `TryGetFailure(output)`

- Signature:

  ```cs
  public bool TryGetFailure(out TFailure? output)
  ```

- Description: Determines whether the result represents a failure.
- Parameters:

  | Name     | Description          |
  |:---------|:---------------------|
  | `output` | The possible failure |

- Returns: [`true`][bool] if the result is failed; otherwise, [`false`][bool].

***[Top](#resulttfailure-tsuccess)***

#### `TryGetSuccess(output)`

- Signature:

  ```cs
  public bool TryGetSuccess(out TSuccess? output)
  ```

- Description: Determines whether the result represents a success.
- Parameters:

  | Name     | Description          |
  |:---------|:---------------------|
  | `output` | The expected success |

- Returns: [`true`][bool] if the result is successful; otherwise, [`false`][bool].

***[Top](#resulttfailure-tsuccess)***

#### `Catch<TException>(execute, createFailure)`

- Signature:

  ```cs
  public Result<TFailure, TSuccess> Catch<TException>(
    Action<TSuccess> execute, Func<TException, TFailure> createFailure
  )
    where TException : Exception
  ```

- Description: Treats [`TException`][exception] as a new failed result.
- Generics:

  | Name         | Description                |
  |:-------------|:---------------------------|
  | `TException` | Type of possible exception |

- Parameters:

  | Name            | Description                |
  |:----------------|:---------------------------|
  | `execute`       | The action to execute      |
  | `createFailure` | Creates a possible failure |

- Returns: A new failed result if `execute` throws [`TException`][exception]; otherwise, the previous result.

***[Top](#resulttfailure-tsuccess)***

#### `Catch<TException>(createSuccess, createFailure)`

- Signature:

  ```cs
  public Result<TFailure, TSuccess> Catch<TException>(
    Func<TSuccess, TSuccess> createSuccess, Func<TException, TFailure> createFailure
  )
    where TException : Exception
  ```

- Description: Treats [`TException`][exception] as a new failed result.
- Generics:

  | Name         | Description                |
  |:-------------|:---------------------------|
  | `TException` | Type of possible exception |

- Parameters:

  | Name            | Description                 |
  |:----------------|:----------------------------|
  | `createSuccess` | Creates an expected success |
  | `createFailure` | Creates a possible failure  |

- Returns: A new failed result if the value of `createSuccess` throws [`TException`][exception]; otherwise, a new
successful result.

***[Top](#resulttfailure-tsuccess)***

#### `Ensure(predicate, failure)`

- Signature:

  ```cs
  public Result<TFailure, TSuccess> Ensure(Func<TSuccess, bool> predicate, TFailure failure)
  ```

- Description: Ensures a new failed result if `predicate` evaluates to [`true`][bool].
- Parameters:

  | Name        | Description               |
  |:------------|:--------------------------|
  | `predicate` | Creates a set of criteria |
  | `failure`   | The possible failure      |

- Returns: A new failed result if the value of `predicate` is [`true`][bool]; otherwise, the previous result.

***[Top](#resulttfailure-tsuccess)***

#### `Ensure(predicate, createFailure)`

- Signature:

  ```cs
  public Result<TFailure, TSuccess> Ensure(Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)
  ```

- Description: Ensures a new failed result if `predicate` evaluates to [`true`][bool].
- Parameters:

  | Name            | Description                |
  |:----------------|:---------------------------|
  | `predicate`     | Creates a set of criteria  |
  | `createFailure` | Creates a possible failure |

- Returns: A new failed result if the value of `predicate` is [`true`][bool]; otherwise, the previous result.

***[Top](#resulttfailure-tsuccess)***

#### `Ensure<TAuxiliary>(auxiliary, predicate, createFailure)`

- Signature:

  ```cs
  public Result<TFailure, TSuccess> Ensure<TAuxiliary>(
    TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate,
    Func<TSuccess, TAuxiliary, TFailure> createFailure
  )
  ```

- Description: Ensures a new failed result if `predicate` evaluates to [`true`][bool].
- Generics:

  | Name         | Description       |
  |:-------------|:------------------|
  | `TAuxiliary` | Type of auxiliary |

- Parameters:

  | Name            | Description                                                              |
  |:----------------|:-------------------------------------------------------------------------|
  | `auxiliary`     | The auxiliary to use in combination with `predicate` and `createFailure` |
  | `predicate`     | Creates a set of criteria                                                |
  | `createFailure` | Creates a possible failure                                               |

- Returns: A new failed result if the value of `predicate` is [`true`][bool]; otherwise, the previous result.

***[Top](#resulttfailure-tsuccess)***

#### `Ensure<TAuxiliary>(createAuxiliary, predicate, createFailure)`

- Signature:

  ```cs
  public Result<TFailure, TSuccess> Ensure<TAuxiliary>(
    Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate,
    Func<TSuccess, TAuxiliary, TFailure> createFailure
  )
  ```

- Description: Ensures a new failed result if `predicate` evaluates to [`true`][bool].
- Generics:

  | Generic      | Description       |
  |:-------------|:------------------|
  | `TAuxiliary` | Type of auxiliary |

- Parameters:

  | Name              | Description                                                                     |
  |:------------------|:--------------------------------------------------------------------------------|
  | `createAuxiliary` | Creates an auxiliary to use in combination with `predicate` and `createFailure` |
  | `predicate`       | Creates a set of criteria                                                       |
  | `createFailure`   | Creates a possible failure                                                      |

- Returns: A new failed result if the value of `predicate` is [`true`][bool]; otherwise, the previous result.

***[Top](#resulttfailure-tsuccess)***

#### `DoOnFailure(execute)`

- Signatures:

  - ```cs
    public Result<TFailure, TSuccess> DoOnFailure(Action execute)
    ```

  - ```cs
    public Result<TFailure, TSuccess> DoOnFailure(Action<TFailure> execute)
    ```

- Description: Executes an action if the previous result is failed.
- Parameters:

  | Name      | Description           |
  |:----------|:----------------------|
  | `execute` | The action to execute |

- Returns: The previous result.

***[Top](#resulttfailure-tsuccess)***

#### `DoOnSuccess(execute)`

- Signatures:

  - ```cs
    public Result<TFailure, TSuccess> DoOnSuccess(Action execute)
    ```

  - ```cs
    public Result<TFailure, TSuccess> DoOnSuccess(Action<TSuccess> execute)
    ```

- Description: Executes an action if the previous result is successful.
- Parameters:

  | Name      | Description           |
  |:----------|:----------------------|
  | `execute` | The action to execute |

- Returns: The previous result.

***[Top](#resulttfailure-tsuccess)***

#### `Match(doOnFailure, doOnSuccess)`

- Signatures:

  - ```cs
    public Result<TFailure, TSuccess> Match(Action doOnFailure, Action doOnSuccess)
    ```

  - ```cs
    public Result<TFailure, TSuccess> Match(Action<TFailure> doOnFailure, Action<TSuccess> doOnSuccess)
    ```

- Description: Executes an action based on the state of the previous result.
- Parameters:

  | Name          | Description                                                |
  |:--------------|:-----------------------------------------------------------|
  | `doOnFailure` | The action to execute if the previous result is failed     |
  | `doOnSuccess` | The action to execute if the previous result is successful |

- Returns: The previous result.

***[Top](#resulttfailure-tsuccess)***

#### `MapFailure<TNewFailure>(create)`

- Signature:

  ```cs
  public Result<TNewFailure, TSuccess> MapFailure<TNewFailure>(Func<TFailure, TNewFailure> create)
  ```

- Description: Maps the possible failure to a value of another type.
- Generics:

  | Name          | Description              |
  |:--------------|:-------------------------|
  | `TNewFailure` | Type of possible failure |

- Parameters:

  | Name     | Description                |
  |:---------|:---------------------------|
  | `create` | Creates a possible failure |

- Returns: A new result with a different type of possible failure.

***[Top](#resulttfailure-tsuccess)***

#### `MapSuccess<TNewSuccess>(create)`

- Signature:

  ```cs
  public Result<TFailure, TNewSuccess> MapSuccess<TNewSuccess>(Func<TSuccess, TNewSuccess> create)
  ```

- Description: Maps the expected success to a value of another type.
- Generics:

  | Name          | Description              |
  |:--------------|:-------------------------|
  | `TNewSuccess` | Type of expected success |

- Parameters:

  | Name     | Description                 |
  |:---------|:----------------------------|
  | `create` | Creates an expected success |

- Returns: A new result with a different type of expected success.

***[Top](#resulttfailure-tsuccess)***

#### `Bind<TNewSuccess>(create)`

- Signature:

  ```cs
  public Result<TFailure, TNewSuccess> Bind<TNewSuccess>(Func<TSuccess, Result<TFailure, TNewSuccess>> create)
  ```

- Description: Binds the previous result to a new one.
- Generics:

  | Name          | Description              |
  |:--------------|:-------------------------|
  | `TNewSuccess` | Type of expected success |

- Parameters:

  | Name     | Description                                   |
  |:---------|:----------------------------------------------|
  | `create` | Creates a new result with the current success |

- Returns: A new result with a different type of expected success.

***[Top](#resulttfailure-tsuccess)***

#### `Reset<TNewSuccess>(success)`

- Signature:

  ```cs
  public Result<TFailure, TNewSuccess> Reset<TNewSuccess>(TNewSuccess success)
  ```

- Description: Resets the state of the expected success.
- Generics:

  | Name          | Description              |
  |:--------------|:-------------------------|
  | `TNewSuccess` | Type of expected success |

- Parameters:

  | Name      | Description                                   |
  |:----------|:----------------------------------------------|
  | `success` | The expected success that acts as initializer |

- Returns: A new result with a different type of expected success.

***[Top](#resulttfailure-tsuccess)***

#### `Reset<TNewSuccess>(result)`

- Signature:

  ```cs
  public Result<TFailure, TNewSuccess> Reset<TNewSuccess>(Result<TFailure, TNewSuccess> result)
  ```

- Description: Resets the state of the expected success.
- Generics:

  | Name          | Description              |
  |:--------------|:-------------------------|
  | `TNewSuccess` | Type of expected success |

- Parameters:

  | Name     | Description                         |
  |:---------|:------------------------------------|
  | `result` | The result that acts as initializer |

- Returns: A new result with a different type of expected success.

***[Top](#resulttfailure-tsuccess)***

#### `Discard`

- Signature:

  ```cs
  public Result<TFailure, Unit> Discard()
  ```

- Description: Discards the expected success.
- Returns: A new result that replaces the expected success with [`Unit`](../unit.md).

***[Top](#resulttfailure-tsuccess)***

#### `Reduce<TReducer>(reduceFailure, reduceSuccess)`

- Signature:

  ```cs
  public TReducer Reduce<TReducer>(Func<TFailure, TReducer> reduceFailure, Func<TSuccess, TReducer> reduceSuccess)
  ```

- Description: Reduces the possible failure or expected success to a single value.
- Generics:

  | Name       | Description     |
  |:-----------|:----------------|
  | `TReducer` | Type of reducer |

- Parameters:

  | Name            | Description                  |
  |:----------------|:-----------------------------|
  | `reduceFailure` | Reduces the possible failure |
  | `reduceSuccess` | Reduces the expected success |

- Returns: A new value that can be the possible failure or the expected success.

***[Top](#resulttfailure-tsuccess)***

#### `Equals(obj)`

- Signature:

  ```cs
  public override bool Equals(object? obj)
  ```

- Description: Determines whether the specified result is equal to the current result.
- Parameters:

  | Name  | Description                                      |
  |:------|:-------------------------------------------------|
  | `obj` | The result to compare with the current reference |

- Returns: [`true`][bool] if the specified result is equal to the current result; otherwise, [`false`][bool].

***[Top](#resulttfailure-tsuccess)***

#### `Equals(other)`

- Signature:

  ```cs
  public bool Equals(Result<TFailure, TSuccess>? other)
  ```

- Description: Determines whether the specified result is equal to the current result.
- Parameters:

  | Name    | Description                                      |
  |:--------|:-------------------------------------------------|
  | `other` | The result to compare with the current reference |

- Returns: [`true`][bool] if the specified result is equal to the current result; otherwise, [`false`][bool].

***[Top](#resulttfailure-tsuccess)***

#### `GetHashCode`

- Signature:

  ```cs
  public override int GetHashCode()
  ```

- Description: Gets the hash code based on the primary members of the current result.
- Returns: The calculated hash code.

***[Top](#resulttfailure-tsuccess)***

#### `ToString`

- Signature:

  ```cs
  public override string ToString()
  ```

- Description: Gets the value of the current result.
- Returns: The value of the current result.

***[Top](#resulttfailure-tsuccess)***

---

### See also

- [Unit](../unit.md)
- [ResultFactory](./result-factory.md)
- [ValueResult<TFailure, TSuccess>](./value-result.md)
- [ValueResultFactory](./value-result-factory.md)

***[Top](#resulttfailure-tsuccess)***

---

### Additional resources

- [License](../../../../license.txt)
- [Security policy](../../../../security.md)
- [Code of conduct](../../../../code-of-conduct.md)
- [Contributing guidelines](../../../../contributing.md)

***[Top](#resulttfailure-tsuccess)***
