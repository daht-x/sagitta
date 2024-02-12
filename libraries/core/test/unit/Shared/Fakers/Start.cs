namespace Daht.Sagitta.Core.UnitTest.Shared.Fakers;

internal sealed record Start
{
	internal required string Constellation { get; init; }

	internal required string Name { get; init; }

	internal required string EvolutionaryStage { get; init; }
}
