// ---------------------------------------------------------------------------------------------------------- 
// Copyright (c) David Andrés Hernández Triana. All rights reserved. 
// Licensed under the MIT License. Please refer to the license file in the project root for more information. 
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests.Results.Fixtures;

internal static class ResultFixture
{
	internal const char Auxiliary = char.MaxValue;

	internal const string Failure = nameof(Failure);

	internal static string RandomFailure => $"{Failure} {Guid.CreateVersion7()}";

	internal const sbyte Success = sbyte.MinValue;

	internal const sbyte SuccessToBind = sbyte.MaxValue;

	internal const short SuccessToMap = short.MinValue;

	internal const short SuccessInitializer = short.MaxValue;
}
