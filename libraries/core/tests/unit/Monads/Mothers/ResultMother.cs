// ---------------------------------------------------------------------------------------------------------- 
// Copyright (c) David Andrés Hernández Triana. All rights reserved. 
// Licensed under the MIT License. Please refer to the license file in the project root for more information. 
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests.Monads.Mothers;

internal static class ResultMother
{
	internal static Result<string, sbyte> Fail()
		=> new(ResultFixture.Failure);

	internal static Result<string, sbyte> Fail(string failure)
		=> new(failure);

	internal static Result<string, sbyte> Succeed()
		=> new(ResultFixture.Success);

	internal static Result<string, sbyte> Succeed(sbyte success)
		=> new(success);
}
