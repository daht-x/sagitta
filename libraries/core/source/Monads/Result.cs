// ---------------------------------------------------------------------------------------------------------- 
// Copyright (c) David Andrés Hernández Triana. All rights reserved. 
// Licensed under the MIT License. Please refer to the license file in the project root for more information. 
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.Monads;

/// <summary>Type intended to handle both the possible failure and the expected success of a given action.</summary>
/// <typeparam name="TFailure">Type of possible failure.</typeparam>
/// <typeparam name="TSuccess">Type of expected success.</typeparam>
[SuppressMessage(DesignAnalysisCategory.Name, DesignAnalysisCategory.Rules.ValidateArgumentsOfPublicMethods)]
public sealed class Result<TFailure, TSuccess> : IEquatable<Result<TFailure, TSuccess>>
{
	/// <summary>Indicates whether the status is failed.</summary>
	[MemberNotNullWhen(true, nameof(failure))]
	[MemberNotNullWhen(false, nameof(success))]
	public bool IsFailed { get; }

	private readonly TFailure? failure;

	/// <summary>The possible failure.</summary>
	/// <remarks>If the result is not failed, the <see cref="Failure" /> throws <see cref="InvalidOperationException" />.</remarks>
	/// <exception cref="InvalidOperationException"/>
	public TFailure Failure
		=> !IsFailed
			? throw new InvalidOperationException(ResultExceptionMessages.AccessToFailureWhenSuccessful)
			: this.failure;

	/// <summary>Indicates whether the status is successful.</summary>
	[MemberNotNullWhen(false, nameof(failure))]
	[MemberNotNullWhen(true, nameof(success))]
	public bool IsSuccessful
		=> !IsFailed;

	private readonly TSuccess? success;

	/// <summary>The expected success.</summary>
	/// <remarks>If the result is not successful, the <see cref="Success" /> throws <see cref="InvalidOperationException" />.</remarks>
	/// <exception cref="InvalidOperationException" />
	public TSuccess Success
		=> !IsSuccessful
			? throw new InvalidOperationException(ResultExceptionMessages.AccessToSuccessWhenFailed)
			: this.success;

	/// <summary>Creates a new failed result.</summary>
	/// <param name="failure">A possible failure.</param>
	public Result(TFailure failure)
	{
		IsFailed = true;
		this.failure = failure;
	}

	/// <summary>Creates a new successful result.</summary>
	/// <param name="success">An expected success.</param>
	public Result(TSuccess success)
	{
		IsFailed = false;
		this.success = success;
	}

	/// <summary>Determines whether the left result is not equal to the right result (equality is determined by value).</summary>
	/// <param name="left">The main result.</param>
	/// <param name="right">The result to compare.</param>
	/// <returns><see langword="true" /> if the left result is not equal to the right result; otherwise, <see langword="false" />.</returns>
	public static bool operator !=(Result<TFailure, TSuccess>? left, Result<TFailure, TSuccess>? right)
		=> !(left == right);

	/// <summary>Determines whether the left result is equal to the right result (equality is determined by value).</summary>
	/// <param name="left">The main result.</param>
	/// <param name="right">The result to compare.</param>
	/// <returns><see langword="true" /> if the left result is equal to the right result; otherwise, <see langword="false" />.</returns>
	public static bool operator ==(Result<TFailure, TSuccess>? left, Result<TFailure, TSuccess>? right)
		=> (left is null && right is null) || (left is not null && left.Equals(right));

	/// <summary>Creates a new failed result.</summary>
	/// <param name="failure">A possible failure.</param>
	/// <returns>A new failed result.</returns>
	public static implicit operator Result<TFailure, TSuccess>(TFailure failure)
		=> new(failure);

	/// <summary>Creates a new successful result.</summary>
	/// <param name="success">An expected success.</param>
	/// <returns>A new successful result.</returns>
	public static implicit operator Result<TFailure, TSuccess>(TSuccess success)
		=> new(success);

