namespace Daht.Sagitta.Core.UnitTest.Monads.Asserters;

internal static class ResultAsserter
{
	internal static void AreSuccessful<TSuccess, TFailure>(TSuccess expectedSuccess, Result<TSuccess, TFailure> actualResult)
	{
		Assert.True(actualResult.IsSuccessful);
		Assert.Equal(expectedSuccess, actualResult.Success);
		Assert.False(actualResult.IsFailed);
		Assert.Equal(default, actualResult.Failure);
	}

	internal static void AreFailed<TSuccess, TFailure>(TFailure expectedFailure, Result<TSuccess, TFailure> actualResult)
	{
		Assert.False(actualResult.IsSuccessful);
		Assert.Equal(default, actualResult.Success);
		Assert.True(actualResult.IsFailed);
		Assert.Equal(expectedFailure, actualResult.Failure);
	}
}
