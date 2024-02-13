# `ResultFactory`

***[home](../../../../readme.md) / packages /  [core](../../readme.md) / monads /***

```cs
public static class ResultFactory
 ```

Type intended to expose a set of ways to initialize [`Result<TFailure, TSuccess>`](./result.md).

## Table of contents

1. [Methods](#methods)
   - [`Fail<TFailure, TSuccess>(failure)`](#failtfailure-tsuccessfailure)
   - [`Fail<TFailure, TSuccess>(createFailure)`](#failtfailure-tsuccesscreatefailure)
   - [`Succeed<TFailure, TSuccess>(success)`](#succeedtfailure-tsuccesssuccess)
   - [`Succeed<TFailure, TSuccess>(createSuccess)`](#succeedtfailure-tsuccesscreatesuccess)
   - [`Catch<TException, TFailure, TSuccess>(createSuccess, createFailure)`](#catchtexception-tfailure-tsuccesscreatesuccess-createfailure)
   - [`Ensure<TFailure, TSuccess>(success, predicate, failure)`](#ensuretfailure-tsuccesssuccess-predicate-failure)
   - [`Ensure<TFailure, TSuccess>(success, predicate, createFailure)`](#ensuretfailure-tsuccesssuccess-predicate-createfailure)
   - [`Ensure<TFailure, TSuccess>(createSuccess, predicate, failure)`](#ensuretfailure-tsuccesscreatesuccess-predicate-failure)
   - [`Ensure<TFailure, TSuccess>(createSuccess, predicate, createFailure)`](#ensuretfailure-tsuccesscreatesuccess-predicate-createfailure)
   - [`Ensure<TAuxiliary, TFailure, TSuccess>(success, auxiliary, predicate, createFailure)`](#ensuretauxiliary-tfailure-tsuccesssuccess-auxiliary-predicate-createfailure)
   - [`Ensure<TAuxiliary, TFailure, TSuccess>(success, createAuxiliary, predicate, createFailure)`](#ensuretauxiliary-tfailure-tsuccesssuccess-createauxiliary-predicate-createfailure)
   - [`Ensure<TAuxiliary, TFailure, TSuccess>(createSuccess, auxiliary, predicate, createFailure)`](#ensuretauxiliary-tfailure-tsuccesscreatesuccess-auxiliary-predicate-createfailure)
   - [`Ensure<TAuxiliary, TFailure, TSuccess>(createSuccess, createAuxiliary, predicate, createFailure)`](#ensuretauxiliary-tfailure-tsuccesscreatesuccess-createauxiliary-predicate-createfailure)
2. [Additional resources](#additional-resources)

### Methods

#### `Fail<TFailure, TSuccess>(failure)`

- Declaration:

  ```cs
  public static Result<TFailure, TSuccess> Fail<TFailure, TSuccess>(TFailure failure)
  ```

- Description: Creates a new failed result.
- Generics:
  | Name       | Description              |
  |:-----------|:-------------------------|
  | `TFailure` | Type of possible failure |
  | `TSuccess` | Type of expected success |
- Parameters:
  | Name      | Description          |
  |:----------|:---------------------|
  | `failure` | The possible failure |

***[Top](#resultfactory)***

#### `Fail<TFailure, TSuccess>(createFailure)`

- Declaration:

  ```cs
  public static Result<TFailure, TSuccess> Fail<TFailure, TSuccess>(Func<TFailure> createFailure)
  ```

- Description: Creates a new failed result.
- Generics:
  | Name       | Description              |
  |:-----------|:-------------------------|
  | `TFailure` | Type of possible failure |
  | `TSuccess` | Type of expected success |
- Parameters:
  | Name            | Description                  |
  |:----------------|:-----------------------------|
  | `createFailure` | Creates the possible failure |

***[Top](#resultfactory)***

#### `Succeed<TFailure, TSuccess>(success)`

- Declaration:

  ```cs
  public static Result<TFailure, TSuccess> Succeed<TFailure, TSuccess>(TSuccess success)
  ```

- Description: Creates a new successful result.
- Generics:
  | Name       | Description              |
  |:-----------|:-------------------------|
  | `TFailure` | Type of possible failure |
  | `TSuccess` | Type of expected success |
- Parameters:
  | Name      | Description          |
  |:----------|:---------------------|
  | `success` | The expected success |

***[Top](#resultfactory)***

#### `Succeed<TFailure, TSuccess>(createSuccess)`

- Declaration:

  ```cs
  public static Result<TFailure, TSuccess> Succeed<TFailure, TSuccess>(Func<TSuccess> createSuccess)
  ```

- Description: Creates a new successful result.
- Generics:
  | Name       | Description              |
  |:-----------|:-------------------------|
  | `TFailure` | Type of possible failure |
  | `TSuccess` | Type of expected success |
- Parameters:
  | Name            | Description                  |
  |:----------------|:-----------------------------|
  | `createSuccess` | Creates the expected success |

***[Top](#resultfactory)***

#### `Catch<TException, TFailure, TSuccess>(createSuccess, createFailure)`

- Declaration:

  ```cs
  public static Result<TFailure, TSuccess> Catch<TException, TFailure, TSuccess>(Func<TSuccess> createSuccess, Func<TException, TFailure> createFailure)
    where TException : Exception
  ```

- Description: Creates a new failed result if the value of `createSuccess` throws `TException`; otherwise, creates a new successful result.
- Generics:
  | Name         | Description                |
  |:-------------|:---------------------------|
  | `TException` | Type of possible exception |
  | `TFailure`   | Type of possible failure   |
  | `TSuccess`   | Type of expected success   |
- Parameters:
  | Name            | Description                  |
  |:----------------|:-----------------------------|
  | `createSuccess` | Creates the expected success |
  | `createFailure` | Creates the possible failure |

***[Top](#resultfactory)***

#### `Ensure<TFailure, TSuccess>(success, predicate, failure)`

- Declaration:

  ```cs
  public static Result<TFailure, TSuccess> Ensure<TFailure, TSuccess>(TSuccess success, Func<TSuccess, bool> predicate, TFailure failure)
  ```

- Description: Creates a new failed result if the value of `predicate` is `true`; otherwise, creates a new successful result.
- Generics:
  | Name       | Description              |
  |:-----------|:-------------------------|
  | `TFailure` | Type of possible failure |
  | `TSuccess` | Type of expected success |
- Parameters:
  | Name        | Description               |
  |:------------|:--------------------------|
  | `success`   | The expected success      |
  | `predicate` | Creates a set of criteria |
  | `failure`   | The possible failure      |

***[Top](#resultfactory)***

#### `Ensure<TFailure, TSuccess>(success, predicate, createFailure)`

- Declaration:

  ```cs
  public static Result<TFailure, TSuccess> Ensure<TFailure, TSuccess>(TSuccess success, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)
  ```

- Description: Creates a new failed result if the value of `predicate` is `true`; otherwise, creates a new successful result.
- Generics:
  | Name       | Description              |
  |:-----------|:-------------------------|
  | `TFailure` | Type of possible failure |
  | `TSuccess` | Type of expected success |
- Parameters:
  | Name            | Description                  |
  |:----------------|:-----------------------------|
  | `success`       | The expected success         |
  | `predicate`     | Creates a set of criteria    |
  | `createFailure` | Creates the possible failure |

***[Top](#resultfactory)***

#### `Ensure<TFailure, TSuccess>(createSuccess, predicate, failure)`

- Declaration:

  ```cs
  public static Result<TFailure, TSuccess> Ensure<TFailure, TSuccess>(Func<TSuccess> createSuccess, Func<TSuccess, bool> predicate, TFailure failure)
  ```

- Description: Creates a new failed result if the value of `predicate` is `true`; otherwise, creates a new successful result.
- Generics:
  | Name       | Description              |
  |:-----------|:-------------------------|
  | `TFailure` | Type of possible failure |
  | `TSuccess` | Type of expected success |
- Parameters:
  | Name            | Description                  |
  |:----------------|:-----------------------------|
  | `createSuccess` | Creates the expected success |
  | `predicate`     | Creates a set of criteria    |
  | `failure`       | The possible failure         |

***[Top](#resultfactory)***

#### `Ensure<TFailure, TSuccess>(createSuccess, predicate, createFailure)`

- Declaration:

  ```cs
  public static Result<TFailure, TSuccess> Ensure<TFailure, TSuccess>(Func<TSuccess> createSuccess, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)
  ```

- Description: Creates a new failed result if the value of `predicate` is `true`; otherwise, creates a new successful result.
- Generics:
  | Name       | Description              |
  |:-----------|:-------------------------|
  | `TFailure` | Type of possible failure |
  | `TSuccess` | Type of expected success |
- Parameters:
  | Name            | Description                  |
  |:----------------|:-----------------------------|
  | `createSuccess` | Creates the expected success |
  | `predicate`     | Creates a set of criteria    |
  | `createFailure` | Creates the possible failure |

***[Top](#resultfactory)***

#### `Ensure<TAuxiliary, TFailure, TSuccess>(success, auxiliary, predicate, createFailure)`

- Declaration:

  ```cs
  public static Result<TFailure, TSuccess> Ensure<TAuxiliary, TFailure, TSuccess>(TSuccess success, TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
  ```

- Description: Creates a new failed result if the value of `predicate` is `true`; otherwise, creates a new successful result.
- Generics:
  | Name         | Description              |
  |:-------------|:-------------------------|
  | `TAuxiliary` | Type of auxiliary        |
  | `TFailure`   | Type of possible failure |
  | `TSuccess`   | Type of expected success |
- Parameters:
  | Name            | Description                                                              |
  |:----------------|:-------------------------------------------------------------------------|
  | `success`       | The expected success                                                     |
  | `auxiliary`     | The auxiliary to use in combination with `predicate` and `createFailure` |
  | `predicate`     | Creates a set of criteria                                                |
  | `createFailure` | Creates the possible failure                                             |

***[Top](#resultfactory)***

#### `Ensure<TAuxiliary, TFailure, TSuccess>(success, createAuxiliary, predicate, createFailure)`

- Declaration:

  ```cs
  public static Result<TFailure, TSuccess> Ensure<TAuxiliary, TFailure, TSuccess>(TSuccess success, Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
  ```

- Description: Creates a new failed result if the value of `predicate` is `true`; otherwise, creates a new successful result.
- Generics:
  | Name         | Description              |
  |:-------------|:-------------------------|
  | `TAuxiliary` | Type of auxiliary        |
  | `TFailure`   | Type of possible failure |
  | `TSuccess`   | Type of expected success |
- Parameters:
  | Name              | Description                                                                      |
  |:------------------|:---------------------------------------------------------------------------------|
  | `success`         | The expected success                                                             |
  | `createAuxiliary` | Creates the auxiliary to use in combination with `predicate` and `createFailure` |
  | `predicate`       | Creates a set of criteria                                                        |
  | `createFailure`   | Creates the possible failure                                                     |

***[Top](#resultfactory)***

#### `Ensure<TAuxiliary, TFailure, TSuccess>(createSuccess, auxiliary, predicate, createFailure)`

- Declaration:

  ```cs
  public static Result<TFailure, TSuccess> Ensure<TAuxiliary, TFailure, TSuccess>(Func<TSuccess> createSuccess, TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
  ```

- Description: Creates a new failed result if the value of `predicate` is `true`; otherwise, creates a new successful result.
- Generics:
  | Name         | Description              |
  |:-------------|:-------------------------|
  | `TAuxiliary` | Type of auxiliary        |
  | `TFailure`   | Type of possible failure |
  | `TSuccess`   | Type of expected success |
- Parameters:
  | Name            | Description                                                              |
  |:----------------|:-------------------------------------------------------------------------|
  | `createSuccess` | Creates the expected success                                             |
  | `auxiliary`     | The auxiliary to use in combination with `predicate` and `createFailure` |
  | `predicate`     | Creates a set of criteria                                                |
  | `createFailure` | Creates the possible failure                                             |

***[Top](#resultfactory)***

#### `Ensure<TAuxiliary, TFailure, TSuccess>(createSuccess, createAuxiliary, predicate, createFailure)`

- Declaration:

  ```cs
  public static Result<TFailure, TSuccess> Ensure<TAuxiliary, TFailure, TSuccess>(Func<TSuccess> createSuccess, Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
  ```

- Description: Creates a new failed result if the value of `predicate` is `true`; otherwise, creates a new successful result.
- Generics:
  | Name         | Description              |
  |:-------------|:-------------------------|
  | `TAuxiliary` | Type of auxiliary        |
  | `TFailure`   | Type of possible failure |
  | `TSuccess`   | Type of expected success |
- Parameters:
  | Name              | Description                                                                      |
  |:------------------|:---------------------------------------------------------------------------------|
  | `createSuccess`   | Creates the expected success                                                     |
  | `createAuxiliary` | Creates the auxiliary to use in combination with `predicate` and `createFailure` |
  | `predicate`       | Creates a set of criteria                                                        |
  | `createFailure`   | Creates the possible failure                                                     |

***[Top](#resultfactory)***

### Additional resources

- [`Result<TFailure, TSuccess>`](./result.md): Type intended to handle both the possible failure and the expected success of a given action.
- [License](../../../../license)
- [Security policy](../../../../security.md)
- [Code of conduct](../../../../code-of-conduct.md)
- [Contributing guidelines](../../../../contributing.md)

***[Top](#resultfactory)***
