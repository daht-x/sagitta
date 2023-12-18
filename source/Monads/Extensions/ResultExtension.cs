namespace Daht.Sagitta.Core.Monads.Extensions;

/// <summary>Type that extends the behavior of <see cref="Result{TFailure, TSuccess}"/>.</summary>
public static class ResultExtension
{
	/// <summary>Creates a new failed result if the value of <paramref name="predicate"/> is <see langword="true"/>; otherwise, returns the previous result.</summary>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="result">The result to extend.</param>
	/// <param name="predicate">Creates a set of criteria.</param>
	/// <param name="failure">The possible failure.</param>
	/// <returns>A new failed result if the value of <paramref name="predicate"/> is <see langword="true"/>; otherwise, the previous result.</returns>
	public static Result<TSuccess, TFailure> Ensure<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, [NotNull] Func<TSuccess, bool> predicate, TFailure failure)
	{
		if (result.IsFailedOrDefault)
		{
			return result;
		}
		if (predicate(result.Success))
		{
			return ResultFactory.Fail<TSuccess, TFailure>(failure);
		}
		return result;
	}
}
