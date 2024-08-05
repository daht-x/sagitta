namespace Daht.Sagitta.Core.UnitTest.Monads.Fixtures;

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

	internal static Constellation Success
		=> new()
		{
			Galaxy = "Milky Way",
			Abbreviation = "Sge",
			Name = "Sagitta",
			Symbolism = "The arrow"
		};
}
