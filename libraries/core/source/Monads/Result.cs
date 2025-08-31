// ---------------------------------------------------------------------------------------------------------- 
// Copyright (c) David Andrés Hernández Triana. All rights reserved. 
// Licensed under the MIT License. Please refer to the license file in the project root for more information. 
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.Monads;

/// <summary>Encapsulates both a possible failure and an expected success for a given action.</summary>
/// <remarks>Type intended to handle both value and reference types.</remarks>
/// <typeparam name="TFailure">Type of possible failure.</typeparam>
/// <typeparam name="TSuccess">Type of expected success.</typeparam>
[SuppressMessage(DesignAnalysisCategory.Name, DesignAnalysisCategory.Rules.ValidateArgumentsOfPublicMethods)]
public sealed class Result<TFailure, TSuccess> : IEquatable<Result<TFailure, TSuccess>>
{
	/// <summary>Indicates whether the state is failed.</summary>
	[MemberNotNullWhen(true, nameof(failure))]
	[MemberNotNullWhen(false, nameof(success))]
	public bool IsFailed { get; }

	private readonly TFailure? failure;

	/// <summary>The possible failure.</summary>
	/// <remarks>If the result is not failed, accessing <see cref="Failure" /> throws an <see cref="InvalidOperationException" />.</remarks>
	/// <exception cref="InvalidOperationException"/>
	public TFailure Failure
		=> !IsFailed
			? throw new InvalidOperationException(ResultExceptionMessages.AccessToFailureWhenSuccessful)
			: this.failure;

	/// <summary>Indicates whether the state is successful.</summary>
	[MemberNotNullWhen(false, nameof(failure))]
	[MemberNotNullWhen(true, nameof(success))]
	public bool IsSuccessful
		=> !IsFailed;

	private readonly TSuccess? success;

	/// <summary>The expected success.</summary>
	/// <remarks>If the result is not successful, accessing <see cref="Success" /> throws an <see cref="InvalidOperationException" />.</remarks>
	/// <exception cref="InvalidOperationException" />
	public TSuccess Success
		=> !IsSuccessful
			? throw new InvalidOperationException(ResultExceptionMessages.AccessToSuccessWhenFailed)
			: this.success;

	/// <summary>Creates a new failed result.</summary>
	/// <param name="failure">The possible failure.</param>
	public Result(TFailure failure)
	{
		IsFailed = true;
		this.failure = failure;
	}

	/// <summary>Creates a new successful result.</summary>
	/// <param name="success">The expected success.</param>
	public Result(TSuccess success)
	{
		IsFailed = false;
		this.success = success;
	}

	/// <summary>Determines whether the left result is not equal to the right result.</summary>
	/// <param name="left">The main result.</param>
	/// <param name="right">The result to compare.</param>
	/// <returns><see langword="true" /> if the left result is not equal to the right result; otherwise, <see langword="false" />.</returns>
	public static bool operator !=(Result<TFailure, TSuccess>? left, Result<TFailure, TSuccess>? right)
		=> !(left == right);

	/// <summary>Determines whether the left result is equal to the right result.</summary>
	/// <param name="left">The main result.</param>
	/// <param name="right">The result to compare.</param>
	/// <returns><see langword="true" /> if the left result is equal to the right result; otherwise, <see langword="false" />.</returns>
	public static bool operator ==(Result<TFailure, TSuccess>? left, Result<TFailure, TSuccess>? right)
		=> (left is null && right is null) || (left is not null && left.Equals(right));

	/// <summary>Indicates whether the state is failed.</summary>
	/// <param name="result">The current result.</param>
	/// <returns><see langword="true" /> if the current result is failed; otherwise, <see langword="false" />.</returns>
	public static bool operator false(Result<TFailure, TSuccess> result)
		=> result.IsFailed;

	/// <summary>Indicates whether the state is successful.</summary>
	/// <param name="result">The current result.</param>
	/// <returns><see langword="true" /> if the current result is successful; otherwise, <see langword="false" />.</returns>
	public static bool operator true(Result<TFailure, TSuccess> result)
		=> result.IsSuccessful;

	/// <summary>Indicates whether the state is failed.</summary>
	/// <param name="result">The current result.</param>
	/// <returns><see langword="true" /> if the current result is failed; otherwise, <see langword="false" />.</returns>
	public static bool operator !(Result<TFailure, TSuccess> result)
		=> result.IsFailed;

