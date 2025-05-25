// ---------------------------------------------------------------------------------------------------------- 
// Copyright (c) David Andrés Hernández Triana. All rights reserved. 
// Licensed under the MIT License. Please refer to the license file in the project root for more information. 
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests.Monads.Fakers;

internal sealed record Start
{
	internal required Constellation Constellation { get; init; }

	internal required string Name { get; init; }

	internal required string EvolutionaryStage { get; init; }
}
