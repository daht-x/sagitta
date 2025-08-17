// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests.Monads.Fakers;

internal readonly struct FailureWithNullToString
{
	public override string? ToString()
		=> null;
}