	/// <summary>Binds the previous result to a new one.</summary>
	/// <param name="result">The current result.</param>
	/// <param name="create">Creates a new result with the current success.</param>
	/// <returns>A new result with a different expected success.</returns>
	public static Result<TFailure, TSuccess> operator |(
		Result<TFailure, TSuccess> result, Func<TSuccess, Result<TFailure, TSuccess>> create
	)
		=> result.Bind(create);

	/// <summary>Gets the possible failure.</summary>
	/// <remarks>If the result is not failed, an <see cref="InvalidOperationException" /> will be thrown.</remarks>
	/// <param name="result">The current result.</param>
	/// <returns>The possible failure.</returns>
	/// <exception cref="InvalidOperationException" />
	public static implicit operator TFailure(Result<TFailure, TSuccess> result)
		=> result.Failure;

	/// <summary>Gets the expected success.</summary>
	/// <remarks>If the result is not successful, an <see cref="InvalidOperationException" /> will be thrown.</remarks>
	/// <param name="result">The current result.</param>
	/// <returns>The expected success.</returns>
	/// <exception cref="InvalidOperationException" />
	public static implicit operator TSuccess(Result<TFailure, TSuccess> result)
		=> result.Success;

	/// <summary>Creates a new failed result.</summary>
	/// <param name="failure">The possible failure.</param>
	/// <returns>A new failed result.</returns>
	public static implicit operator Result<TFailure, TSuccess>(TFailure failure)
		=> new(failure);

	/// <summary>Creates a new successful result.</summary>
	/// <param name="success">The expected success.</param>
	/// <returns>A new successful result.</returns>
	public static implicit operator Result<TFailure, TSuccess>(TSuccess success)
		=> new(success);

	/// <summary>Deconstructs the root state of the result.</summary>
	/// <param name="isFailed">Indicates whether the state is failed.</param>
	/// <param name="failure">The possible failure.</param>
	/// <param name="success">The expected success.</param>
	public void Deconstruct(out bool isFailed, out TFailure? failure, out TSuccess? success)
	{
		isFailed = IsFailed;
		failure = this.failure;
		success = this.success;
	}

	/// <summary>Determines whether the result represents a failure.</summary>
	/// <param name="output">The possible failure.</param>
	/// <returns><see langword="true" /> if the result is failed; otherwise, <see langword="false" />.</returns>
	public bool TryGetFailure([NotNullWhen(true)] out TFailure? output)
	{
		output = this.failure;
		return IsFailed;
	}

	/// <summary>Determines whether the result represents a success.</summary>
	/// <param name="output">The expected success.</param>
	/// <returns><see langword="true" /> if the result is successful; otherwise, <see langword="false" />.</returns>
	public bool TryGetSuccess([NotNullWhen(true)] out TSuccess? output)
	{
		output = this.success;
		return IsSuccessful;
	}

	/// <summary>Treats <typeparamref name="TException" /> as a new failed result.</summary>
	/// <param name="execute">The action to execute.</param>
	/// <param name="createFailure">Creates a possible failure.</param>
	/// <typeparam name="TException">Type of possible exception.</typeparam>
	/// <returns>A new failed result if <paramref name="execute" /> throws <typeparamref name="TException" />; otherwise, the previous result.</returns>
	public Result<TFailure, TSuccess> Catch<TException>(
		Action<TSuccess> execute, Func<TException, TFailure> createFailure
	)
		where TException : Exception
	{
		try
		{
			if (IsFailed)
			{
				return this;
			}
			execute(this.success);
			return this;
		}
		catch (TException exception)
		{
			return new(createFailure(exception));
		}
	}

	/// <summary>Treats <typeparamref name="TException" /> as a new failed result.</summary>
	/// <param name="createSuccess">Creates an expected success.</param>
	/// <param name="createFailure">Creates a possible failure.</param>
	/// <typeparam name="TException">Type of possible exception.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="createSuccess" /> throws <typeparamref name="TException" />; otherwise, a new successful result.</returns>
	public Result<TFailure, TSuccess> Catch<TException>(
		Func<TSuccess, TSuccess> createSuccess, Func<TException, TFailure> createFailure
	)
		where TException : Exception
	{
		try
		{
			return IsFailed
				? this
				: new(createSuccess(this.success));
		}
		catch (TException exception)
		{
			return new(createFailure(exception));
		}
	}

	/// <summary>Ensures a new failed result if <paramref name="predicate" /> evaluates to <see langword="true" />.</summary>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="failure">The possible failure.</param>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, the previous result.</returns>
	public Result<TFailure, TSuccess> Ensure(Func<TSuccess, bool> predicate, TFailure failure)
	{
		if (IsFailed)
		{
			return this;
		}
		return predicate(this.success)
			? new(failure)
			: this;
	}

