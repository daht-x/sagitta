namespace Daht.Sagitta.Core.Monads.Extensions;

/// <summary>Type that extends the behavior of <see cref="Result{TFailure, TSuccess}"/>.</summary>
public static class ResultExtension
{
	/// <summary>Creates a new failed result if the value of <paramref name="predicate"/> is <see langword="true"/>; otherwise, returns the previous result.</summary>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="result">The result to extend.</param>
	/// <param name="predicate">
	///		<para>Creates a set of criteria.</para>
	///		<para>If <paramref name="predicate"/> is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <param name="failure">
	///     <para>The possible failure.</para>
	///     <para>If <paramref name="failure"/> is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <returns>A new failed result if the value of <paramref name="predicate"/> is <see langword="true"/>; otherwise, the previous result.</returns>
	/// <exception cref="ArgumentNullException"/>
	public static Result<TSuccess, TFailure> Ensure<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, bool> predicate, TFailure failure)
	{
		if (result.IsFailedOrDefault)
		{
			return result;
		}
		ArgumentNullException.ThrowIfNull(predicate);
		if (predicate(result.Success))
		{
			return failure is null
				? throw new ArgumentNullException(nameof(failure))
				: ResultFactory.Fail<TSuccess, TFailure>(failure);
		}
		return result;
	}
}
