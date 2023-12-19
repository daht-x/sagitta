namespace Daht.Sagitta.Core.UnitTest.Monads;

public sealed class ResultFactoryTest
{
	private const string root = nameof(ResultFactory);

	private const string @catch = nameof(ResultFactory.Catch);

	private const string succeed = nameof(ResultFactory.Succeed);

	private const string fail = nameof(ResultFactory.Fail);

	#region Catch

	[Fact]
	[Trait(root, @catch)]
	public void Catch_CreateSuccessPlusCreateFailure_SuccessfulResult()
	{
		//Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expectedSuccess;
		Func<InvalidOperationException, string> createFailure = static exception => exception.Message;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Catch(createSuccess, createFailure);

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	[Fact]
	[Trait(root, @catch)]
	public void Catch_ExceptionPlusCreateFailure_FailedResult()
	{
		//Arrange
		Func<Constellation> createSuccess = static () => throw new InvalidOperationException();
		Func<InvalidOperationException, string> createFailure = static exception => exception.Message;
		const string expectedFailure = "Operation is not valid due to the current state of the object.";

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Catch(createSuccess, createFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#region Succeed

	#region Overload

	[Fact]
	[Trait(root, succeed)]
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
	[Trait(root, succeed)]
	public void Succeed_CreateSuccess_SuccessfulResult()
	{
		//Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expectedSuccess;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Succeed<Constellation, string>(createSuccess);

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#endregion

	#region Fail

	#region Overload

	[Fact]
	[Trait(root, fail)]
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
	[Trait(root, fail)]
	public void Fail_CreateFailure_FailedResult()
	{
		//Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<string> createFailure = static () => expectedFailure;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Fail<Constellation, string>(createFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#endregion
}