	/// <summary>Ensures a new failed result if <paramref name="predicate" /> evaluates to <see langword="true" />.</summary>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates a possible failure.</param>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, the previous result.</returns>
	public Result<TFailure, TSuccess> Ensure(Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)
	{
		if (IsFailed)
		{
			return this;
		}
		return predicate(this.success)
			? new(createFailure(this.success))
			: this;
	}

	/// <summary>Ensures a new failed result if <paramref name="predicate" /> evaluates to <see langword="true" />.</summary>
	/// <param name="auxiliary">The auxiliary to use in combination with <paramref name="predicate" /> and <paramref name="createFailure" />.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates a possible failure.</param>
	/// <typeparam name="TAuxiliary">Type of auxiliary.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, the previous result.</returns>
	public Result<TFailure, TSuccess> Ensure<TAuxiliary>(
		TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate,
		Func<TSuccess, TAuxiliary, TFailure> createFailure
	)
	{
		if (IsFailed)
		{
			return this;
		}
		return predicate(this.success, auxiliary)
			? new(createFailure(this.success, auxiliary))
			: this;
	}

	/// <summary>Ensures a new failed result if <paramref name="predicate" /> evaluates to <see langword="true" />.</summary>
	/// <param name="createAuxiliary">Creates an auxiliary to use in combination with <paramref name="predicate" /> and <paramref name="createFailure" />.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates a possible failure.</param>
	/// <typeparam name="TAuxiliary">Type of auxiliary.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, the previous result.</returns>
	public Result<TFailure, TSuccess> Ensure<TAuxiliary>(
		Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate,
		Func<TSuccess, TAuxiliary, TFailure> createFailure
	)
	{
		if (IsFailed)
		{
			return this;
		}
		TAuxiliary auxiliary = createAuxiliary();
		return predicate(this.success, auxiliary)
			? createFailure(this.success, auxiliary)
			: this;
	}

	/// <summary>Executes an action if the previous result is failed.</summary>
	/// <param name="execute">The action to execute.</param>
	/// <returns>The previous result.</returns>
	public Result<TFailure, TSuccess> DoOnFailure(Action execute)
	{
		if (IsSuccessful)
		{
			return this;
		}
		execute();
		return this;
	}

	/// <summary>Executes an action if the previous result is failed.</summary>
	/// <param name="execute">The action to execute.</param>
	/// <returns>The previous result.</returns>
	public Result<TFailure, TSuccess> DoOnFailure(Action<TFailure> execute)
	{
		if (IsSuccessful)
		{
			return this;
		}
		execute(this.failure);
		return this;
	}

	/// <summary>Executes an action if the previous result is successful.</summary>
	/// <param name="execute">The action to execute.</param>
	/// <returns>The previous result.</returns>
	public Result<TFailure, TSuccess> DoOnSuccess(Action execute)
	{
		if (IsFailed)
		{
			return this;
		}
		execute();
		return this;
	}

	/// <summary>Executes an action if the previous result is successful.</summary>
	/// <param name="execute">The action to execute.</param>
	/// <returns>The previous result.</returns>
	public Result<TFailure, TSuccess> DoOnSuccess(Action<TSuccess> execute)
	{
		if (IsFailed)
		{
			return this;
		}
		execute(this.success);
		return this;
	}

	/// <summary>Executes an actions based on the state of the previous result.</summary>
	/// <param name="doOnFailure">The action to execute if the previous result is failed.</param>
	/// <param name="doOnSuccess">The action to execute if the previous result is successful.</param>
	/// <returns>The previous result.</returns>
	public Result<TFailure, TSuccess> Match(Action doOnFailure, Action doOnSuccess)
	{
		if (IsFailed)
		{
			doOnFailure();
			return this;
		}
		doOnSuccess();
		return this;
	}

	/// <summary>Executes an action based on the state of the previous result.</summary>
	/// <param name="doOnFailure">The action to execute if the previous result is failed.</param>
	/// <param name="doOnSuccess">The action to execute if the previous result is successful.</param>
	/// <returns>The previous result.</returns>
	public Result<TFailure, TSuccess> Match(Action<TFailure> doOnFailure, Action<TSuccess> doOnSuccess)
	{
		if (IsFailed)
		{
			doOnFailure(this.failure);
			return this;
		}
		doOnSuccess(this.success);
		return this;
	}

