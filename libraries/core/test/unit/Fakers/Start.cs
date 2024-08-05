namespace Daht.Sagitta.Core.UnitTest.Fakers;

internal sealed record Start
{
	internal required Constellation Constellation { get; init; }

	internal required string Name { get; init; }

	internal required string EvolutionaryStage { get; init; }
}
