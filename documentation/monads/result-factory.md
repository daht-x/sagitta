# `static class ResultFactory`

***[home](../../readme.md) / monads /***

Type that exposes a set of ways to initialize [`Result<TSuccess, TFailure>`](./result.md).

## Table of contents

1. [Methods](#methods)
   - [`Catch`](#catch)
   - [`Ensure`](#ensure)
   - [`Succeed`](#succeed)
   - [`Fail`](#fail)
2. [Additional resources](#additional-resources)

### Methods

#### `Catch`

Creates a new failed result if the value of `createSuccess` throws `TException`; otherwise, creates a new successful result.

- `Catch<TException, TSuccess, TFailure>(Func<TSuccess> createSuccess, Func<TException, TFailure> createFailure)`:

  | Generic      | Description                |
  |:-------------|:---------------------------|
  | `TException` | Type of possible exception |
  | `TSuccess`   | Type of expected success   |
  | `TFailure`   | Type of possible failure   |

  | Parameter       | Description                  |
  |:----------------|:-----------------------------|
  | `createSuccess` | Creates the expected success |
  | `createFailure` | Creates the possible failure |

***[Top](#static-class-resultfactory)***

[bool]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool

#### `Ensure`

Creates a new failed result if the value of `predicate` is [true][bool]; otherwise, creates a new successful result.

| Generic    | Description              |
|:-----------|:-------------------------|
| `TSuccess` | Type of expected success |
| `TFailure` | Type of possible failure |

- `Ensure<TSuccess, TFailure>(TSuccess success, Func<TSuccess, bool> predicate, TFailure failure)`:

  | Parameter   | Description               |
  |:------------|:--------------------------|
  | `success`   | The expected success      |
  | `predicate` | Creates a set of criteria |
  | `failure`   | The possible failure      |

- `Ensure<TSuccess, TFailure>(TSuccess success, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)`:

  | Parameter       | Description                  |
  |:----------------|:-----------------------------|
  | `success`       | The expected success         |
  | `predicate`     | Creates a set of criteria    |
  | `createFailure` | Creates the possible failure |

- `Ensure<TSuccess, TFailure>(Func<TSuccess> createSuccess, Func<TSuccess, bool> predicate, TFailure failure)`:

  | Parameter       | Description                  |
  |:----------------|:-----------------------------|
  | `createSuccess` | Creates the expected success |
  | `predicate`     | Creates a set of criteria    |
  | `failure`       | The possible failure         |

- `Ensure<TSuccess, TFailure>(Func<TSuccess> createSuccess, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)`:

  | Parameter       | Description                  |
  |:----------------|:-----------------------------|
  | `createSuccess` | Creates the expected success |
  | `predicate`     | Creates a set of criteria    |
  | `createFailure` | Creates the possible failure |

- `Ensure<TAuxiliary, TSuccess, TFailure>(TSuccess success, TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)`:

  | Generic      | Description       |
  |:-------------|:------------------|
  | `TAuxiliary` | Type of auxiliary |

  | Parameter       | Description                                                              |
  |:----------------|:-------------------------------------------------------------------------|
  | `success`       | The expected success                                                     |
  | `auxiliary`     | The auxiliary to use in combination with `predicate` and `createFailure` |
  | `predicate`     | Creates a set of criteria                                                |
  | `createFailure` | Creates the possible failure                                             |

- `Ensure<TAuxiliary, TSuccess, TFailure>(TSuccess success, Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)`:

  | Generic      | Description       |
  |:-------------|:------------------|
  | `TAuxiliary` | Type of auxiliary |

  | Parameter         | Description                                                                      |
  |:------------------|:---------------------------------------------------------------------------------|
  | `success`         | The expected success                                                             |
  | `createAuxiliary` | Creates the auxiliary to use in combination with `predicate` and `createFailure` |
  | `predicate`       | Creates a set of criteria                                                        |
  | `createFailure`   | Creates the possible failure                                                     |

- `Ensure<TAuxiliary, TSuccess, TFailure>(Func<TSuccess> createSuccess, TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)`:

  | Generic      | Description       |
  |:-------------|:------------------|
  | `TAuxiliary` | Type of auxiliary |

  | Parameter       | Description                                                              |
  |:----------------|:-------------------------------------------------------------------------|
  | `createSuccess` | Creates the expected success                                             |
  | `auxiliary`     | The auxiliary to use in combination with `predicate` and `createFailure` |
  | `predicate`     | Creates a set of criteria                                                |
  | `createFailure` | Creates the possible failure                                             |

- `Ensure<TAuxiliary, TSuccess, TFailure>(Func<TSuccess> createSuccess, Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)`:

  | Generic      | Description       |
  |:-------------|:------------------|
  | `TAuxiliary` | Type of auxiliary |

  | Parameter         | Description                                                                      |
  |:------------------|:---------------------------------------------------------------------------------|
  | `createSuccess`   | Creates the expected success                                                     |
  | `createAuxiliary` | Creates the auxiliary to use in combination with `predicate` and `createFailure` |
  | `predicate`       | Creates a set of criteria                                                        |
  | `createFailure`   | Creates the possible failure                                                     |

***[Top](#static-class-resultfactory)***

#### `Succeed`

Creates a new successful result.

| Generic    | Description              |
|:-----------|:-------------------------|
| `TSuccess` | Type of expected success |
| `TFailure` | Type of possible failure |

- `Succeed<TSuccess, TFailure>(TSuccess success)`:

  | Parameter | Description          |
  |:----------|:---------------------|
  | `success` | The expected success |

- `Succeed<TSuccess, TFailure>(Func<TSuccess> createSuccess)`:

  | Parameter       | Description                  |
  |:----------------|:-----------------------------|
  | `createSuccess` | Creates the expected success |

***[Top](#static-class-resultfactory)***

#### `Fail`

Creates a new failed result.

| Generic    | Description              |
|:-----------|:-------------------------|
| `TSuccess` | Type of expected success |
| `TFailure` | Type of possible failure |

- `Fail<TSuccess, TFailure>(TFailure failure)`:

  | Parameter | Description          |
  |:----------|:---------------------|
  | `failure` | The possible failure |

- `Fail<TSuccess, TFailure>(Func<TFailure> createFailure)`:

  | Parameter       | Description                  |
  |:----------------|:-----------------------------|
  | `createFailure` | Creates the possible failure |

***[Top](#static-class-resultfactory)***

### Additional resources

- [`Result<TSuccess, TFailure>`](./result.md): Type that encapsulates both the expected success and the possible failure of a given action.
- [License](../../license).
- [Security policy](../../security.md).
- [Code of conduct](../../code-of-conduct.md).
- [Contributing guidelines](../../contributing.md).

***[Top](#static-class-resultfactory)***
