namespace Daht.Sagitta.Core.Monads;

#pragma warning disable CA1062
/// <summary>Type intended to expose a set of ways to initialize <see cref="Result{TFailure,TSuccess}" />.</summary>
public static class ResultFactory
{
	/// <summary>Creates a new failed result if the value of <paramref name="createSuccess" /> throws <typeparamref name="TException" />; otherwise, creates a new successful result.</summary>
	/// <param name="createSuccess">Creates the expected success.</param>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <typeparam name="TException">Type of possible exception.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="createSuccess" /> throws <typeparamref name="TException" />; otherwise, a new successful result.</returns>
	public static Result<TFailure, TSuccess> Catch<TException, TFailure, TSuccess>(Func<TSuccess> createSuccess, Func<TException, TFailure> createFailure)
		where TException : Exception
	{
		try
		{
			return Succeed<TFailure, TSuccess>(createSuccess);
		}
		catch (TException exception)
		{
			return Fail<TFailure, TSuccess>(createFailure(exception));
		}
	}

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, creates a new successful result.</summary>
	/// <param name="success">The expected success.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, a new successful result.</returns>
	public static Result<TFailure, TSuccess> Ensure<TFailure, TSuccess>(TSuccess success, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)
		=> Ensure(success, predicate, createFailure(success));

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, creates a new successful result.</summary>
	/// <param name="createSuccess">Creates the expected success.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, a new successful result.</returns>
	public static Result<TFailure, TSuccess> Ensure<TFailure, TSuccess>(Func<TSuccess> createSuccess, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> createFailure)
		=> Ensure(createSuccess(), predicate, createFailure);

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, creates a new successful result.</summary>
	/// <param name="createSuccess">Creates the expected success.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="failure">The possible failure.</param>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, a new successful result.</returns>
	public static Result<TFailure, TSuccess> Ensure<TFailure, TSuccess>(Func<TSuccess> createSuccess, Func<TSuccess, bool> predicate, TFailure failure)
		=> Ensure(createSuccess(), predicate, failure);

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, creates a new successful result.</summary>
	/// <param name="success">The expected success.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="failure">The possible failure.</param>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, a new successful result.</returns>
	public static Result<TFailure, TSuccess> Ensure<TFailure, TSuccess>(TSuccess success, Func<TSuccess, bool> predicate, TFailure failure)
		=> predicate(success)
			? Fail<TFailure, TSuccess>(failure)
			: Succeed<TFailure, TSuccess>(success);

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, creates a new successful result.</summary>
	/// <param name="success">The expected success.</param>
	/// <param name="createAuxiliary">Creates the auxiliary to use in combination with <paramref name="predicate" /> and <paramref name="createFailure" />.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <typeparam name="TAuxiliary">Type of auxiliary.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, a new successful result.</returns>
	public static Result<TFailure, TSuccess> Ensure<TAuxiliary, TFailure, TSuccess>(TSuccess success, Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
		=> Ensure(success, createAuxiliary(), predicate, createFailure);

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, creates a new successful result.</summary>
	/// <param name="createSuccess">Creates the expected success.</param>
	/// <param name="createAuxiliary">Creates the auxiliary to use in combination with <paramref name="predicate" /> and <paramref name="createFailure" />.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <typeparam name="TAuxiliary">Type of auxiliary.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, a new successful result.</returns>
	public static Result<TFailure, TSuccess> Ensure<TAuxiliary, TFailure, TSuccess>(Func<TSuccess> createSuccess, Func<TAuxiliary> createAuxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
		=> Ensure(createSuccess(), createAuxiliary, predicate, createFailure);

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, creates a new successful result.</summary>
	/// <param name="createSuccess">Creates the expected success.</param>
	/// <param name="auxiliary">The auxiliary to use in combination with <paramref name="predicate" /> and <paramref name="createFailure" />.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <typeparam name="TAuxiliary">Type of auxiliary.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, a new successful result.</returns>
	public static Result<TFailure, TSuccess> Ensure<TAuxiliary, TFailure, TSuccess>(Func<TSuccess> createSuccess, TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
		=> Ensure(createSuccess(), auxiliary, predicate, createFailure);

	/// <summary>Creates a new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, creates a new successful result.</summary>
	/// <param name="success">The expected success.</param>
	/// <param name="auxiliary">The auxiliary to use in combination with <paramref name="predicate" /> and <paramref name="createFailure" />.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <typeparam name="TAuxiliary">Type of auxiliary.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="predicate" /> is <see langword="true" />; otherwise, a new successful result.</returns>
	public static Result<TFailure, TSuccess> Ensure<TAuxiliary, TFailure, TSuccess>(TSuccess success, TAuxiliary auxiliary, Func<TSuccess, TAuxiliary, bool> predicate, Func<TSuccess, TAuxiliary, TFailure> createFailure)
		=> predicate(success, auxiliary)
			? Fail<TFailure, TSuccess>(createFailure(success, auxiliary))
			: Succeed<TFailure, TSuccess>(success);

	/// <summary>Creates a new failed result.</summary>
	/// <param name="failure">The possible failure.</param>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new failed result.</returns>
	public static Result<TFailure, TSuccess> Fail<TFailure, TSuccess>(TFailure failure)
		=> new(failure);

	/// <summary>Creates a new failed result.</summary>
	/// <param name="createFailure">Creates the possible failure.</param>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new failed result.</returns>
	public static Result<TFailure, TSuccess> Fail<TFailure, TSuccess>(Func<TFailure> createFailure)
		=> new(createFailure());

	/// <summary>Creates a new successful result.</summary>
	/// <param name="success">The expected success.</param>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new successful result.</returns>
	public static Result<TFailure, TSuccess> Succeed<TFailure, TSuccess>(TSuccess success)
		=> new(success);

	/// <summary>Creates a new successful result.</summary>
	/// <param name="createSuccess">Creates the expected success.</param>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new successful result.</returns>
	public static Result<TFailure, TSuccess> Succeed<TFailure, TSuccess>(Func<TSuccess> createSuccess)
		=> new(createSuccess());
}
#pragma warning restore CA1062
