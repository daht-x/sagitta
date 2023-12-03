namespace Daht.Sagitta.Core.UnitTest.Monads.Asserters;

internal static class ResultAsserter
{
	internal static void AreFailed<TFailure, TSuccess>(TFailure expectedFailure, Result<TFailure, TSuccess> actualResult)
		where TFailure : notnull
		where TSuccess : notnull
	{
		Assert.True(actualResult.IsFailedOrDefault);
		Assert.False(actualResult.IsSuccessfulOrDefault);
		Assert.False(actualResult.IsDefault);
		Assert.True(actualResult.IsFailed);
		Assert.Equal(expectedFailure, actualResult.Failure);
		Assert.False(actualResult.IsSuccessful);
		Assert.Equal(default, actualResult.Success);
	}

	internal static void AreSuccessful<TFailure, TSuccess>(TSuccess expectedSuccess, Result<TFailure, TSuccess> actualResult)
		where TFailure : notnull
		where TSuccess : notnull
	{
		Assert.False(actualResult.IsFailedOrDefault);
		Assert.True(actualResult.IsSuccessfulOrDefault);
		Assert.False(actualResult.IsDefault);
		Assert.False(actualResult.IsFailed);
		Assert.Equal(default, actualResult.Failure);
		Assert.True(actualResult.IsSuccessful);
		Assert.Equal(expectedSuccess, actualResult.Success);
	}
}
