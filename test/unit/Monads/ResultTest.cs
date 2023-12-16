namespace Daht.Sagitta.Core.UnitTest.Monads;

public sealed class ResultTest
{
	private const string root = nameof(Result<object, object>);

	private const string implicitOperator = "Implicit Operator";

	#region Implicit Operator

	#region Overload No. 01

	[Fact]
	[Trait(root, implicitOperator)]
	public void ImplicitOperator_NullSuccess_ArgumentNullException()
	{
		//Arrange
		const Constellation success = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			static () =>
			{
#pragma warning disable S1481
				Result<Constellation, string> _ = success;
#pragma warning restore S1481
			}
		);
		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(success), actualException);
	}

	[Fact]
	[Trait(root, implicitOperator)]
	public void ImplicitOperator_Success_SuccessfulResult()
	{
		//Arrange
		Constellation expectedSuccess = ResultFixture.Success;

		//Act
		Result<Constellation, string> actualResult = expectedSuccess;

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload No. 02

	[Fact]
	[Trait(root, implicitOperator)]
	public void ImplicitOperator_NullFailure_ArgumentNullException()
	{
		//Arrange
		const string failure = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			static () =>
			{
#pragma warning disable S1481
				Result<Constellation, string> _ = failure;
#pragma warning restore S1481
			}
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(failure), actualException);
	}

	[Fact]
	[Trait(root, implicitOperator)]
	public void ImplicitOperator_Failure_FailedResult()
	{
		//Arrange
		const string expectedFailure = ResultFixture.Failure;

		//Act
		Result<Constellation, string> actualResult = expectedFailure;

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#endregion
}
