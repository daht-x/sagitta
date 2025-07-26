// ---------------------------------------------------------------------------------------------------------- 
// Copyright (c) David Andrés Hernández Triana. All rights reserved. 
// Licensed under the MIT License. Please refer to the license file in the project root for more information. 
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests.Monads.Asserters;

internal static class ResultAsserter
{
	internal static void IsFailed<TFailure, TSuccess>(TFailure expected, Result<TFailure, TSuccess> actual)
	{
		Assert.NotNull(expected);
		Assert.NotNull(actual);
		Assert.True(actual.IsFailed);
		Assert.False(actual.IsSuccessful);
		Assert.Equal(expected, actual.Failure);
		_ = Assert.Throws<InvalidOperationException>(() => actual.Success);
	}

	internal static void IsSuccessful<TFailure, TSuccess>(TSuccess expected, Result<TFailure, TSuccess> actual)
	{
		Assert.NotNull(expected);
		Assert.NotNull(actual);
		Assert.False(actual.IsFailed);
		Assert.True(actual.IsSuccessful);
		_ = Assert.Throws<InvalidOperationException>(() => actual.Failure);
		Assert.Equal(expected, actual.Success);
	}
}
