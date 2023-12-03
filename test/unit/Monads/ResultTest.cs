namespace Daht.Sagitta.Core.UnitTest.Monads;

public sealed class ResultTest
{
	private const string root = nameof(Result);

	private const string succeed = nameof(Result.Succeed);

	private const string fail = nameof(Result.Fail);

	#region Fail

	[Fact]
	[Trait(root, fail)]
	public void Fail_NullFailure_ArgumentNullException()
	{
		//Arrange
		const string failure = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(static () => _ = Result.Fail<string, string>(failure));

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(failure), actualException);
	}

	[Fact]
	[Trait(root, fail)]
	public void Fail_Failure_FailedResult()
	{
		//Arrange
		const string expectedFailure = ResultFixture.Failure;

		//Act
		Result<string, string> actualResult = Result.Fail<string, string>(expectedFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#region Succeed

	#region Overload No. 01

	[Fact]
	[Trait(root, succeed)]
	public void Succeed_NullSuccess_ArgumentNullException()
	{
		//Arrange
		const string success = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(static () => _ = Result.Succeed<string, string>(success));

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(success), actualException);
	}

	[Fact]
	[Trait(root, succeed)]
	public void Succeed_Success_SuccessfulResult()
	{
		//Arrange
		const string expectedSuccess = ResultFixture.Success;

		//Act
		Result<string, string> actualResult = Result.Succeed<string, string>(expectedSuccess);

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload No. 02

	[Fact]
	[Trait(root, succeed)]
	public void Succeed_NullCreateSuccess_ArgumentNullException()
	{
		//Arrange
		const Func<string> createSuccess = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(static () => _ = Result.Succeed<string, string>(createSuccess));

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createSuccess), actualException);
	}

	[Fact]
	[Trait(root, succeed)]
	public void Succeed_CreateSuccessWithNullValue_ArgumentNullException()
	{
		//Arrange
		Func<string> createSuccess = static () => null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(() => _ = Result.Succeed<string, string>(createSuccess));

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createSuccess), actualException);
	}

	[Fact]
	[Trait(root, succeed)]
	public void Succeed_CreateSuccess_SuccessfulResult()
	{
		//Arrange
		const string expectedSuccess = ResultFixture.Success;
		Func<string> createSuccess = static () => expectedSuccess;

		//Act
		Result<string, string> actualResult = Result.Succeed<string, string>(createSuccess);

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#endregion
}
