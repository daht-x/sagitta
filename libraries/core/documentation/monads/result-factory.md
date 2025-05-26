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
2. [Additional resources](#additional-resources)

### Methods

#### `Fail<TFailure, TSuccess>(failure)`

- Signature:

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

  | Name      | Description        |
  |:----------|:-------------------|
  | `failure` | A possible failure |

- Return: A new failed result.

***[Top](#resultfactory)***

#### `Fail<TFailure, TSuccess>(createFailure)`

- Signature:

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

  | Name            | Description                |
  |:----------------|:---------------------------|
  | `createFailure` | Creates a possible failure |

- Return: A new failed result.

***[Top](#resultfactory)***

#### `Succeed<TFailure, TSuccess>(success)`

- Signature:

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

  | Name      | Description         |
  |:----------|:--------------------|
  | `success` | An expected success |

- Return: A new successful result.

***[Top](#resultfactory)***

#### `Succeed<TFailure, TSuccess>(createSuccess)`

- Signature:

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

  | Name            | Description                 |
  |:----------------|:----------------------------|
  | `createSuccess` | Creates an expected success |

- Return: A new successful result.

***[Top](#resultfactory)***

#### `Catch<TException, TFailure, TSuccess>(createSuccess, createFailure)`

- Signature:

  ```cs
  public static Result<TFailure, TSuccess> Catch<TException, TFailure, TSuccess>(Func<TSuccess> createSuccess, Func<TException, TFailure> createFailure)
    where TException : Exception
  ```

- Description: Treats `TException` as a new failed result.
- Generics:

  | Name         | Description                |
  |:-------------|:---------------------------|
  | `TException` | Type of possible exception |
  | `TFailure`   | Type of possible failure   |
  | `TSuccess`   | Type of expected success   |

- Parameters:

  | Name            | Description                 |
  |:----------------|:----------------------------|
  | `createSuccess` | Creates an expected success |
  | `createFailure` | Creates a possible failure  |

- Return: A new failed result if the value of `createSuccess` throws `TException`; otherwise, a new successful result.

***[Top](#resultfactory)***

### Additional resources

- [`Result<TFailure, TSuccess>`](./result.md): Type intended to handle both the possible failure and the expected success
of a given action.
- [License](../../../../license.txt)
- [Security policy](../../../../security.md)
- [Code of conduct](../../../../code-of-conduct.md)
- [Contributing guidelines](../../../../contributing.md)

***[Top](#resultfactory)***
