// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests.Monads.Asserters;

internal static class ValueResultAsserter
{
	internal static void IsDefault(Action execute)
		=> Assert.Throws<InvalidOperationException>(execute);

	internal static void IsFailed<TFailure, TSuccess>(TFailure expected, ValueResult<TFailure, TSuccess> actual)
		where TFailure : struct, Enum
		where TSuccess : struct
	{
		Assert.True(actual.IsFailed);
		Assert.Equal(expected, actual.Failure);
		_ = Assert.Throws<InvalidOperationException>(() => actual.Success);
	}

	internal static void IsSuccessful<TFailure, TSuccess>(TSuccess expected, ValueResult<TFailure, TSuccess> actual)
		where TFailure : struct, Enum
		where TSuccess : struct
	{
		Assert.False(actual.IsFailed);
		_ = Assert.Throws<InvalidOperationException>(() => actual.Failure);
		Assert.Equal(expected, actual.Success);
	}
}
