namespace Daht.Sagitta.Core.Monads;

#pragma warning disable CA1062
/// <summary>Type intended to handle both the possible failure and the expected success of a given action.</summary>
/// <typeparam name="TFailure">Type of possible failure.</typeparam>
/// <typeparam name="TSuccess">Type of expected success.</typeparam>
public sealed class Result<TFailure, TSuccess>
{
	/// <summary>Indicates whether the status is failed.</summary>
	public bool IsFailed { get; }

	/// <summary>The possible failure.</summary>
	public TFailure Failure { get; } = default!;

	/// <summary>Indicates whether the status is successful.</summary>
	public bool IsSuccessful { get; }

	/// <summary>The expected success.</summary>
	public TSuccess Success { get; } = default!;

	/// <summary>Creates a new failed result.</summary>
	/// <param name="failure">The possible failure.</param>
	public Result(TFailure failure)
	{
		IsFailed = true;
		Failure = failure;
	}

	/// <summary>Creates a new successful result.</summary>
	/// <param name="success">The expected success.</param>
	public Result(TSuccess success)
	{
		IsSuccessful = true;
		Success = success;
	}

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

	/// <summary>Creates a new failed result if <paramref name="execute" /> throws <typeparamref name="TException" />; otherwise, returns the previous result.</summary>
	/// <param name="execute">The action to execute.</param>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <typeparam name="TException">Type of possible exception.</typeparam>
	/// <returns>A new failed result if <paramref name="execute" /> throws <typeparamref name="TException" />; otherwise, the previous result.</returns>
	public Result<TFailure, TSuccess> Catch<TException>(Action<TSuccess> execute, Func<TException, TFailure> createFailure)
		where TException : Exception
	{
		try
		{
			if (IsFailed)
			{
				return this;
			}
			execute(Success);
			return this;
		}
		catch (TException exception)
		{
			return new(createFailure(exception));
		}
	}

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, returns the previous result.</summary>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, the previous result.</returns>
	public Result<TFailure, TSuccess> Ensure(Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)
		=> Ensure(predicate, createFailure(Success));

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, returns the previous result.</summary>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="failure">The possible failure.</param>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, the previous result.</returns>
	public Result<TFailure, TSuccess> Ensure(Func<TSuccess, bool> predicate, TFailure failure)
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
	/// <param name="createAuxiliary">Creates the auxiliary to use in combination with <paramref name="predicate" /> and <paramref name="createFailure" />.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <typeparam name="TAuxiliary">Type of auxiliary.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, the previous result.</returns>
	public Result<TFailure, TSuccess> Ensure<TAuxiliary>(Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
		=> Ensure(createAuxiliary(), predicate, createFailure);

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, returns the previous result.</summary>
	/// <param name="auxiliary">The auxiliary to use in combination with <paramref name="predicate" /> and <paramref name="createFailure" />.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <typeparam name="TAuxiliary">Type of auxiliary.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, the previous result.</returns>
	public Result<TFailure, TSuccess> Ensure<TAuxiliary>(TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
	{
		if (IsFailed)
		{
			return this;
		}
		return predicate(Success, auxiliary)
			? new(createFailure(Success, auxiliary))
			: this;
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
		execute(Failure);
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
		execute(Success);
		return this;
	}

	/// <summary>Creates a new result with the same or different type of expected success.</summary>
	/// <param name="createSuccessToMap">Creates the expected success to map.</param>
	/// <typeparam name="TSuccessToMap">Type of expected success to map.</typeparam>
	/// <returns>A new result with the same or different type of expected success.</returns>
	public Result<TFailure, TSuccessToMap> Map<TSuccessToMap>(Func<TSuccess, TSuccessToMap> createSuccessToMap)
		=> Map(createSuccessToMap(Success));

	/// <summary>Creates a new result with the same or different type of expected success.</summary>
	/// <param name="successToMap">The expected success to map.</param>
	/// <typeparam name="TSuccessToMap">Type of expected success to map.</typeparam>
	/// <returns>A new result with the same or different type of expected success.</returns>
	public Result<TFailure, TSuccessToMap> Map<TSuccessToMap>(TSuccessToMap successToMap)
		=> IsFailed
			? new(Failure)
			: new(successToMap);

	/// <summary>Creates a new result in combination with another result with the same or different type of expected success.</summary>
	/// <param name="createResultToBind">Creates a new result to bind.</param>
	/// <typeparam name="TSuccessToBind">Type of expected success to bind.</typeparam>
	/// <returns>A new result in combination with another result with the same or different type of expected success.</returns>
	public Result<TFailure, TSuccessToBind> Bind<TSuccessToBind>(Func<TSuccess, Result<TFailure, TSuccessToBind>> createResultToBind)
		=> IsFailed
			? new(Failure)
			: createResultToBind(Success);

	/// <summary>Creates a new reduced failure if the previous result is failed; otherwise, creates a new reduced success.</summary>
	/// <param name="reduceFailure">Creates the possible reduced failure.</param>
	/// <param name="reduceSuccess">Creates the expected reduced success.</param>
	/// <typeparam name="TReducer">Type of reducer.</typeparam>
	/// <returns>A new reduced failure if the previous result is failed; otherwise, a new reduced success.</returns>
	public TReducer Reduce<TReducer>(Func<TFailure, TReducer> reduceFailure, Func<TSuccess, TReducer> reduceSuccess)
		=> IsFailed
			? reduceFailure(Failure)
			: reduceSuccess(Success);
}
#pragma warning restore CA1062