	/// <summary>Maps the possible failure to a value of another type.</summary>
	/// <param name="create">Creates a possible failure.</param>
	/// <typeparam name="TNewFailure">Type of possible failure.</typeparam>
	/// <returns>A new result with a different type of possible failure.</returns>
	public Result<TNewFailure, TSuccess> MapFailure<TNewFailure>(Func<TFailure, TNewFailure> create)
		=> IsSuccessful
			? new(this.success)
			: new(create(this.failure));

	/// <summary>Maps the expected success to a value of another type.</summary>
	/// <param name="create">Creates an expected success.</param>
	/// <typeparam name="TNewSuccess">Type of expected success.</typeparam>
	/// <returns>A new result with a different type of expected success.</returns>
	public Result<TFailure, TNewSuccess> MapSuccess<TNewSuccess>(Func<TSuccess, TNewSuccess> create)
		=> IsFailed
			? new(this.failure)
			: new(create(this.success));

	/// <summary>Binds the previous result to a new one.</summary>
	/// <param name="create">Creates a new result with the current success.</param>
	/// <typeparam name="TNewSuccess">Type of expected success.</typeparam>
	/// <returns>A new result with a different type of expected success.</returns>
	public Result<TFailure, TNewSuccess> Bind<TNewSuccess>(Func<TSuccess, Result<TFailure, TNewSuccess>> create)
		=> IsFailed
			? new(this.failure)
			: create(this.success);

	/// <summary>Resets the state of the expected success.</summary>
	/// <param name="success">The expected success that acts as initializer.</param>
	/// <typeparam name="TNewSuccess">Type of expected success.</typeparam>
	/// <returns>A new result with a different type of expected success.</returns>
	public Result<TFailure, TNewSuccess> Reset<TNewSuccess>(TNewSuccess success)
		=> IsFailed
			? new(this.failure)
			: new(success);

	/// <summary>Resets the state of the expected success.</summary>
	/// <param name="result">The result that acts as initializer.</param>
	/// <typeparam name="TNewSuccess">Type of expected success.</typeparam>
	/// <returns>A new result with a different type of expected success.</returns>
	public Result<TFailure, TNewSuccess> Reset<TNewSuccess>(Result<TFailure, TNewSuccess> result)
		=> IsFailed
			? new(this.failure)
			: result;

	/// <summary>Discards the expected success.</summary>
	/// <returns>A new result that replaces the expected success with <see cref="Unit"/>.</returns>
	public Result<TFailure, Unit> Discard()
		=> IsFailed
			? new(this.failure)
			: new(Unit.Default);

	/// <summary>Reduces the possible failure or expected success to a single value.</summary>
	/// <param name="reduceFailure">Reduces the possible failure.</param>
	/// <param name="reduceSuccess">Reduces the expected success.</param>
	/// <typeparam name="TReducer">Type of reducer.</typeparam>
	/// <returns>A new value that can be the possible failure or the expected success.</returns>
	public TReducer Reduce<TReducer>(Func<TFailure, TReducer> reduceFailure, Func<TSuccess, TReducer> reduceSuccess)
		=> IsFailed
			? reduceFailure(this.failure)
			: reduceSuccess(this.success);

	/// <summary>Determines whether the specified result is equal to the current result.</summary>
	/// <param name="obj">The result to compare with the current reference.</param>
	/// <returns><see langword="true" /> if the specified result is equal to the current result; otherwise, <see langword="false" />.</returns>
	public override bool Equals(object? obj)
		=> obj is Result<TFailure, TSuccess> other && Equals(other);

	/// <summary>Determines whether the specified result is equal to the current result.</summary>
	/// <param name="other">The result to compare with the current reference.</param>
	/// <returns><see langword="true" /> if the specified result is equal to the current result; otherwise, <see langword="false" />.</returns>
	public bool Equals(Result<TFailure, TSuccess>? other)
	{
		if (other is null)
		{
			return false;
		}
		if (IsFailed != other.IsFailed)
		{
			return false;
		}
		return IsFailed
			? EqualityComparer<TFailure>.Default.Equals(this.failure, other.failure)
			: EqualityComparer<TSuccess>.Default.Equals(this.success, other.success);
	}

	/// <summary>Gets the hash code based on the primary members of the current result.</summary>
	/// <returns>The calculated hash code.</returns>
	public override int GetHashCode()
		=> IsFailed
			? HashCode.Combine(IsFailed, this.failure)
			: HashCode.Combine(IsSuccessful, this.success);

	/// <summary>Gets the value of the current result.</summary>
	/// <returns>The value of the current result.</returns>
	public override string ToString()
		=> IsFailed
			? this.failure?.ToString() ?? string.Empty
			: this.success?.ToString() ?? string.Empty;
}
