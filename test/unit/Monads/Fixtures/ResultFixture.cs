namespace Daht.Sagitta.Core.UnitTest.Monads.Fixtures;

internal static class ResultFixture
{
	internal const string Failure = nameof(ResultFixture.Failure);

	internal static Constellation Success
		=> new()
		{
			Abbreviation = "Sge",
			Name = "Sagitta",
			Symbolism = "The arrow"
		};

	internal static string RandomFailure
		=> $"{ResultFixture.Failure} | {Guid.NewGuid()}";
}
