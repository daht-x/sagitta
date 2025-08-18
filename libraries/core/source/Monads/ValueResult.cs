// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.Monads;

/// <summary>Encapsulates both a possible failure and an expected success for a given action.</summary>
/// <remarks>Type intended to handle only value types.</remarks>
/// <typeparam name="TFailure">Type of possible failure.</typeparam>
/// <typeparam name="TSuccess">Type of expected success.</typeparam>
[StructLayout(LayoutKind.Auto)]
public readonly struct ValueResult<TFailure, TSuccess> : IEquatable<ValueResult<TFailure, TSuccess>>
	where TFailure : struct, Enum
	where TSuccess : struct
{
	/// <summary>Indicates whether the current result is initialized.</summary>
	public bool IsInitialized { get; }

	/// <summary>Indicates whether the state is failed.</summary>
	public bool IsFailed { get; }

	private readonly TFailure failure;

	/// <summary>The possible failure.</summary>
	/// <remarks>If the result is <see langword="default" /> (uninitialized) or not failed, accessing <see cref="Failure" /> throws an <see cref="InvalidOperationException" />.</remarks>
	/// <exception cref="InvalidOperationException"/>
	public TFailure Failure
	{
		get
		{
			ThrowInvalidOperationExceptionIfResultIsUninitialized();
			return !IsFailed
				? throw new InvalidOperationException(ResultExceptionMessages.AccessToFailureWhenSuccessful)
				: this.failure;
		}
	}

	private readonly TSuccess success;

	/// <summary>The expected success.</summary>
	/// <remarks>If the result is <see langword="default" /> (uninitialized) or not successful, accessing <see cref="Success" /> throws an <see cref="InvalidOperationException" />.</remarks>
	/// <exception cref="InvalidOperationException" />
	public TSuccess Success
	{
		get
		{
			ThrowInvalidOperationExceptionIfResultIsUninitialized();
			return IsFailed
				? throw new InvalidOperationException(ResultExceptionMessages.AccessToSuccessWhenFailed)
				: this.success;
		}
	}

	/// <summary>Determines whether the left result is not equal to the right result.</summary>
	/// <param name="left">The main result.</param>
	/// <param name="right">The result to compare.</param>
	/// <returns><see langword="true" /> if the left result is not equal to the right result; otherwise, <see langword="false" />.</returns>
	public static bool operator !=(ValueResult<TFailure, TSuccess> left, ValueResult<TFailure, TSuccess> right)
		=> !(left == right);

	/// <summary>Determines whether the left result is equal to the right result.</summary>
	/// <param name="left">The main result.</param>
	/// <param name="right">The result to compare.</param>
	/// <returns><see langword="true" /> if the left result is equal to the right result; otherwise, <see langword="false" />.</returns>
	public static bool operator ==(ValueResult<TFailure, TSuccess> left, ValueResult<TFailure, TSuccess> right)
		=> left.Equals(right);

	/// <summary>Creates a new failed result.</summary>
	/// <param name="failure">The possible failure.</param>
	public ValueResult(TFailure failure)
	{
		Unsafe.SkipInit(out this.success);
		IsInitialized = true;
		IsFailed = true;
		this.failure = failure;
	}

	/// <summary>Creates a new successful result.</summary>
	/// <param name="success">The expected success.</param>
	public ValueResult(TSuccess success)
	{
		Unsafe.SkipInit(out this.failure);
		IsInitialized = true;
		IsFailed = false;
		this.success = success;
	}

	/// <summary>Creates a new failed result.</summary>
	/// <param name="failure">The possible failure.</param>
	/// <returns>A new failed result.</returns>
	public static implicit operator ValueResult<TFailure, TSuccess>(TFailure failure)
		=> new(failure);

	/// <summary>Creates a new successful result.</summary>
	/// <param name="success">The expected success.</param>
	/// <returns>A new successful result.</returns>
	public static implicit operator ValueResult<TFailure, TSuccess>(TSuccess success)
		=> new(success);

	/// <summary>Determines whether the result represents a failure.</summary>
	/// <param name="output">The possible failure.</param>
	/// <returns><see langword="true" /> if the result is failed; otherwise, <see langword="false" />.</returns>
	public bool TryGetFailure(out TFailure output)
	{
		if (!IsInitialized)
		{
			output = default;
			return false;
		}
		output = this.failure;
		return IsFailed;
	}

	/// <summary>Determines whether the result represents a success.</summary>
	/// <param name="output">The expected success.</param>
	/// <returns><see langword="true" /> if the result is successful; otherwise, <see langword="false" />.</returns>
	public bool TryGetSuccess(out TSuccess output)
	{
		if (!IsInitialized)
		{
			output = default;
			return false;
		}
		output = this.success;
		return !IsFailed;
	}

	/// <summary>Deconstructs the root state of the result.</summary>
	/// <remarks>If the result is <see langword="default" /> (uninitialized), an <see cref="InvalidOperationException" /> will be thrown.</remarks>
	/// <param name="isFailed">Indicates whether the state is failed.</param>
	/// <param name="failure">The possible failure.</param>
	/// <param name="success">The expected success.</param>
	/// <exception cref="InvalidOperationException" />
	public void Deconstruct(out bool isFailed, out TFailure failure, out TSuccess success)
	{
		ThrowInvalidOperationExceptionIfResultIsUninitialized();
		isFailed = IsFailed;
		failure = this.failure;
		success = this.success;
	}

	/// <summary>Discards the expected success.</summary>
	/// <remarks>If the result is <see langword="default" /> (uninitialized), an <see cref="InvalidOperationException" /> will be thrown.</remarks>
	/// <returns>A new result that replaces the expected success with <see cref="Unit"/>.</returns>
	/// <exception cref="InvalidOperationException" />
	public ValueResult<TFailure, Unit> Discard()
	{
		ThrowInvalidOperationExceptionIfResultIsUninitialized();
		return IsFailed
			? new(this.failure)
			: new(Unit.Default);
	}

	/// <summary>Determines whether the specified result is equal to the current result.</summary>
	/// <param name="obj">The result to compare with the current reference.</param>
	/// <returns><see langword="true" /> if the specified result is equal to the current result; otherwise, <see langword="false" />.</returns>
	public override bool Equals(object? obj)
		=> obj is ValueResult<TFailure, TSuccess> other && Equals(other);

	/// <summary>Determines whether the specified result is equal to the current result.</summary>
	/// <param name="other">The result to compare with the current reference.</param>
	/// <returns><see langword="true" /> if the specified result is equal to the current result; otherwise, <see langword="false" />.</returns>
	public bool Equals(ValueResult<TFailure, TSuccess> other)
	{
		if ((IsInitialized != other.IsInitialized) || (IsInitialized && other.IsInitialized && (IsFailed != other.IsFailed)))
		{
			return false;
		}
		if (!IsInitialized && !other.IsInitialized)
		{
			return true;
		}
		return IsFailed
			? EqualityComparer<TFailure>.Default.Equals(this.failure, other.failure)
			: EqualityComparer<TSuccess>.Default.Equals(this.success, other.success);
	}

	/// <summary>Gets the hash code based on the primary members of the current result.</summary>
	/// <returns>The calculated hash code.</returns>
	public override int GetHashCode()
	{
		if (!IsInitialized)
		{
			return 0;
		}
		return IsFailed
			? HashCode.Combine(IsInitialized, IsFailed, this.failure)
			: HashCode.Combine(IsInitialized, this.success);
	}

	/// <summary>Gets the value of the current result.</summary>
	/// <returns>The value of the current result.</returns>
	public override string ToString()
	{
		if (!IsInitialized)
		{
			return string.Empty;
		}
		return IsFailed
			? this.failure.ToString()
			: this.success.ToString() ?? string.Empty;
	}

	[StackTraceHidden]
	private void ThrowInvalidOperationExceptionIfResultIsUninitialized()
	{
		if (IsInitialized)
		{
			return;
		}
		ThrowInvalidOperationExceptionForUninitializedResult();
	}

	[DoesNotReturn]
	[StackTraceHidden]
	private static void ThrowInvalidOperationExceptionForUninitializedResult()
		=> throw new InvalidOperationException(
			"The result cannot be accessed when it was not initialized as a failure or success."
		);
}
