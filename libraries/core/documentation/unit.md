# `Unit`

[bool]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool

***[home](../../../readme.md) / packages /  [core](../readme.md) /***

```cs
public readonly struct Unit : IEquatable<Unit>
 ```

Represents the absence of a specific value, explicitly simulating the [`void`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/void)
type.

## Table of contents

1. [Properties](#properties)
   - [`Default`](#default)
2. [Operators](#operators)
   - [`Equality operator ==`](#equality-operator-)
   - [`Inequality operator !=`](#inequality-operator-)
3. [Methods](#methods)
   - [`Equals(obj)`](#equalsobj)
   - [`Equals(other)`](#equalsother)
   - [`GetHashCode`](#gethashcode)
   - [`ToString`](#tostring)
4. [See also](#see-also)
5. [Additional resources](#additional-resources)

---

### Properties

#### `Default`

- Signature

  ```cs
  public static Unit Default { get; }
  ```

- Description: The placeholder that indicates the discarding of a value.

***[Top](#unit)***

---

### Operators

#### Equality operator ==

- Signature:

  ```cs
  public static bool operator ==(Unit left, Unit right)
  ```

- Description: Determines whether the left unit is equal to the right unit.
- Parameters:

  | Name    | Description          |
  |:--------|:---------------------|
  | `left`  | The main unit.       |
  | `right` | The unit to compare. |

- Return: [`true`][bool] if the left unit is equal to the right unit; otherwise, [`false`][bool].

***[Top](#unit)***

#### Inequality operator !=

  ```cs
  public static bool operator !=(Unit left, Unit right)
  ```

- Description: Determines whether the left unit is not equal to the right unit.
- Parameters:

  | Name    | Description          |
  |:--------|:---------------------|
  | `left`  | The main unit.       |
  | `right` | The unit to compare. |

- Return: [`true`][bool] if the left unit is not equal to the right unit; otherwise, [`false`][bool].

***[Top](#unit)***

---

### Methods

#### `Equals(obj)`

- Signature:

  ```cs
  public override bool Equals(object? obj)
  ```

- Description: Determines whether the specified unit is equal to the current unit.
- Parameters:

  | Name  | Description                                    |
  |:------|:-----------------------------------------------|
  | `obj` | The unit to compare with the current reference |

- Returns: [`true`][bool] if the specified unit is equal to the current unit; otherwise, [`false`][bool].

***[Top](#unit)***

#### `Equals(other)`

- Signature:

  ```cs
  public bool Equals(Unit other)
  ```

- Description: Determines whether the specified unit is equal to the current unit.
- Parameters:

  | Name    | Description                                    |
  |:--------|:-----------------------------------------------|
  | `other` | The unit to compare with the current reference |

- Returns: [`true`][bool] if the specified unit is equal to the current unit; otherwise, [`false`][bool].

***[Top](#unit)***

#### `GetHashCode`

- Signature:

  ```cs
  public override int GetHashCode()
  ```

- Description: Gets the hash code of the current unit.
- Returns: The hash code of the current unit.

***[Top](#unit)***

#### `ToString`

- Signature:

  ```cs
  public override string ToString()
  ```

- Description: Gets the value of the current unit.
- Returns: The value of the current unit.

***[Top](#unit)***

---

### See also

- [Result<TFailure, TSuccess>](./monads/result.md)
- [ResultFactory](./monads/result-factory.md)
- [ValueResult<TFailure, TSuccess>](./monads/value-result.md)
- [ValueResultFactory](./monads/value-result-factory.md)

***[Top](#unit)***

---

### Additional resources

- [License](../../../license.txt)
- [Security policy](../../../security.md)
- [Code of conduct](../../../code-of-conduct.md)
- [Contributing guidelines](../../../contributing.md)

***[Top](#unit)***
