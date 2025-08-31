# `ValueResult<TFailure, TSuccess>`

[default]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/default
[invalid-operation-exception]: https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception
[bool]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool

***[home](../../../../readme.md) / packages /  [core](../../readme.md) / results /***

```cs
public readonly struct ValueResult<TFailure, TSuccess> : IEquatable<ValueResult<TFailure, TSuccess>>
  where TFailure : struct, Enum
  where TSuccess : struct
 ```

- Description: Encapsulates both a possible failure and an expected success for a given action.
- Remarks: Type intended to handle only value types.

## Table of contents

1. [Generics](#generics)
   - [`TFailure`](#tfailure)
   - [`TSuccess`](#tsuccess)
2. [Properties](#properties)
   - [`IsInitialized`](#isinitialized)
   - [`IsFailed`](#isfailed)
   - [`Failure`](#failure)
   - [`Success`](#success)
3. [Constructors](#constructors)
    - [`ValueResult(failure)`](#valueresultfailure)
    - [`ValueResult(success)`](#valueresultsuccess)
4. [Operators](#operators)
    - [`Equality operator ==`](#equality-operator-)
    - [`Inequality operator !=`](#inequality-operator-)
5. [Implicit operators](#implicit-operators)
   - [`TFailure(result)`](#tfailureresult)
   - [`TSuccess(result)`](#tsuccessresult)
   - [`ValueResult<TFailure, TSuccess>(failure)`](#valueresulttfailure-tsuccessfailure)
   - [`ValueResult<TFailure, TSuccess>(success)`](#valueresulttfailure-tsuccesssuccess)
6. [Methods](#methods)
   - [`Deconstruct(isFailed, failure, success)`](#deconstructisfailed-failure-success)
   - [`TryGetFailure(output)`](#trygetfailureoutput)
   - [`TryGetSuccess(output)`](#trygetsuccessoutput)
   - [`Discard`](#discard)
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

***[Top](#valueresulttfailure-tsuccess)***

#### `TSuccess`

Type of expected success.

***[Top](#valueresulttfailure-tsuccess)***

---

### Properties

#### `IsInitialized`

- Signature

  ```cs
  public bool IsInitialized { get; }
  ```

- Description: Indicates whether the current result is initialized.

***[Top](#valueresulttfailure-tsuccess)***

#### `IsFailed`

- Signature

  ```cs
  public bool IsFailed { get; }
  ```

- Description: Indicates whether the state is failed.
- Remarks: Access to this state is only semantically valid when [`IsInitialized`](#isinitialized) is [`true`][bool].

***[Top](#valueresulttfailure-tsuccess)***

#### `Failure`

- Signature

  ```cs
  public TFailure Failure { get; }
  ```

- Description: The possible failure.
- Remarks: If the result is [`default`][default] (uninitialized) or not failed, accessing [`Failure`](#failure)
throws an [`InvalidOperationException`][invalid-operation-exception].

***[Top](#valueresulttfailure-tsuccess)***

#### `Success`

- Signature

  ```cs
  public TSuccess Success { get; }
  ```

- Description: The expected success.
- Remarks: If the result is [`default`][default] (uninitialized) or not successful, accessing [`Success`](#success)
throws an [`InvalidOperationException`][invalid-operation-exception].

***[Top](#valueresulttfailure-tsuccess)***

---

### Constructors

#### `ValueResult(failure)`

- Signature:

  ```cs
  public ValueResult(TFailure failure)
  ```

- Description: Creates a new failed result.
- Parameters:

  | Name      | Description          |
  |:----------|:---------------------|
  | `failure` | The possible failure |

- Returns: A new failed result.

***[Top](#valueresulttfailure-tsuccess)***

#### `ValueResult(success)`

- Signature:

  ```cs
  public ValueResult(TSuccess success)
  ```

- Description: Creates a new successful result.
- Parameters:

  | Name      | Description          |
  |:----------|:---------------------|
  | `success` | The expected success |

- Returns: A new successful result.

***[Top](#valueresulttfailure-tsuccess)***

---

### Operators

#### `Equality operator ==`

- Signature:

  ```cs
  public static bool operator ==(ValueResult<TFailure, TSuccess> left, ValueResult<TFailure, TSuccess> right)
  ```

- Description: Determines whether the left result is equal to the right result.
- Parameters:

  | Name    | Description           |
  |:--------|:----------------------|
  | `left`  | The main result       |
  | `right` | The result to compare |

- Returns: [`true`][bool] if the left result is equal to the right result; otherwise, [`false`][bool].

***[Top](#valueresulttfailure-tsuccess)***

#### `Inequality operator !=`

- Signature:

  ```cs
  public static bool operator !=(ValueResult<TFailure, TSuccess> left, ValueResult<TFailure, TSuccess> right)
  ```

- Description: Determines whether the left result is not equal to the right result.
- Parameters:

  | Name    | Description           |
  |:--------|:----------------------|
  | `left`  | The main result       |
  | `right` | The result to compare |

- Returns: [`true`][bool] if the left result is not equal to the right result; otherwise, [`false`][bool].

***[Top](#valueresulttfailure-tsuccess)***

---

### Implicit operators

#### `TFailure(result)`

- Signature:

  ```cs
  public static implicit operator TFailure(ValueResult<TFailure, TSuccess> result)
  ```

- Description: Gets the possible failure.
- Remarks: If the result is [`default`][default] (uninitialized) or not failed,
an [`InvalidOperationException`][invalid-operation-exception] will be thrown.
- Parameters:

  | Name     | Description        |
  |:---------|:-------------------|
  | `result` | The current result |

- Returns: The possible failure.

***[Top](#valueresulttfailure-tsuccess)***

#### `TSuccess(result)`

- Signature:

  ```cs
  public static implicit operator TSuccess(ValueResult<TFailure, TSuccess> result)
  ```

- Description: Gets the expected success.
- Remarks: If the result is [`default`][default] (uninitialized) or not successful,
an [`InvalidOperationException`][invalid-operation-exception] will be thrown.
- Parameters:

  | Name     | Description        |
  |:---------|:-------------------|
  | `result` | The current result |

- Returns: The expected success.

***[Top](#valueresulttfailure-tsuccess)***

#### `ValueResult<TFailure, TSuccess>(failure)`

- Signature:

  ```cs
  public static implicit operator ValueResult<TFailure, TSuccess>(TFailure failure)
  ```

- Description: Creates a new failed result.
- Parameters:

  | Name      | Description          |
  |:----------|:---------------------|
  | `failure` | The possible failure |

- Returns: A new failed result.

***[Top](#valueresulttfailure-tsuccess)***

#### `ValueResult<TFailure, TSuccess>(success)`

- Signature:

  ```cs
  public static implicit operator ValueResult<TFailure, TSuccess>(TSuccess success)
  ```

- Description: Creates a new successful result.
- Parameters:

  | Name      | Description          |
  |:----------|:---------------------|
  | `success` | The expected success |

- Returns: A new successful result.

***[Top](#valueresulttfailure-tsuccess)***

---

### Methods

#### `Deconstruct(isFailed, failure, success)`

- Signature:

  ```cs
  public void Deconstruct(out bool isFailed, out TFailure failure, out TSuccess success)
  ```

- Description: Deconstructs the root state of the result.
- Remarks: If the result is [`default`][default] (uninitialized),
an [`InvalidOperationException`][invalid-operation-exception] will be thrown.
- Parameters:

  | Name       | Description                           |
  |:-----------|:--------------------------------------|
  | `isFailed` | Indicates whether the state is failed |
  | `failure`  | The possible failure                  |
  | `success`  | The expected success                  |

***[Top](#valueresulttfailure-tsuccess)***

#### `TryGetFailure(output)`

- Signature:

  ```cs
  public bool TryGetFailure(out TFailure output)
  ```

- Description: Determines whether the result represents a failure.
- Parameters:

  | Name     | Description          |
  |:---------|:---------------------|
  | `output` | The possible failure |

- Returns: [`true`][bool] if the result is failed; otherwise, [`false`][bool].

***[Top](#valueresulttfailure-tsuccess)***

#### `TryGetSuccess(output)`

- Signature:

  ```cs
  public bool TryGetSuccess(out TSuccess output)
  ```

- Description: Determines whether the result represents a success.
- Parameters:

  | Name     | Description          |
  |:---------|:---------------------|
  | `output` | The expected success |

- Returns: [`true`][bool] if the result is successful; otherwise, [`false`][bool].

***[Top](#valueresulttfailure-tsuccess)***

#### `Discard`

- Signature:

  ```cs
  public ValueResult<TFailure, Unit> Discard()
  ```

- Description: Discards the expected success.
- Remarks: If the result is [`default`][default] (uninitialized),
an [`InvalidOperationException`][invalid-operation-exception] will be thrown.
- Returns: A new result that replaces the expected success with [`Unit`](../unit.md).

***[Top](#valueresulttfailure-tsuccess)***

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

***[Top](#valueresulttfailure-tsuccess)***

#### `Equals(other)`

- Signature:

  ```cs
  public bool Equals(ValueResult<TFailure, TSuccess> other)
  ```

- Description: Determines whether the specified result is equal to the current result.
- Parameters:

  | Name    | Description                                      |
  |:--------|:-------------------------------------------------|
  | `other` | The result to compare with the current reference |

- Returns: [`true`][bool] if the specified result is equal to the current result; otherwise, [`false`][bool].

***[Top](#valueresulttfailure-tsuccess)***

#### `GetHashCode`

- Signature:

  ```cs
  public override int GetHashCode()
  ```

- Description: Gets the hash code based on the primary members of the current result.
- Returns: The calculated hash code.

***[Top](#valueresulttfailure-tsuccess)***

#### `ToString`

- Signature:

  ```cs
  public override string ToString()
  ```

- Description: Gets the value of the current result.
- Returns: The value of the current result.

***[Top](#valueresulttfailure-tsuccess)***

---

### See also

- [Unit](../unit.md)
- [Result<TFailure, TSuccess>](./result.md)
- [ResultFactory](./result-factory.md)
- [ValueResultFactory](./value-result-factory.md)

***[Top](#valueresulttfailure-tsuccess)***

---

### Additional resources

- [License](../../../../license.txt)
- [Security policy](../../../../security.md)
- [Code of conduct](../../../../code-of-conduct.md)
- [Contributing guidelines](../../../../contributing.md)

***[Top](#valueresulttfailure-tsuccess)***
