namespace Daht.Sagitta.Core.UnitTest.Monads.Asserters;

internal static class ResultAsserter
{
	internal static void CheckIfAreFailed<TFailure, TSuccess>(TFailure expectedFailure,
		Result<TFailure, TSuccess> actualResult)
	{
		CheckIfIsFailed(actualResult);
		Assert.Equal(default, actualResult.Success);
		Assert.Equal(expectedFailure, actualResult.Failure);
	}

	internal static void CheckIfIsFailed<TFailure, TSuccess>(Result<TFailure, TSuccess> actualResult)
	{
		Assert.False(actualResult.IsSuccessful);
		Assert.True(actualResult.IsFailed);
	}

	internal static void CheckIfAreSuccessful<TFailure, TSuccess>(TSuccess expectedSuccess,
		Result<TFailure, TSuccess> actualResult)
	{
		CheckIfIsSuccessful(actualResult);
		Assert.Equal(expectedSuccess, actualResult.Success);
		Assert.Equal(default, actualResult.Failure);
	}

	internal static void CheckIfIsSuccessful<TFailure, TSuccess>(Result<TFailure, TSuccess> actualResult)
	{
		Assert.True(actualResult.IsSuccessful);
		Assert.False(actualResult.IsFailed);
	}
}
