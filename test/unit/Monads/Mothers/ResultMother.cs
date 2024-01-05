namespace Daht.Sagitta.Core.UnitTest.Monads.Mothers;

internal static class ResultMother
{
	internal static Result<Constellation, string> Succeed()
		=> new(ResultFixture.Success);

	internal static Result<Constellation, string> Succeed(Constellation success)
		=> new(success);

	internal static Result<Constellation, string> SucceedRandomly()
		=> new(ResultFixture.RandomSuccess);

	internal static Result<Constellation, string> Fail(string failure)
		=> new(failure);
}
