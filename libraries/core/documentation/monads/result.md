# `Result<TFailure, TSuccess>`

***[home](../../../../readme.md) / packages /  [core](../../readme.md) / monads /***

```cs
public sealed class Result<TFailure, TSuccess>
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
   - [`Catch<TException>(execute, createFailure)`](#catchtexceptionexecute-createfailure)
   - [`Catch<TException>(createSuccess, createFailure)`](#catchtexceptioncreatesuccess-createfailure)
   - [`Ensure(predicate, failure)`](#ensurepredicate-failure)
   - [`Ensure(predicate, createFailure)`](#ensurepredicate-createfailure)
   - [`Ensure<TAuxiliary>(auxiliary, predicate, createFailure)`](#ensuretauxiliaryauxiliary-predicate-createfailure)
   - [`Ensure<TAuxiliary>(createAuxiliary, predicate, createFailure)`](#ensuretauxiliarycreateauxiliary-predicate-createfailure)
   - [`DoOnFailure(execute)`](#doonfailureexecute)
   - [`DoOnSuccess(execute)`](#doonsuccessexecute)
   - [`Map<TSuccessToMap>(successToMap)`](#maptsuccesstomapsuccesstomap)
   - [`Map<TSuccessToMap>(createSuccessToMap)`](#maptsuccesstomapcreatesuccesstomap)
   - [`Bind<TSuccessToBind>(createResultToBind)`](#bindtsuccesstobindcreateresulttobind)
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

- Declaration

  ```cs
  public bool IsFailed { get; }
  ```

- Description: Indicates whether the status is failed.

***[Top](#resulttfailure-tsuccess)***

#### `Failure`

- Declaration

  ```cs
  public TFailure Failure { get; }
  ```

- Description: The possible failure.

***[Top](#resulttfailure-tsuccess)***

#### `IsSuccessful`

- Declaration

  ```cs
  public bool IsSuccessful { get; }
  ```

- Description: Indicates whether the status is successful.

***[Top](#resulttfailure-tsuccess)***

#### `Success`

- Declaration

  ```cs
  public TSuccess Success { get; }
  ```

- Description: The expected success.

***[Top](#resulttfailure-tsuccess)***

### Constructors

#### `Result(failure)`

- Declaration:

  ```cs
  public Result(TFailure failure)
  ```

- Description: Creates a new failed result.
- Parameters:
  | Name      | Description        |
  |:----------|:-------------------|
  | `failure` | A possible failure |

***[Top](#resulttfailure-tsuccess)***

#### `Result(success)`

- Declaration:

  ```cs
  public Result(TSuccess success)
  ```

- Description: Creates a new successful result.
- Parameters:
  | Name      | Description         |
  |:----------|:--------------------|
  | `success` | An expected success |

***[Top](#resulttfailure-tsuccess)***

### Equality operators

#### `==(left, right)`

- Declaration:

  ```cs
  public static bool operator ==(Result<TFailure, TSuccess>? left, Result<TFailure, TSuccess>? right)
  ```

- Description: Determines whether the left result is equal to the right result (equality is determined by value).
- Parameters:
  | Name    | Description           |
  |:--------|:----------------------|
  | `left`  | The main result       |
  | `right` | The result to compare |

***[Top](#resulttfailure-tsuccess)***

#### `!=(left, right)`

- Declaration:

  ```cs
  public static bool operator !=(Result<TFailure, TSuccess>? left, Result<TFailure, TSuccess>? right)
  ```

- Description: Determines whether the left result is not equal to the right result (equality is determined by value).
- Parameters:
  | Name    | Description           |
  |:--------|:----------------------|
  | `left`  | The main result       |
  | `right` | The result to compare |

***[Top](#resulttfailure-tsuccess)***

### Implicit operators

#### `Result<TFailure, TSuccess>(failure)`

- Declaration:

  ```cs
  public static implicit operator Result<TFailure, TSuccess>(TFailure failure)
  ```

- Description: Creates a new failed result.
- Parameters:
  | Name      | Description        |
  |:----------|:-------------------|
  | `failure` | A possible failure |

***[Top](#resulttfailure-tsuccess)***

#### `Result<TFailure, TSuccess>(success)`

- Declaration:

  ```cs
  public static implicit operator Result<TFailure, TSuccess>(TSuccess success)
  ```

- Description: Creates a new successful result.
- Parameters:
  | Name      | Description         |
  |:----------|:--------------------|
  | `success` | An expected success |

***[Top](#resulttfailure-tsuccess)***

### Methods

#### `Catch<TException>(execute, createFailure)`

- Declaration:

  ```cs
  public Result<TFailure, TSuccess> Catch<TException>(Action<TSuccess> execute, Func<TException, TFailure> createFailure)
    where TException : Exception
  ```

- Description: Creates a new failed result if `execute` throws `TException`; otherwise, returns the previous result.
- Generics:
  | Name         | Description                |
  |:-------------|:---------------------------|
  | `TException` | Type of possible exception |
- Parameters:
  | Name            | Description                |
  |:----------------|:---------------------------|
  | `execute`       | The action to execute      |
  | `createFailure` | Creates a possible failure |

***[Top](#resulttfailure-tsuccess)***

#### `Catch<TException>(createSuccess, createFailure)`

- Declaration:

  ```cs
  public Result<TFailure, TSuccess> Catch<TException>(Func<TSuccess, TSuccess> createSuccess, Func<TException, TFailure> createFailure)
    where TException : Exception
  ```

- Description: Creates a new failed result if the value of `createSuccess` throws `TException`; otherwise, creates a new
successful result.
- Generics:
  | Name         | Description                |
  |:-------------|:---------------------------|
  | `TException` | Type of possible exception |
- Parameters:
  | Name            | Description                 |
  |:----------------|:----------------------------|
  | `createSuccess` | Creates an expected success |
  | `createFailure` | Creates a possible failure  |

***[Top](#resulttfailure-tsuccess)***

#### `Ensure(predicate, failure)`

- Declaration:

  ```cs
  public Result<TFailure, TSuccess> Ensure(Func<TSuccess, bool> predicate, TFailure failure)
  ```

- Description: Creates a new failed result if the value of `predicate` is `true`; otherwise, returns the previous result.
- Parameters:
  | Name        | Description               |
  |:------------|:--------------------------|
  | `predicate` | Creates a set of criteria |
  | `failure`   | A possible failure        |

***[Top](#resulttfailure-tsuccess)***

#### `Ensure(predicate, createFailure)`

- Declaration:

  ```cs
  public Result<TFailure, TSuccess> Ensure(Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)
  ```

- Description: Creates a new failed result if the value of `predicate` is `true`; otherwise, returns the previous result.
- Parameters:
  | Name            | Description                |
  |:----------------|:---------------------------|
  | `predicate`     | Creates a set of criteria  |
  | `createFailure` | Creates a possible failure |

***[Top](#resulttfailure-tsuccess)***

#### `Ensure<TAuxiliary>(auxiliary, predicate, createFailure)`

- Declaration:

  ```cs
  public Result<TFailure, TSuccess> Ensure<TAuxiliary>(TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
  ```

- Description: Creates a new failed result if the value of `predicate` is `true`; otherwise, returns the previous result.
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

***[Top](#resulttfailure-tsuccess)***

#### `Ensure<TAuxiliary>(createAuxiliary, predicate, createFailure)`

- Declaration:

  ```cs
  public Result<TFailure, TSuccess> Ensure<TAuxiliary>(Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
  ```

- Description: Creates a new failed result if the value of `predicate` is `true`; otherwise, returns the previous result.
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

***[Top](#resulttfailure-tsuccess)***

#### `DoOnFailure(execute)`

- Declaration:

  ```cs
  public Result<TFailure, TSuccess> DoOnFailure(Action<TFailure> execute)
  ```

- Description: Executes an action if the previous result is failed.
- Parameters:
  | Name      | Description           |
  |:----------|:----------------------|
  | `execute` | The action to execute |

***[Top](#resulttfailure-tsuccess)***

#### `DoOnSuccess(execute)`

- Declaration:

  ```cs
  public Result<TFailure, TSuccess> DoOnSuccess(Action<TSuccess> execute)
  ```

- Description: Executes an action if the previous result is successful.
- Parameters:
  | Name      | Description           |
  |:----------|:----------------------|
  | `execute` | The action to execute |

***[Top](#resulttfailure-tsuccess)***

#### `Map<TSuccessToMap>(successToMap)`

- Declaration:

  ```cs
  public Result<TFailure, TSuccessToMap> Map<TSuccessToMap>(TSuccessToMap successToMap)
  ```

- Description: Creates a new result with the same or different type of expected success.
- Generics:
  | Name            | Description                     |
  |:----------------|:--------------------------------|
  | `TSuccessToMap` | Type of expected success to map |
- Parameters:
  | Name           | Description                |
  |:---------------|:---------------------------|
  | `successToMap` | An expected success to map |

***[Top](#resulttfailure-tsuccess)***

#### `Map<TSuccessToMap>(createSuccessToMap)`

- Declaration:

  ```cs
  public Result<TFailure, TSuccessToMap> Map<TSuccessToMap>(Func<TSuccess, TSuccessToMap> createSuccessToMap)
  ```

- Description: Creates a new result with the same or different type of expected success.
- Generics:
  | Name            | Description                     |
  |:----------------|:--------------------------------|
  | `TSuccessToMap` | Type of expected success to map |
- Parameters:
  | Name                 | Description                        |
  |:---------------------|:-----------------------------------|
  | `createSuccessToMap` | Creates an expected success to map |

***[Top](#resulttfailure-tsuccess)***

#### `Bind<TSuccessToBind>(createResultToBind)`

- Declaration:

  ```cs
  public Result<TFailure, TSuccessToBind> Bind<TSuccessToBind>(Func<TSuccess, Result<TFailure, TSuccessToBind>> createResultToBind)
  ```

- Description: Creates a new result in combination with another result with the same or different type of expected success.
- Generics:
  | Name             | Description                      |
  |:-----------------|:---------------------------------|
  | `TSuccessToBind` | Type of expected success to bind |
- Parameters:
  | Name                 | Description                  |
  |:---------------------|:-----------------------------|
  | `createResultToBind` | Creates a new result to bind |

***[Top](#resulttfailure-tsuccess)***

#### `Reduce<TReducer>(reduceFailure, reduceSuccess)`

- Declaration:

  ```cs
  public TReducer Reduce<TReducer>(Func<TFailure, TReducer> reduceFailure, Func<TSuccess, TReducer> reduceSuccess)
  ```

- Description: Creates a new reduced failure if the previous result is failed; otherwise, creates a new reduced success.
- Generics:
  | Name       | Description     |
  |:-----------|:----------------|
  | `TReducer` | Type of reducer |
- Parameters:
  | Name            | Description                         |
  |:----------------|:------------------------------------|
  | `reduceFailure` | Creates a possible reduced failure  |
  | `reduceSuccess` | Creates an expected reduced success |

***[Top](#resulttfailure-tsuccess)***

#### `Equals(obj)`

- Declaration:

  ```cs
  public override bool Equals(object? obj)
  ```

- Description: Determines whether the specified result is equal to the current result (equality is determined by value).
- Parameters:
  | Name  | Description                            |
  |:------|:---------------------------------------|
  | `obj` | The result to compare with the current |

***[Top](#resulttfailure-tsuccess)***

#### `Equals(other)`

- Declaration:

  ```cs
  public bool Equals(Result<TFailure, TSuccess>? other)
  ```

- Description: Determines whether the specified result is equal to the current result (equality is determined by value).
- Parameters:
  | Name    | Description                            |
  |:--------|:---------------------------------------|
  | `other` | The result to compare with the current |

***[Top](#resulttfailure-tsuccess)***

#### `GetHashCode()`

- Declaration:

  ```cs
  public override int GetHashCode()
  ```

- Description: Get the hash code based on the possible failure and the expected success.

***[Top](#resulttfailure-tsuccess)***

### Additional resources

- [`ResultFactory`](./result-factory.md): Type intended to expose a set of ways to initialize [`Result<TFailure, TSuccess>`](#resulttfailure-tsuccess).
- [License](../../../../license)
- [Security policy](../../../../security.md)
- [Code of conduct](../../../../code-of-conduct.md)
- [Contributing guidelines](../../../../contributing.md)

***[Top](#resulttfailure-tsuccess)***
