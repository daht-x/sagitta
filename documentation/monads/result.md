# `Result<TSuccess, TFailure>`

***[~](../../readme.md) / Monads /***

## Table of contents

- [Signature](#signature)
- [Description](#description)
- [Generics](#generics)
- [Constructors](#constructors)
- [Properties](#properties)
  - [`IsSuccessful`](#issuccessful)
  - [`Success`](#success)
  - [`IsFailed`](#isfailed)
  - [`Failure`](#failure)
- [Implicit operators](#implicit-operators)
- [Methods](#methods)
  - [`Ensure`](#ensure)
  - [`Map`](#map)
  - [`Bind`](#bind)
  - [`Reduce`](#reduce)
- [Additional resources](#additional-resources)

### Signature

```cs
public sealed class Result<TSuccess, TFailure>
```

***[Go to top](#resulttsuccess-tfailure)***

---

### Description

Type that encapsulates both the expected success and the possible failure of a given action.

***[Go to top](#resulttsuccess-tfailure)***

---

### Generics

- `TSuccess`: Type of expected success.
- `TFailure`: Type of possible failure.

***[Go to top](#resulttsuccess-tfailure)***

---

### Constructors

1. **Signature**:

   ```cs
   public Result(TSuccess success)
   ```

   - **Description**: Creates a new successful result.
   - **Parameters**:
     - `success`: The expected success.

2. **Signature**:

   ```cs
   public Result(TFailure failure)
   ```

   - **Description**: Creates a new failed result.
   - **Parameters**:
     - `failure`: The possible failure.

***[Go to top](#resulttsuccess-tfailure)***

---

### Properties

#### ``IsSuccessful``

- **Signature**:

  ```cs
  public bool IsSuccessful { get; }
  ```

  - **Description**: Indicates whether the status is successful.

***[Go to top](#resulttsuccess-tfailure)***

#### `Success`

- **Signature**:

  ```cs
  public TSuccess Success { get; }
  ```

  - **Description**: The expected success.

***[Go to top](#resulttsuccess-tfailure)***

#### `IsFailed`

- **Signature**:

  ```cs
  public bool IsFailed { get; }
  ```

  - **Description**: Indicates whether the status is failed.

***[Go to top](#resulttsuccess-tfailure)***

#### `Failure`

- **Signature**:

  ```cs
  public TFailure Failure { get; }
  ```

  - **Description**: The possible failure.

***[Go to top](#resulttsuccess-tfailure)***

---

### Implicit operators

1. **Signature**:

   ```cs
   public static implicit operator Result<TSuccess, TFailure>(TSuccess success)
   ```

   - **Description**: Creates a new successful result.
   - **Parameters**:
     - `success`: The expected success.

2. **Signature**:

   ```cs
   public static implicit operator Result<TSuccess, TFailure>(TFailure failure)
   ```

   - **Description**: Creates a new failed result.
   - **Parameters**:
     - `failure`: The possible failure.

***[Go to top](#resulttsuccess-tfailure)***

---

### Methods

[true-false-operators]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/true-false-operators

#### `Ensure`

1. **Signature**:

   ```cs
   public Result<TSuccess, TFailure> Ensure(Func<TSuccess, bool> predicate, TFailure failure)
   ```

   - **Description**: Creates a new failed result if the value of `predicate` is [true][true-false-operators]; otherwise, returns the previous result.
   - **Parameters**:
     - `predicate`: Creates a set of criteria.
     - `failure`: The possible failure.

2. **Signature**:

   ```cs
   public Result<TSuccess, TFailure> Ensure(Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)
   ```

   - **Description**: Creates a new failed result if the value of `predicate` is [true][true-false-operators]; otherwise, returns the previous result.
   - **Parameters**:
     - `predicate`: Creates a set of criteria.
     - `createFailure`: Creates the possible failure.

3. **Signature**:

   ```cs
   public Result<TSuccess, TFailure> Ensure<TAuxiliary>(TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
   ```

   - **Description**: Creates a new failed result if the value of `predicate` is [true][true-false-operators]; otherwise, returns the previous result.
   - **Parameters**:
     - `auxiliary`: The auxiliary to use in combination with `predicate` and `createFailure`.
     - `predicate`: Creates a set of criteria.
     - `createFailure`: Creates the possible failure.
   - **Generics**:
     - `TAuxiliary`: Type of auxiliary.

4. **Signature**:

   ```cs
   public Result<TSuccess, TFailure> Ensure<TAuxiliary>(Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
   ```

   - **Description**: Creates a new failed result if the value of `predicate` is [true][true-false-operators]; otherwise, returns the previous result.
   - **Parameters**:
     - `createAuxiliary`: Creates the auxiliary to use in combination with `predicate` and `createFailure`.
     - `predicate`: Creates a set of criteria.
     - `createFailure`: Creates the possible failure.
   - **Generics**:
     - `TAuxiliary`: Type of auxiliary.

***[Go to top](#resulttsuccess-tfailure)***

#### `Map`

1. **Signature**:

   ```cs
   public Result<TSuccessToMap, TFailure> Map<TSuccessToMap>(TSuccessToMap successToMap)
   ```

   - **Description**: Creates a new result with the same or different type of expected success.
   - **Parameters**:
     - `successToMap`: The expected success to map.
   - **Generics**:
     - `TSuccessToMap`: Type of expected success to map.

2. **Signature**:

   ```cs
   public Result<TSuccessToMap, TFailure> Map<TSuccessToMap>(Func<TSuccess, TSuccessToMap> createSuccessToMap)
   ```

   - **Description**: Creates a new result with the same or different type of expected success.
   - **Parameters**:
     - `createSuccessToMap`: Creates the expected success to map.
   - **Generics**:
     - `TSuccessToMap`: Type of expected success to map.

***[Go to top](#resulttsuccess-tfailure)***

#### `Bind`

1. **Signature**:

   ```cs
   public Result<TSuccessToBind, TFailure> Bind<TSuccessToBind>(Func<TSuccess, Result<TSuccessToBind, TFailure>> createResultToBind)
   ```

   - **Description**: Creates a new result in combination with another result with the same or different type of expected success.
   - **Parameters**:
     - `createResultToBind`: Creates a new result to bind.
   - **Generics**:
     - `TSuccessToBind`: Type of expected success to bind.

***[Go to top](#resulttsuccess-tfailure)***

#### `Reduce`

1. **Signature**:

   ```cs
   public TReducer Reduce<TReducer>(Func<TSuccess, TReducer> createReducedSuccess, Func<TFailure, TReducer> createReducedFailure)
   ```

   - **Description**: Creates a new reduced failure if the result is failed; otherwise, creates a new reduced success.
   - **Parameters**:
     - `createReducedSuccess`: Creates the expected reduced success.
     - `createReducedFailure`: Creates the possible reduced failure.
   - **Generics**:
     - `TReducer`: Type of reducer.

***[Go to top](#resulttsuccess-tfailure)***

---

### Additional resources

- [`ResultFactory`](./result-factory.md): Type that exposes a set of ways to initialize [`Result<TSuccess, TFailure>`](#resulttsuccess-tfailure).

***[Go to top](#resulttsuccess-tfailure)***