	/// <summary>Deconstructs the root state of the result.</summary>
	/// <param name="isFailed">Indicates whether the status is failed.</param>
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
	/// <param name="failure">A possible failure.</param>
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
	/// <param name="auxiliary">An auxiliary to use in combination with <paramref name="predicate" /> and <paramref name="createFailure" />.</param>
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

	/// <summary>Maps the expected success to a value of another type.</summary>
	/// <param name="successToMap">An expected success to map.</param>
	/// <typeparam name="TSuccessToMap">Type of expected success to map.</typeparam>
	/// <returns>A new result with a different type of expected success.</returns>
	public Result<TFailure, TSuccessToMap> Map<TSuccessToMap>(TSuccessToMap successToMap)
		=> IsFailed
			? new(this.failure)
			: new(successToMap);

	/// <summary>Maps the expected success to a value of another type.</summary>
	/// <param name="createSuccessToMap">Creates an expected success to map.</param>
	/// <typeparam name="TSuccessToMap">Type of expected success to map.</typeparam>
	/// <returns>A new result with a different type of expected success.</returns>
	public Result<TFailure, TSuccessToMap> Map<TSuccessToMap>(Func<TSuccess, TSuccessToMap> createSuccessToMap)
		=> IsFailed
			? new(this.failure)
			: new(createSuccessToMap(this.success));

	/// <summary>Binds the previous result to a new one.</summary>
	/// <param name="createResultToBind">Creates a new result to bind.</param>
	/// <typeparam name="TSuccessToBind">Type of expected success to bind.</typeparam>
	/// <returns>A new result with a different type of expected success.</returns>
	public Result<TFailure, TSuccessToBind> Bind<TSuccessToBind>(
		Func<TSuccess, Result<TFailure, TSuccessToBind>> createResultToBind
	)
		=> IsFailed
			? new(this.failure)
			: createResultToBind(this.success);

	/// <summary>Resets the state of the expected success.</summary>
	/// <param name="initializerResult">A new initializer result.</param>
	/// <typeparam name="TSuccessInitializer">Type of expected success that acts as initializer.</typeparam>
	/// <returns>A new result with a different type of expected success.</returns>
	public Result<TFailure, TSuccessInitializer> Reset<TSuccessInitializer>(
		Result<TFailure, TSuccessInitializer> initializerResult
	)
		=> IsFailed
			? new(this.failure)
			: initializerResult;

	/// <summary>Discards the expected success.</summary>
	/// <returns>A new result that replaces the expected success with <see cref="Unit"/>.</returns>
	public Result<TFailure, Unit> Discard()
		=> IsFailed
			? new(this.failure)
			: new(Unit.Default);

	/// <summary>Reduces the possible failure or expected success to a single value.</summary>
	/// <param name="reduceFailure">Creates a possible reduced failure.</param>
	/// <param name="reduceSuccess">Creates an expected reduced success.</param>
	/// <typeparam name="TReducer">Type of reducer.</typeparam>
	/// <returns>A new value that can be the possible failure or the expected success.</returns>
	public TReducer Reduce<TReducer>(Func<TFailure, TReducer> reduceFailure, Func<TSuccess, TReducer> reduceSuccess)
		=> IsFailed
			? reduceFailure(this.failure)
			: reduceSuccess(this.success);

	/// <summary>Determines whether the specified result is equal to the current result (equality is determined by value).</summary>
	/// <param name="obj">The result to compare with the current.</param>
	/// <returns><see langword="true" /> if the specified result is equal to the current result; otherwise, <see langword="false" />.</returns>
	public override bool Equals(object? obj)
		=> obj is Result<TFailure, TSuccess> other && Equals(other);

	/// <summary>Determines whether the specified result is equal to the current result (equality is determined by value).</summary>
	/// <param name="other">The result to compare with the current.</param>
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
}
