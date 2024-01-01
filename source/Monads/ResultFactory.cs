namespace Daht.Sagitta.Core.Monads;

#pragma warning disable CA1062
/// <summary>Type that exposes a set of ways to initialize <see cref="Result{TFailure, TSuccess}" />.</summary>
public static class ResultFactory
{
	/// <summary>Creates a new failed result if the value of <paramref name="createSuccess" /> throws <typeparamref name="TException" />; otherwise, creates a new successful result.</summary>
	/// <typeparam name="TException">Type of possible exception.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="createSuccess">Creates the expected success.</param>
	/// <param name="createFailure">Creates the possible failure in combination with <typeparamref name="TException" />.</param>
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

	/// <summary>Creates a new successful result.</summary>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="success">The expected success.</param>
	/// <returns>A new successful result.</returns>
	public static Result<TSuccess, TFailure> Succeed<TSuccess, TFailure>(TSuccess success)
		=> new(success);

	/// <summary>Creates a new successful result.</summary>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="createSuccess">Creates the expected success.</param>
	/// <returns>A new successful result.</returns>
	public static Result<TSuccess, TFailure> Succeed<TSuccess, TFailure>(Func<TSuccess> createSuccess)
		=> new(createSuccess());

	/// <summary>Creates a new failed result.</summary>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="failure">The possible failure.</param>
	/// <returns>A new failed result.</returns>
	public static Result<TSuccess, TFailure> Fail<TSuccess, TFailure>(TFailure failure)
		=> new(failure);

	/// <summary>Creates a new failed result.</summary>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <returns>A new failed result.</returns>
	public static Result<TSuccess, TFailure> Fail<TSuccess, TFailure>(Func<TFailure> createFailure)
		=> new(createFailure());
}
#pragma warning restore CA1062
