# `ResultFactory`

***[home](../../readme.md) / monads /***

## Table of contents

1. [Signature](#signature)
2. [Description](#description)
3. [Methods](#methods)
   - [`Catch`](#catch)
   - [`Ensure`](#ensure)
   - [`Succeed`](#succeed)
   - [`Fail`](#fail)
4. [Additional resources](#additional-resources)

### Signature

```cs
public static class ResultFactory
```

***[Top](#resultfactory)***

---

### Description

Type that exposes a set of ways to initialize [`Result<TSuccess, TFailure>`](./result.md).

***[Top](#resultfactory)***

---

### Methods

#### `Catch`

1. **Signature**:

   ```cs
   public static Result<TSuccess, TFailure> Catch<TException, TSuccess, TFailure>(Func<TSuccess> createSuccess, Func<TException, TFailure> createFailure)
      where TException : Exception
   ```

   - **Description**: Creates a new failed result if the value of `createSuccess` throws `TException`; otherwise, creates a new successful result.
   - **Parameters**:
     - `createSuccess`: Creates the expected success.
     - `createFailure`: Creates the possible failure.
   - **Generics**:
     - `TException`: Type of possible exception.
     - `TSuccess`: Type of expected success.
     - `TFailure`: Type of possible failure.

***[Top](#resultfactory)***

[true-false-operators]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/true-false-operators

#### `Ensure`

1. **Signature**:

   ```cs
   public static Result<TSuccess, TFailure> Ensure<TSuccess, TFailure>(TSuccess success, Func<TSuccess, bool> predicate, TFailure failure)
   ```

   - **Description**: Creates a new failed result if the value of `predicate` is [true][true-false-operators]; otherwise, creates a new successful result.
   - **Parameters**:
     - `success`: The expected success.
     - `predicate`: Creates a set of criteria.
     - `failure`: The possible failure.
   - **Generics**:
     - `TSuccess`: Type of expected success.
     - `TFailure`: Type of possible failure.

2. **Signature**:

   ```cs
   public static Result<TSuccess, TFailure> Ensure<TSuccess, TFailure>(TSuccess success, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)
   ```

   - **Description**: Creates a new failed result if the value of `predicate` is [true][true-false-operators]; otherwise, creates a new successful result.
   - **Parameters**:
     - `success`: The expected success.
     - `predicate`: Creates a set of criteria.
     - `createFailure`: Creates the possible failure.
   - **Generics**:
     - `TSuccess`: Type of expected success.
     - `TFailure`: Type of possible failure.

3. **Signature**:

   ```cs
   public static Result<TSuccess, TFailure> Ensure<TSuccess, TFailure>(Func<TSuccess> createSuccess, Func<TSuccess, bool> predicate, TFailure failure)
   ```

   - **Description**: Creates a new failed result if the value of `predicate` is [true][true-false-operators]; otherwise, creates a new successful result.
   - **Parameters**:
     - `createSuccess`: Creates the expected success.
     - `predicate`: Creates a set of criteria.
     - `failure`: The possible failure.
   - **Generics**:
     - `TSuccess`: Type of expected success.
     - `TFailure`: Type of possible failure.

4. **Signature**:

   ```cs
   public static Result<TSuccess, TFailure> Ensure<TSuccess, TFailure>(Func<TSuccess> createSuccess, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)
   ```

   - **Description**: Creates a new failed result if the value of `predicate` is [true][true-false-operators]; otherwise, creates a new successful result.
   - **Parameters**:
     - `createSuccess`: Creates the expected success.
     - `predicate`: Creates a set of criteria.
     - `createFailure`: Creates the possible failure.
   - **Generics**:
     - `TSuccess`: Type of expected success.
     - `TFailure`: Type of possible failure.

5. **Signature**:

   ```cs
   public static Result<TSuccess, TFailure> Ensure<TAuxiliary, TSuccess, TFailure>(TSuccess success, TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
   ```

   - **Description**: Creates a new failed result if the value of `predicate` is [true][true-false-operators]; otherwise, creates a new successful result.
   - **Parameters**:
     - `success`: The expected success.
     - `auxiliary`: The auxiliary to use in combination with `predicate` and `createFailure`.
     - `predicate`: Creates a set of criteria.
     - `createFailure`: Creates the possible failure.
   - **Generics**:
     - `TAuxiliary`: Type of auxiliary.
     - `TSuccess`: Type of expected success.
     - `TFailure`: Type of possible failure.

6. **Signature**:

   ```cs
   public static Result<TSuccess, TFailure> Ensure<TAuxiliary, TSuccess, TFailure>(TSuccess success, Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
   ```

   - **Description**: Creates a new failed result if the value of `predicate` is [true][true-false-operators]; otherwise, creates a new successful result.
   - **Parameters**:
     - `success`: The expected success.
     - `createAuxiliary`: Creates the auxiliary to use in combination with `predicate` and `createFailure`.
     - `predicate`: Creates a set of criteria.
     - `createFailure`: Creates the possible failure.
   - **Generics**:
     - `TAuxiliary`: Type of auxiliary.
     - `TSuccess`: Type of expected success.
     - `TFailure`: Type of possible failure.

7. **Signature**:

   ```cs
   public static Result<TSuccess, TFailure> Ensure<TAuxiliary, TSuccess, TFailure>(Func<TSuccess> createSuccess, TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
   ```

   - **Description**: Creates a new failed result if the value of `predicate` is [true][true-false-operators]; otherwise, creates a new successful result.
   - **Parameters**:
     - `createSuccess`: Creates the expected success.
     - `auxiliary`: The auxiliary to use in combination with `predicate` and `createFailure`.
     - `predicate`: Creates a set of criteria.
     - `createFailure`: Creates the possible failure.
   - **Generics**:
     - `TAuxiliary`: Type of auxiliary.
     - `TSuccess`: Type of expected success.
     - `TFailure`: Type of possible failure.

8. **Signature**:

   ```cs
   public static Result<TSuccess, TFailure> Ensure<TAuxiliary, TSuccess, TFailure>(Func<TSuccess> createSuccess, Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
   ```

   - **Description**: Creates a new failed result if the value of `predicate` is [true][true-false-operators]; otherwise, creates a new successful result.
   - **Parameters**:
     - `createSuccess`: Creates the expected success.
     - `createAuxiliary`: Creates the auxiliary to use in combination with `predicate` and `createFailure`.
     - `predicate`: Creates a set of criteria.
     - `createFailure`: Creates the possible failure.
   - **Generics**:
     - `TAuxiliary`: Type of auxiliary.
     - `TSuccess`: Type of expected success.
     - `TFailure`: Type of possible failure.

***[Top](#resultfactory)***

#### `Succeed`

1. **Signature**:

   ```cs
   public static Result<TSuccess, TFailure> Succeed<TSuccess, TFailure>(TSuccess success)
   ```

   - **Description**: Creates a new successful result.
   - **Parameters**:
     - `success`: The expected success.
   - **Generics**:
     - `TSuccess`: Type of expected success.
     - `TFailure`: Type of possible failure.

2. **Signature**:

   ```cs
   public static Result<TSuccess, TFailure> Succeed<TSuccess, TFailure>(Func<TSuccess> createSuccess)
   ```

   - **Description**: Creates a new successful result.
   - **Parameters**:
     - `createSuccess`: Creates the expected success.
   - **Generics**:
     - `TSuccess`: Type of expected success.
     - `TFailure`: Type of possible failure.

***[Top](#resultfactory)***

#### `Fail`

1. **Signature**:

   ```cs
   public static Result<TSuccess, TFailure> Fail<TSuccess, TFailure>(TFailure failure)
   ```

   - **Description**: Creates a new failed result.
   - **Parameters**:
     - `failure`: The possible failure.
   - **Generics**:
     - `TSuccess`: Type of expected success.
     - `TFailure`: Type of possible failure.

2. **Signature**:

   ```cs
   public static Result<TSuccess, TFailure> Fail<TSuccess, TFailure>(Func<TFailure> createFailure)
   ```

   - **Description**: Creates a new failed result.
   - **Parameters**:
     - `createFailure`: Creates the possible failure.
   - **Generics**:
     - `TSuccess`: Type of expected success.
     - `TFailure`: Type of possible failure.

***[Top](#resultfactory)***

---

### Additional resources

- [`Result<TSuccess, TFailure>`](./result.md): Type that encapsulates both the expected success and the possible failure of a given action.
- [License](../../license).
- [Security policy](../../security.md).
- [Code of conduct](../../code-of-conduct.md).

***[Top](#resultfactory)***
