namespace Daht.Sagitta.Core.UnitTest.Shared.Exceptions.Asserters;

internal static class ArgumentNullExceptionAsserter
{
	internal static void AreEqualParameterNames(string expectedParameterName, ArgumentNullException? exception)
	{
		Assert.NotNull(exception);
		Assert.Equal(expectedParameterName, exception.ParamName);
	}
}
