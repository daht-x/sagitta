namespace Daht.Sagitta.Core.UnitTest.Shared.Exceptions.Asserters;

internal static class ArgumentNullExceptionAsserter
{
	internal static void AreEqualParameterNames(string expectedParameterName, ArgumentNullException? actualException)
	{
		Assert.NotNull(actualException);
		Assert.Equal(expectedParameterName, actualException.ParamName);
	}
}
