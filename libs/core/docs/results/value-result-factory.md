# `ValueResultFactory`

***[home](../../../../readme.md) / packages /  [core](../../readme.md) / results /***

```cs
public static class ValueResultFactory
 ```

Provide global factory methods to initialize [`ValueResult<TFailure, TSuccess>`](./value-result.md).

## Table of contents

1. [Methods](#methods)
   - [`Fail<TFailure, TSuccess>(failure)`](#failtfailure-tsuccessfailure)
   - [`Succeed<TFailure, TSuccess>(success)`](#succeedtfailure-tsuccesssuccess)
2. [See also](#see-also)
3. [Additional resources](#additional-resources)

---

### Methods

#### `Fail<TFailure, TSuccess>(failure)`

- Signature:

  ```cs
  public static ValueResult<TFailure, TSuccess> Fail<TFailure, TSuccess>(TFailure failure)
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

- Returns: A new failed result.

***[Top](#valueresultfactory)***

#### `Succeed<TFailure, TSuccess>(success)`

- Signature:

  ```cs
  public static ValueResult<TFailure, TSuccess> Succeed<TFailure, TSuccess>(TSuccess success)
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

- Returns: A new successful result.

***[Top](#valueresultfactory)***

---

### See also

- [Unit](../unit.md)
- [Result<TFailure, TSuccess>](./result.md)
- [ResultFactory](./result-factory.md)
- [ValueResult<TFailure, TSuccess>](./value-result.md)

***[Top](#valueresultfactory)***

---

### Additional resources

- [License](../../../../license.txt)
- [Security policy](../../../../security.md)
- [Code of conduct](../../../../code-of-conduct.md)
- [Contributing guidelines](../../../../contributing.md)

***[Top](#valueresultfactory)***
