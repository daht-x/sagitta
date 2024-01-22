namespace Daht.Sagitta.Core.UnitTest.Monads.Asserters;

internal static class ResultAsserter
{
	internal static void AreSuccessful<TSuccess, TFailure>(TSuccess expectedSuccess, Result<TSuccess, TFailure> actualResult)
	{
		IsSuccessful(actualResult);
		Assert.Equal(expectedSuccess, actualResult.Success);
		Assert.Equal(default, actualResult.Failure);
	}

	internal static void IsSuccessful<TSuccess, TFailure>(Result<TSuccess, TFailure> actualResult)
	{
		Assert.True(actualResult.IsSuccessful);
		Assert.False(actualResult.IsFailed);
	}

	internal static void AreFailed<TSuccess, TFailure>(TFailure expectedFailure, Result<TSuccess, TFailure> actualResult)
	{
		IsFailed(actualResult);
		Assert.Equal(default, actualResult.Success);
		Assert.Equal(expectedFailure, actualResult.Failure);
	}

	internal static void IsFailed<TSuccess, TFailure>(Result<TSuccess, TFailure> actualResult)
	{
		Assert.False(actualResult.IsSuccessful);
		Assert.True(actualResult.IsFailed);
	}
}
