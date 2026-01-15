// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests.Results.Mothers;

internal static class ValueResultMother
{
	internal static ValueResult<Failure, sbyte> GetDefault()
		=> default;

	internal static ValueResult<Failure, sbyte> Fail()
		=> new(ValueResultFixture.Failure);

	internal static ValueResult<Failure, sbyte> Fail(Failure failure)
		=> new(failure);

	internal static ValueResult<Failure, sbyte> Succeed()
		=> new(ValueResultFixture.Success);

	internal static ValueResult<Failure, sbyte> Succeed(sbyte success)
		=> new(success);
}
