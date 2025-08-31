// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests.Results.Fixtures;

internal static class ValueResultFixture
{
	internal static Failure Failure
		=> Failure.Availability;

	internal const sbyte Success = sbyte.MinValue;
}
