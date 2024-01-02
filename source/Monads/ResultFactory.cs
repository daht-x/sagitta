namespace Daht.Sagitta.Core.Monads;

#pragma warning disable CA1062
/// <summary>Type that exposes a set of ways to initialize <see cref="Result{TFailure, TSuccess}" />.</summary>
public static class ResultFactory
{
	/// <summary>Creates a new failed result if the value of <paramref name="createSuccess" /> throws <typeparamref name="TException" />; otherwise, creates a new successful result.</summary>
	/// <param name="createSuccess">Creates the expected success.</param>
	/// <param name="createFailure">Creates the possible failure in combination with <typeparamref name="TException" />.</param>
	/// <typeparam name="TException">Type of possible exception.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="createSuccess" /> throws <typeparamref name="TException" />; otherwise, a new successful result.</returns>
	public static Result<TSuccess, TFailure> Catch<TException, TSuccess, TFailure>(Func<TSuccess> createSuccess, Func<TException, TFailure> createFailure)
		where TException : Exception
	{
		try
		{
			return Succeed<TSuccess, TFailure>(createSuccess);
		}
		catch (TException exception)
		{
			return Fail<TSuccess, TFailure>(createFailure(exception));
		}
	}

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, returns the previous result.</summary>
	/// <param name="success">The expected success.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="failure">The possible failure.</param>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, the previous result.</returns>
	public static Result<TSuccess, TFailure> Ensure<TSuccess, TFailure>(TSuccess success, Func<TSuccess, bool> predicate, TFailure failure)
		=> predicate(success)
			? Fail<TSuccess, TFailure>(failure)
			: Succeed<TSuccess, TFailure>(success);

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, returns the previous result.</summary>
	/// <param name="success">The expected success.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, the previous result.</returns>
	public static Result<TSuccess, TFailure> Ensure<TSuccess, TFailure>(TSuccess success, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)
		=> predicate(success)
			? Fail<TSuccess, TFailure>(createFailure(success))
			: Succeed<TSuccess, TFailure>(success);

	/// <summary>Creates a new successful result.</summary>
	/// <param name="success">The expected success.</param>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <returns>A new successful result.</returns>
	public static Result<TSuccess, TFailure> Succeed<TSuccess, TFailure>(TSuccess success)
		=> new(success);

	/// <summary>Creates a new successful result.</summary>
	/// <param name="createSuccess">Creates the expected success.</param>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <returns>A new successful result.</returns>
	public static Result<TSuccess, TFailure> Succeed<TSuccess, TFailure>(Func<TSuccess> createSuccess)
		=> new(createSuccess());

	/// <summary>Creates a new failed result.</summary>
	/// <param name="failure">The possible failure.</param>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <returns>A new failed result.</returns>
	public static Result<TSuccess, TFailure> Fail<TSuccess, TFailure>(TFailure failure)
		=> new(failure);

	/// <summary>Creates a new failed result.</summary>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <returns>A new failed result.</returns>
	public static Result<TSuccess, TFailure> Fail<TSuccess, TFailure>(Func<TFailure> createFailure)
		=> new(createFailure());
}
#pragma warning restore CA1062
