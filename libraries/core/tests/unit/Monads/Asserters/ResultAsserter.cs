namespace Daht.Sagitta.Core.UnitTests.Monads.Asserters;

internal static class ResultAsserter
{
	internal static void CheckIfAreFailed<TFailure, TSuccess>(TFailure expected, Result<TFailure, TSuccess> actual)
	{
		CheckIfIsFailed(actual);
		Assert.NotNull(expected);
		Assert.Equal(expected, actual.Failure);
		Assert.Equal(default, actual.Success);
	}

	internal static void CheckIfIsFailed<TFailure, TSuccess>(Result<TFailure, TSuccess> actual)
	{
		Assert.NotNull(actual);
		Assert.True(actual.IsFailed);
		Assert.False(actual.IsSuccessful);
	}

	internal static void CheckIfAreSuccessful<TFailure, TSuccess>(TSuccess expected, Result<TFailure, TSuccess> actual)
	{
		CheckIfIsSuccessful(actual);
		Assert.NotNull(expected);
		Assert.Equal(default, actual.Failure);
		Assert.Equal(expected, actual.Success);
	}

	internal static void CheckIfIsSuccessful<TFailure, TSuccess>(Result<TFailure, TSuccess> actual)
	{
		Assert.NotNull(actual);
		Assert.False(actual.IsFailed);
		Assert.True(actual.IsSuccessful);
	}
}
