namespace Daht.Sagitta.Core.UnitTest.Monads.Asserters;

internal static class ResultAsserter
{
	internal static void CheckIfAreFailed<TFailure, TSuccess>(TFailure expectedFailure,
		Result<TFailure, TSuccess> actualResult)
	{
		CheckIfIsFailed(actualResult);
		Assert.NotNull(expectedFailure);
		Assert.Equal(expectedFailure, actualResult.Failure);
		Assert.Equal(default, actualResult.Success);
	}

	internal static void CheckIfIsFailed<TFailure, TSuccess>(Result<TFailure, TSuccess> actualResult)
	{
		Assert.NotNull(actualResult);
		Assert.True(actualResult.IsFailed);
		Assert.False(actualResult.IsSuccessful);
	}

	internal static void CheckIfAreSuccessful<TFailure, TSuccess>(TSuccess expectedSuccess,
		Result<TFailure, TSuccess> actualResult)
	{
		CheckIfIsSuccessful(actualResult);
		Assert.NotNull(expectedSuccess);
		Assert.Equal(default, actualResult.Failure);
		Assert.Equal(expectedSuccess, actualResult.Success);
	}

	internal static void CheckIfIsSuccessful<TFailure, TSuccess>(Result<TFailure, TSuccess> actualResult)
	{
		Assert.NotNull(actualResult);
		Assert.False(actualResult.IsFailed);
		Assert.True(actualResult.IsSuccessful);
	}
}
