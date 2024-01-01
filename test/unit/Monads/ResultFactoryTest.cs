namespace Daht.Sagitta.Core.UnitTest.Monads;

public sealed class ResultFactoryTest
{
	private const string root = nameof(ResultFactory);

	private const string @catch = nameof(ResultFactory.Catch);

	private const string succeed = nameof(ResultFactory.Succeed);

	private const string fail = nameof(ResultFactory.Fail);

	#region Catch

	[Fact]
	[Trait(ResultFactoryTest.root, ResultFactoryTest.@catch)]
	public void Catch_CreateSuccessPlusCreateFailure_SuccessfulResult()
	{
		//Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Constellation CreateSuccess()
			=> expectedSuccess;
		static string CreateFailure(InvalidOperationException exception)
			=> exception.Message;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Catch<InvalidOperationException, Constellation, string>(CreateSuccess, CreateFailure);

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	[Fact]
	[Trait(ResultFactoryTest.root, ResultFactoryTest.@catch)]
	public void Catch_ExceptionPlusCreateFailure_FailedResult()
	{
		//Arrange
		static Constellation CreateSuccess()
			=> throw new InvalidOperationException();
		static string CreateFailure(InvalidOperationException exception)
			=> exception.Message;
		const string expectedFailure = "Operation is not valid due to the current state of the object.";

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Catch<InvalidOperationException, Constellation, string>(CreateSuccess, CreateFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#region Succeed

	#region Overload

	[Fact]
	[Trait(ResultFactoryTest.root, ResultFactoryTest.succeed)]
	public void Succeed_Success_SuccessfulResult()
	{
		//Arrange
		Constellation expectedSuccess = ResultFixture.Success;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Succeed<Constellation, string>(expectedSuccess);

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(ResultFactoryTest.root, ResultFactoryTest.succeed)]
	public void Succeed_CreateSuccess_SuccessfulResult()
	{
		//Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Constellation CreateSuccess()
			=> expectedSuccess;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Succeed<Constellation, string>(CreateSuccess);

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#endregion

	#region Fail

	#region Overload

	[Fact]
	[Trait(ResultFactoryTest.root, ResultFactoryTest.fail)]
	public void Fail_Failure_FailedResult()
	{
		//Arrange
		const string expectedFailure = ResultFixture.Failure;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Fail<Constellation, string>(expectedFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(ResultFactoryTest.root, ResultFactoryTest.fail)]
	public void Fail_CreateFailure_FailedResult()
	{
		//Arrange
		const string expectedFailure = ResultFixture.Failure;
		static string CreateFailure()
			=> expectedFailure;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Fail<Constellation, string>(CreateFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#endregion
}
