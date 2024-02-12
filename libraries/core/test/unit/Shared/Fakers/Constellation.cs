namespace Daht.Sagitta.Core.UnitTest.Shared.Fakers;

internal sealed record Constellation
{
	internal required string Galaxy { get; init; }

	internal required string Abbreviation { get; init; }

	internal required string Name { get; init; }

	internal required string Symbolism { get; init; }
}
