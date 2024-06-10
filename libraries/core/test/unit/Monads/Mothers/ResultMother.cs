namespace Daht.Sagitta.Core.UnitTest.Monads.Mothers;

internal static class ResultMother
{
	internal static Result<string, Constellation> Fail()
		=> new(ResultFixture.Failure);

	internal static Result<string, Constellation> Fail(string failure)
		=> new(failure);

	internal static Result<string, Constellation> Succeed()
		=> new(ResultFixture.Success);

	internal static Result<string, Constellation> Succeed(Constellation success)
		=> new(success);
}
