# `sealed class Result<TSuccess, TFailure>`

***[home](../../readme.md) / monads /***

Type that encapsulates both the expected success and the possible failure of a given action.

| Generic    | Description              |
|:-----------|:-------------------------|
| `TSuccess` | Type of expected success |
| `TFailure` | Type of possible failure |

## Table of contents

1. [Constructors](#constructors)
2. [Properties](#properties)
3. [Implicit operators](#implicit-operators)
4. [Methods](#methods)
   - [`Ensure`](#ensure)
   - [`Map`](#map)
   - [`Bind`](#bind)
   - [`Reduce`](#reduce)
5. [Additional resources](#additional-resources)

### Constructors

- `Result(TSuccess success)`:

  Creates a new successful result.

  | Parameter | Description          |
  |:----------|:---------------------|
  | `success` | The expected success |

- `Result(TFailure failure)`:

  Creates a new failed result.

  | Parameter | Description          |
  |:----------|:---------------------|
  | `failure` | The possible failure |

***[Top](#sealed-class-resulttsuccess-tfailure)***

[bool]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool

### Properties

| Member         | Type           | Description                                |
|:---------------|:---------------|:-------------------------------------------|
| `IsSuccessful` | [`bool`][bool] | Indicates whether the status is successful |
| `Success`      | `TSuccess`     | The expected success                       |
| `IsFailed`     | [`bool`][bool] | Indicates whether the status is failed     |
| `Failure`      | `TFailure`     | The possible failure                       |

***[Top](#sealed-class-resulttsuccess-tfailure)***

### Implicit operators

- `Result<TSuccess, TFailure>(TSuccess success)`:

  Creates a new successful result.

  | Parameter | Description          |
  |:----------|:---------------------|
  | `success` | The expected success |

- `Result<TSuccess, TFailure>(TFailure failure)`:

  Creates a new failed result.

  | Parameter | Description          |
  |:----------|:---------------------|
  | `failure` | The possible failure |

***[Top](#sealed-class-resulttsuccess-tfailure)***

### Methods

#### `Ensure`

Creates a new failed result if the value of `predicate` is [`true`][bool]; otherwise, returns the previous result.

- `Ensure(Func<TSuccess, bool> predicate, TFailure failure)`:

  | Parameter   | Description               |
  |:------------|:--------------------------|
  | `predicate` | Creates a set of criteria |
  | `failure`   | The possible failure      |

  Returns `Result<TSuccess, TFailure>`.

- `Ensure(Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)`:

  | Parameter       | Description                  |
  |:----------------|:-----------------------------|
  | `predicate`     | Creates a set of criteria    |
  | `createFailure` | Creates the possible failure |

  Returns `Result<TSuccess, TFailure>`.

- `Ensure<TAuxiliary>(TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)`:

  | Generic      | Description       |
  |:-------------|:------------------|
  | `TAuxiliary` | Type of auxiliary |

  | Parameter       | Description                                                              |
  |:----------------|:-------------------------------------------------------------------------|
  | `auxiliary`     | The auxiliary to use in combination with `predicate` and `createFailure` |
  | `predicate`     | Creates a set of criteria                                                |
  | `createFailure` | Creates the possible failure                                             |

  Returns `Result<TSuccess, TFailure>`.

- `Ensure<TAuxiliary>(Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)`:

  | Generic      | Description       |
  |:-------------|:------------------|
  | `TAuxiliary` | Type of auxiliary |

  | Parameter         | Description                                                                      |
  |:------------------|:---------------------------------------------------------------------------------|
  | `createAuxiliary` | Creates the auxiliary to use in combination with `predicate` and `createFailure` |
  | `predicate`       | Creates a set of criteria                                                        |
  | `createFailure`   | Creates the possible failure                                                     |

  Returns `Result<TSuccess, TFailure>`.

***[Top](#sealed-class-resulttsuccess-tfailure)***

#### `Map`

Creates a new result with the same or different type of expected success.

| Generic         | Description                     |
|:----------------|:--------------------------------|
| `TSuccessToMap` | Type of expected success to map |

- `Map<TSuccessToMap>(TSuccessToMap successToMap)`:

  | Parameter      | Description                 |
  |:---------------|:----------------------------|
  | `successToMap` | The expected success to map |

  Returns `Result<TSuccessToMap, TFailure>`.

- `Map<TSuccessToMap>(Func<TSuccess, TSuccessToMap> createSuccessToMap)`:

  | Parameter            | Description                         |
  |:---------------------|:------------------------------------|
  | `createSuccessToMap` | Creates the expected success to map |

  Returns `Result<TSuccessToMap, TFailure>`.

***[Top](#sealed-class-resulttsuccess-tfailure)***

#### `Bind`

Creates a new result in combination with another result with the same or different type of expected success.

| Generic          | Description                      |
|:-----------------|:---------------------------------|
| `TSuccessToBind` | Type of expected success to bind |

- `Bind<TSuccessToBind>(Func<TSuccess, Result<TSuccessToBind, TFailure>> createResultToBind)`:

  | Parameter            | Description                  |
  |:---------------------|:-----------------------------|
  | `createResultToBind` | Creates a new result to bind |

  Returns `Result<TSuccessToBind, TFailure>`.

***[Top](#sealed-class-resulttsuccess-tfailure)***

#### `Reduce`

Creates a new reduced failure if the result is failed; otherwise, creates a new reduced success.

| Generic    | Description     |
|:-----------|:----------------|
| `TReducer` | Type of reducer |

- `Reduce<TReducer>(Func<TSuccess, TReducer> createReducedSuccess, Func<TFailure, TReducer> createReducedFailure)`:

  | Parameter              | Description                          |
  |:-----------------------|:-------------------------------------|
  | `createReducedSuccess` | Creates the expected reduced success |
  | `createReducedFailure` | Creates the possible reduced failure |

  Returns `TReducer`.

***[Top](#sealed-class-resulttsuccess-tfailure)***

### Additional resources

- [`ResultFactory`](./result-factory.md): Type that exposes a set of ways to initialize `Result<TSuccess, TFailure>`.
- [License](../../license).
- [Security policy](../../security.md).
- [Code of conduct](../../code-of-conduct.md).
- [Contributing guidelines](../../contributing.md).

***[Top](#sealed-class-resulttsuccess-tfailure)***
