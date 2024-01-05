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
			? new(failure)
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
			? new(createFailure(Success))
			: this;
	}

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, returns the previous result.</summary>
	/// <param name="auxiliary">The auxiliary to use in combination with <paramref name="predicate" /> and <paramref name="createFailure" />.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <typeparam name="TAuxiliary">Type of auxiliary.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, the previous result.</returns>
	public Result<TSuccess, TFailure> Ensure<TAuxiliary>(TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
	{
		if (IsFailed)
		{
			return this;
		}
		return predicate(Success, auxiliary)
			? new(createFailure(Success, auxiliary))
			: this;
	}

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, returns the previous result.</summary>
	/// <param name="createAuxiliary">Creates the auxiliary to use in combination with <paramref name="predicate" /> and <paramref name="createFailure" />.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <typeparam name="TAuxiliary">Type of auxiliary.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, the previous result.</returns>
	public Result<TSuccess, TFailure> Ensure<TAuxiliary>(Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
	{
		if (IsFailed)
		{
			return this;
		}
		TAuxiliary auxiliary = createAuxiliary();
		return predicate(Success, auxiliary)
			? new(createFailure(Success, auxiliary))
			: this;
	}

	/// <summary>Creates a new result with the same or different type of expected success.</summary>
	/// <param name="successToMap">The expected success to map.</param>
	/// <typeparam name="TSuccessToMap">Type of expected success to map.</typeparam>
	/// <returns>A new result with the same or different type of expected success.</returns>
	public Result<TSuccessToMap, TFailure> Map<TSuccessToMap>(TSuccessToMap successToMap)
		=> IsFailed
			? new(Failure)
			: new(successToMap);

	/// <summary>Creates a new result with the same or different type of expected success.</summary>
	/// <param name="createSuccessToMap">Creates the expected success to map.</param>
	/// <typeparam name="TSuccessToMap">Type of expected success to map.</typeparam>
	/// <returns>A new result with the same or different type of expected success.</returns>
	public Result<TSuccessToMap, TFailure> Map<TSuccessToMap>(Func<TSuccess, TSuccessToMap> createSuccessToMap)
		=> IsFailed
			? new(Failure)
			: new(createSuccessToMap(Success));

	/// <summary>Creates a new result in combination with another result with the same or different type of expected success.</summary>
	/// <param name="createResultToBind">Creates a new result to bind.</param>
	/// <typeparam name="TSuccessToBind">Type of expected success to bind.</typeparam>
	/// <returns>A new result in combination with another result with the same or different type of expected success.</returns>
	public Result<TSuccessToBind, TFailure> Bind<TSuccessToBind>(Func<TSuccess, Result<TSuccessToBind, TFailure>> createResultToBind)
		=> IsFailed
			? new(Failure)
			: createResultToBind(Success);
}
#pragma warning restore CA1062
