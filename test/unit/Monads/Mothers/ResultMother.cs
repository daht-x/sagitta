namespace Daht.Sagitta.Core.UnitTest.Monads.Mothers;

internal static class ResultMother
{
	internal static Result<Constellation, string> Default => default;

	internal static Result<Constellation, string> Succeed()
		=> ResultFactory.Succeed<Constellation, string>(ResultFixture.Success);

	internal static Result<Constellation, string> Succeed(Constellation success)
		=> ResultFactory.Succeed<Constellation, string>(success);

	internal static Result<Constellation, string> Fail(string failure)
		=> ResultFactory.Fail<Constellation, string>(failure);
}
