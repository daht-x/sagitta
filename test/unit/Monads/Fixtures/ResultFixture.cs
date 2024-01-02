namespace Daht.Sagitta.Core.UnitTest.Monads.Fixtures;

internal static class ResultFixture
{
	internal const string Failure = nameof(Failure);

	internal static Constellation Success
		=> new()
		{
			Abbreviation = "Sge",
			Name = "Sagitta",
			Symbolism = "The arrow"
		};

	internal static string RandomFailure
		=> $"{Failure} | {Guid.NewGuid()}";
}
