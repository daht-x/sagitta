namespace Daht.Sagitta.Core.Monads;

#pragma warning disable CA1062
/// <summary>Type that encapsulates both the expected success and the possible failure of a given action.</summary>
/// <typeparam name="TSuccess">Type of expected success.</typeparam>
/// <typeparam name="TFailure">Type of possible failure.</typeparam>
public sealed class Result<TSuccess, TFailure>
{
	/// <summary>Creates a new successful result.</summary>
	/// <param name="success">The expected success.</param>
	public Result(TSuccess success)
	{
		IsSuccessful = true;
		Success = success;
	}

	/// <summary>Creates a new failed result.</summary>
	/// <param name="failure">The possible failure.</param>
	public Result(TFailure failure)
	{
		IsFailed = true;
		Failure = failure;
	}

	/// <summary>Indicates whether the status is successful.</summary>
	public bool IsSuccessful { get; }

	/// <summary>The expected success.</summary>
	public TSuccess Success { get; } = default!;

	/// <summary>Indicates whether the status is failed.</summary>
	public bool IsFailed { get; }

	/// <summary>The possible failure.</summary>
	public TFailure Failure { get; } = default!;

	/// <summary>Creates a new successful result.</summary>
	/// <param name="success">The expected success.</param>
	/// <returns>A new successful result.</returns>
	public static implicit operator Result<TSuccess, TFailure>(TSuccess success)
		=> new(success);

	/// <summary>Creates a new failed result.</summary>
	/// <param name="failure">The possible failure.</param>
	/// <returns>A new failed result.</returns>
	public static implicit operator Result<TSuccess, TFailure>(TFailure failure)
		=> new(failure);

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, returns the previous result.</summary>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="failure">The possible failure.</param>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, the previous result.</returns>
	public Result<TSuccess, TFailure> Ensure(Func<TSuccess, bool> predicate, TFailure failure)
	{
		if (IsFailed)
		{
			return this;
		}
		return predicate(Success)
			? ResultFactory.Fail<TSuccess, TFailure>(failure)
			: this;
	}

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, returns the previous result.</summary>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, the previous result.</returns>
	public Result<TSuccess, TFailure> Ensure(Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)
	{
		if (IsFailed)
		{
			return this;
		}
		return predicate(Success)
			? ResultFactory.Fail<TSuccess, TFailure>(createFailure(Success))
			: this;
	}
}
#pragma warning restore CA1062
