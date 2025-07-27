# `Result<TFailure, TSuccess>`

[invalid-operation-exception]: https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception

***[home](../../../../readme.md) / packages /  [core](../../readme.md) / monads /***

```cs
public sealed class Result<TFailure, TSuccess> : IEquatable<Result<TFailure, TSuccess>>
 ```

Type intended to handle both the possible failure and the expected success of a given action.

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
4. [Equality operators](#equality-operators)
    - [`==(left, right)`](#left-right)
    - [`!=(left, right)`](#left-right-1)
5. [Implicit operators](#implicit-operators)
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
   - [`Map<TSuccessToMap>(successToMap)`](#maptsuccesstomapsuccesstomap)
   - [`Map<TSuccessToMap>(createSuccessToMap)`](#maptsuccesstomapcreatesuccesstomap)
   - [`Bind<TSuccessToBind>(createResultToBind)`](#bindtsuccesstobindcreateresulttobind)
   - [`Reset<TSuccessToInitialize>(initializerResult)`](#resettsuccesstoinitializeinitializerresult)
   - [`Discard()`](#discard)
   - [`Reduce<TReducer>(reduceFailure, reduceSuccess)`](#reducetreducerreducefailure-reducesuccess)
   - [`Equals(obj)`](#equalsobj)
   - [`Equals(other)`](#equalsother)
   - [`GetHashCode()`](#gethashcode)
7. [Additional resources](#additional-resources)

### Generics

#### `TFailure`

Type of possible failure.

***[Top](#resulttfailure-tsuccess)***

#### `TSuccess`

Type of expected success.

***[Top](#resulttfailure-tsuccess)***

### Properties

#### `IsFailed`

- Signature

  ```cs
  public bool IsFailed { get; }
  ```

- Description: Indicates whether the status is failed.

***[Top](#resulttfailure-tsuccess)***

#### `Failure`

- Signature

  ```cs
  public TFailure Failure { get; }
  ```

- Description: The possible failure.
- Remarks: If the result is not failed, `Failure` throws [`InvalidOperationException`][invalid-operation-exception].

***[Top](#resulttfailure-tsuccess)***

#### `IsSuccessful`

- Signature

  ```cs
  public bool IsSuccessful { get; }
  ```

- Description: Indicates whether the status is successful.

***[Top](#resulttfailure-tsuccess)***

#### `Success`

- Signature

  ```cs
  public TSuccess Success { get; }
  ```

- Description: The expected success.
- Remarks: If the result is not successful, `Success` throws [`InvalidOperationException`][invalid-operation-exception].

***[Top](#resulttfailure-tsuccess)***

### Constructors

#### `Result(failure)`

- Signature:

  ```cs
  public Result(TFailure failure)
  ```

- Description: Creates a new failed result.
- Parameters:

  | Name      | Description        |
  |:----------|:-------------------|
  | `failure` | A possible failure |

- Return: A new failed result.

***[Top](#resulttfailure-tsuccess)***

#### `Result(success)`

- Signature:

  ```cs
  public Result(TSuccess success)
  ```

- Description: Creates a new successful result.
- Parameters:

  | Name      | Description         |
  |:----------|:--------------------|
  | `success` | An expected success |

- Return: A new successful result.

***[Top](#resulttfailure-tsuccess)***

### Equality operators

#### `==(left, right)`

- Signature:

  ```cs
  public static bool operator ==(Result<TFailure, TSuccess>? left, Result<TFailure, TSuccess>? right)
  ```

- Description: Determines whether the left result is equal to the right result (equality is determined by value).
- Parameters:

  | Name    | Description           |
  |:--------|:----------------------|
  | `left`  | The main result       |
  | `right` | The result to compare |

- Return: `true` if the left result is equal to the right result; otherwise,`false`.

***[Top](#resulttfailure-tsuccess)***

#### `!=(left, right)`

- Signature:

  ```cs
  public static bool operator !=(Result<TFailure, TSuccess>? left, Result<TFailure, TSuccess>? right)
  ```

- Description: Determines whether the left result is not equal to the right result (equality is determined by value).
- Parameters:

  | Name    | Description           |
  |:--------|:----------------------|
  | `left`  | The main result       |
  | `right` | The result to compare |

- Return: `true` if the left result is not equal to the right result; otherwise, `false`.

***[Top](#resulttfailure-tsuccess)***

### Implicit operators

#### `Result<TFailure, TSuccess>(failure)`

- Signature:

  ```cs
  public static implicit operator Result<TFailure, TSuccess>(TFailure failure)
  ```

- Description: Creates a new failed result.
- Parameters:

  | Name      | Description        |
  |:----------|:-------------------|
  | `failure` | A possible failure |

- Return: A new failed result.

***[Top](#resulttfailure-tsuccess)***

#### `Result<TFailure, TSuccess>(success)`

- Signature:

  ```cs
  public static implicit operator Result<TFailure, TSuccess>(TSuccess success)
  ```

- Description: Creates a new successful result.
- Parameters:

  | Name      | Description         |
  |:----------|:--------------------|
  | `success` | An expected success |

- Return: A new successful result.

***[Top](#resulttfailure-tsuccess)***

### Methods

#### `Deconstruct(isFailed, failure, success)`

- Signature:

  ```cs
  public void Deconstruct(out bool isFailed, out TFailure? failure, out TSuccess? success)
  ```

- Description: Deconstructs the root state of the result.
- Parameters:

  | Name       | Description                            |
  |:-----------|:---------------------------------------|
  | `isFailed` | Indicates whether the status is failed |
  | `failure`  | The possible failure                   |
  | `success`  | The expected success                   |

***[Top](#resulttfailure-tsuccess)***

#### `TryGetFailure(output)`

- Signature:

  ```cs
  public bool TryGetFailure(out TFailure? output)
  ```

- Description: Determines whether the result represents a failure.
- Parameters:

  | Name       | Description                            |
  |:-----------|:---------------------------------------|
  | `output` | The possible failure. |

- Return: `true` if the result is failed; otherwise, `false`.

***[Top](#resulttfailure-tsuccess)***

#### `TryGetSuccess(output)`

- Signature:

  ```cs
  public bool TryGetSuccess(out TSuccess? output)
  ```

- Description: Determines whether the result represents a success.
- Parameters:

  | Name       | Description                            |
  |:-----------|:---------------------------------------|
  | `output` | The expected success. |

- Return: `true` if the result is successful; otherwise, `false`.

***[Top](#resulttfailure-tsuccess)***

#### `Catch<TException>(execute, createFailure)`

- Signature:

  ```cs
  public Result<TFailure, TSuccess> Catch<TException>(Action<TSuccess> execute, Func<TException, TFailure> createFailure)
    where TException : Exception
  ```

- Description: Treats `TException` as a new failed result.
- Generics:

  | Name         | Description                |
  |:-------------|:---------------------------|
  | `TException` | Type of possible exception |

- Parameters:

  | Name            | Description                |
  |:----------------|:---------------------------|
  | `execute`       | The action to execute      |
  | `createFailure` | Creates a possible failure |

- Return: A new failed result if `execute` throws `TException` otherwise, the previous result.

***[Top](#resulttfailure-tsuccess)***

#### `Catch<TException>(createSuccess, createFailure)`

- Signature:

  ```cs
  public Result<TFailure, TSuccess> Catch<TException>(Func<TSuccess, TSuccess> createSuccess, Func<TException, TFailure> createFailure)
    where TException : Exception
  ```

- Description: Treats `TException` as a new failed result.
- Generics:

  | Name         | Description                |
  |:-------------|:---------------------------|
  | `TException` | Type of possible exception |

- Parameters:

  | Name            | Description                 |
  |:----------------|:----------------------------|
  | `createSuccess` | Creates an expected success |
  | `createFailure` | Creates a possible failure  |

- Return: A new failed result if the value of `createSuccess` throws `TException`; otherwise, a new successful result.

***[Top](#resulttfailure-tsuccess)***

#### `Ensure(predicate, failure)`

- Signature:

  ```cs
  public Result<TFailure, TSuccess> Ensure(Func<TSuccess, bool> predicate, TFailure failure)
  ```

- Description: Ensures a new failed result if `predicate` evaluates to `true`.
- Parameters:

  | Name        | Description               |
  |:------------|:--------------------------|
  | `predicate` | Creates a set of criteria |
  | `failure`   | A possible failure        |

- Return: A new failed result if the value of `predicate` is `true`; otherwise, the previous result.

***[Top](#resulttfailure-tsuccess)***

#### `Ensure(predicate, createFailure)`

- Signature:

  ```cs
  public Result<TFailure, TSuccess> Ensure(Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)
  ```

- Description: Ensures a new failed result if `predicate` evaluates to `true`.
- Parameters:

  | Name            | Description                |
  |:----------------|:---------------------------|
  | `predicate`     | Creates a set of criteria  |
  | `createFailure` | Creates a possible failure |

- Return: A new failed result if the value of `predicate` is `true`; otherwise, the previous result.

***[Top](#resulttfailure-tsuccess)***

#### `Ensure<TAuxiliary>(auxiliary, predicate, createFailure)`

- Signature:

  ```cs
  public Result<TFailure, TSuccess> Ensure<TAuxiliary>(TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
  ```

- Description: Ensures a new failed result if `predicate` evaluates to `true`.
- Generics:

  | Name         | Description       |
  |:-------------|:------------------|
  | `TAuxiliary` | Type of auxiliary |

- Parameters:

  | Name            | Description                                                             |
  |:----------------|:------------------------------------------------------------------------|
  | `auxiliary`     | An auxiliary to use in combination with `predicate` and `createFailure` |
  | `predicate`     | Creates a set of criteria                                               |
  | `createFailure` | Creates a possible failure                                              |

- Return: A new failed result if the value of `predicate` is `true`; otherwise, the previous result.

***[Top](#resulttfailure-tsuccess)***

#### `Ensure<TAuxiliary>(createAuxiliary, predicate, createFailure)`

- Signature:

  ```cs
  public Result<TFailure, TSuccess> Ensure<TAuxiliary>(Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
  ```

- Description: Ensures a new failed result if `predicate` evaluates to `true`.
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

- Return: A new failed result if the value of `predicate` is `true`; otherwise, the previous result.

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

- Return: The previous result.

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

- Return: The previous result.

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

- Return: The previous result.

***[Top](#resulttfailure-tsuccess)***

#### `Map<TSuccessToMap>(successToMap)`

- Signature:

  ```cs
  public Result<TFailure, TSuccessToMap> Map<TSuccessToMap>(TSuccessToMap successToMap)
  ```

- Description: Maps the expected success to a value of another type.
- Generics:

  | Name            | Description                     |
  |:----------------|:--------------------------------|
  | `TSuccessToMap` | Type of expected success to map |

- Parameters:

  | Name           | Description                |
  |:---------------|:---------------------------|
  | `successToMap` | An expected success to map |

- Return: A new result with a different type of expected success.

***[Top](#resulttfailure-tsuccess)***

#### `Map<TSuccessToMap>(createSuccessToMap)`

- Signature:

  ```cs
  public Result<TFailure, TSuccessToMap> Map<TSuccessToMap>(Func<TSuccess, TSuccessToMap> createSuccessToMap)
  ```

- Description: Maps the expected success to a value of another type.
- Generics:

  | Name            | Description                     |
  |:----------------|:--------------------------------|
  | `TSuccessToMap` | Type of expected success to map |

- Parameters:

  | Name                 | Description                        |
  |:---------------------|:-----------------------------------|
  | `createSuccessToMap` | Creates an expected success to map |

- Return: A new result with a different type of expected success.

***[Top](#resulttfailure-tsuccess)***

#### `Bind<TSuccessToBind>(createResultToBind)`

- Signature:

  ```cs
  public Result<TFailure, TSuccessToBind> Bind<TSuccessToBind>(Func<TSuccess, Result<TFailure, TSuccessToBind>> createResultToBind)
  ```

- Description: Binds the previous result to a new one.
- Generics:

  | Name             | Description                      |
  |:-----------------|:---------------------------------|
  | `TSuccessToBind` | Type of expected success to bind |

- Parameters:

  | Name                 | Description                  |
  |:---------------------|:-----------------------------|
  | `createResultToBind` | Creates a new result to bind |

- Return: A new result with a different type of expected success.

***[Top](#resulttfailure-tsuccess)***

#### `Reset<TSuccessToInitialize>(initializerResult)`

- Signature:

  ```cs
  public Result<TFailure, TSuccessToInitialize> Reset<TSuccessToInitialize>(Result<TFailure, TSuccessToInitialize> initializerResult)
  ```

- Description: Resets the state of the expected success.
- Generics:

  | Name                  | Description                                       |
  |:----------------------|:--------------------------------------------------|
  | `TSuccessInitializer` | Type of expected success that acts as initializer |

- Parameters:

  | Name                | Description              |
  |:--------------------|:-------------------------|
  | `initializerResult` | A new initializer result |

- Return: A new result with a different type of expected success.

***[Top](#resulttfailure-tsuccess)***

#### `Discard()`

- Signature:

  ```cs
  public Result<TFailure, Unit> Discard()
  ```

- Description: Discards the expected success.
- Return: A new result that replaces the expected success with [`Unit`](../unit.md).

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

  | Name            | Description                         |
  |:----------------|:------------------------------------|
  | `reduceFailure` | Creates a possible reduced failure  |
  | `reduceSuccess` | Creates an expected reduced success |

- Return: A new value that can be the possible failure or the expected success.

***[Top](#resulttfailure-tsuccess)***

#### `Equals(obj)`

- Signature:

  ```cs
  public override bool Equals(object? obj)
  ```

- Description: Determines whether the specified result is equal to the current result (equality is determined by value).
- Parameters:

  | Name  | Description                            |
  |:------|:---------------------------------------|
  | `obj` | The result to compare with the current |

- Return: `true` if the specified result is equal to the current result; otherwise, `false`.

***[Top](#resulttfailure-tsuccess)***

#### `Equals(other)`

- Signature:

  ```cs
  public bool Equals(Result<TFailure, TSuccess>? other)
  ```

- Description: Determines whether the specified result is equal to the current result (equality is determined by value).
- Parameters:

  | Name    | Description                            |
  |:--------|:---------------------------------------|
  | `other` | The result to compare with the current |

- Return: `true` if the specified result is equal to the current result; otherwise, `false`.

***[Top](#resulttfailure-tsuccess)***

#### `GetHashCode()`

- Signature:

  ```cs
  public override int GetHashCode()
  ```

- Description: Gets the hash code based on the primary members of the current result.
- Return: The calculated hash code.

***[Top](#resulttfailure-tsuccess)***

### Additional resources

- [`ResultFactory`](./result-factory.md): Type intended to expose a set of ways to initialize [`Result<TFailure, TSuccess>`](#resulttfailure-tsuccess).
- [License](../../../../license.txt)
- [Security policy](../../../../security.md)
- [Code of conduct](../../../../code-of-conduct.md)
- [Contributing guidelines](../../../../contributing.md)

***[Top](#resulttfailure-tsuccess)***
