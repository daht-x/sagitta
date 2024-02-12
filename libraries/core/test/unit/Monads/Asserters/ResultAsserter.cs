namespace Daht.Sagitta.Core.UnitTest.Monads.Asserters;

internal static class ResultAsserter
{
	internal static void AreFailed<TFailure, TSuccess>(TFailure expectedFailure, Result<TFailure, TSuccess> actualResult)
	{
		IsFailed(actualResult);
		Assert.Equal(default, actualResult.Success);
		Assert.Equal(expectedFailure, actualResult.Failure);
	}

	internal static void IsFailed<TFailure, TSuccess>(Result<TFailure, TSuccess> actualResult)
	{
		Assert.False(actualResult.IsSuccessful);
		Assert.True(actualResult.IsFailed);
	}

	internal static void AreSuccessful<TFailure, TSuccess>(TSuccess expectedSuccess, Result<TFailure, TSuccess> actualResult)
	{
		IsSuccessful(actualResult);
		Assert.Equal(expectedSuccess, actualResult.Success);
		Assert.Equal(default, actualResult.Failure);
	}

	internal static void IsSuccessful<TFailure, TSuccess>(Result<TFailure, TSuccess> actualResult)
	{
		Assert.True(actualResult.IsSuccessful);
		Assert.False(actualResult.IsFailed);
	}
}
