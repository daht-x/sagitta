namespace Daht.Sagitta.Core.UnitTest.Monads.Fixtures;

internal static class ResultFixture
{
	internal const string Failure = nameof(Failure);

	internal const string Auxiliary = nameof(Auxiliary);

	internal static Constellation Success
		=> new()
		{
			Galaxy = "Milky Way",
			Abbreviation = "Sge",
			Name = "Sagitta",
			Symbolism = "The arrow"
		};

	internal static Start SuccessToMap
		=> new()
		{
			Constellation = "Sagitta",
			Name = "Gamma Sagittae",
			EvolutionaryStage = "Red Giant"
		};
}
