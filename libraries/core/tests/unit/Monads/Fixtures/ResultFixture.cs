// ---------------------------------------------------------------------------------------------------------- 
// Copyright (c) David Andrés Hernández Triana. All rights reserved. 
// Licensed under the MIT License. Please refer to the license file in the project root for more information. 
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests.Monads.Fixtures;

internal static class ResultFixture
{
	internal const string Failure = nameof(Failure);

	internal const string Auxiliary = nameof(Auxiliary);

	internal static Start SuccessToMap
		=> new()
		{
			Constellation = Success,
			Name = "Gamma Sagittae",
			EvolutionaryStage = "Red Giant"
		};

	internal static Start SuccessToInitialize
		=> new()
		{
			Constellation = Success,
			Name = "Alpha Sagittae",
			EvolutionaryStage = "Bright Giant"
		};

	internal static Constellation Success
		=> new()
		{
			Galaxy = "Milky Way",
			Abbreviation = "Sge",
			Name = "Sagitta",
			Symbolism = "The arrow"
		};
}
