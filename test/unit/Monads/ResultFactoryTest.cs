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
	public void Catch_NullCreateSuccessPlusCreateFailure_ArgumentNullException()
	{
		//Arrange
		const Func<Constellation> createSuccess = null!;
		Func<InvalidOperationException, string> createFailure = static exception => exception.Message;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			() => _ = ResultFactory.Catch(createSuccess, createFailure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createSuccess), actualException);
	}

	[Fact]
	[Trait(root, @catch)]
	public void Catch_CreateSuccessWithNullValuePlusCreateFailure_ArgumentNullException()
	{
		//Arrange
		Func<Constellation> createSuccess = static () => null!;
		Func<InvalidOperationException, string> createFailure = static exception => exception.Message;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			() => _ = ResultFactory.Catch(createSuccess, createFailure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createSuccess), actualException);
	}

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
	public void Catch_ExceptionPlusNullCreateFailure_ArgumentNullException()
	{
		//Arrange
		Func<Constellation> createSuccess = static () => throw new InvalidOperationException();
		const Func<InvalidOperationException, string> createFailure = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			() => _ = ResultFactory.Catch(createSuccess, createFailure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createFailure), actualException);
	}

	[Fact]
	[Trait(root, @catch)]
	public void Catch_ExceptionPlusCreateFailureWithNullValue_ArgumentNullException()
	{
		//Arrange
		Func<Constellation> createSuccess = static () => throw new InvalidOperationException();
		Func<InvalidOperationException, string> createFailure = static _ => null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			() => _ = ResultFactory.Catch(createSuccess, createFailure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createFailure), actualException);
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

	#region Overload No. 01

	[Fact]
	[Trait(root, succeed)]
	public void Succeed_NullSuccess_ArgumentNullException()
	{
		//Arrange
		const Constellation success = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			static () => _ = ResultFactory.Succeed<Constellation, string>(success)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(success), actualException);
	}

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

	#region Overload No. 02

	[Fact]
	[Trait(root, succeed)]
	public void Succeed_NullCreateSuccess_ArgumentNullException()
	{
		//Arrange
		const Func<Constellation> createSuccess = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			static () => _ = ResultFactory.Succeed<Constellation, string>(createSuccess)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createSuccess), actualException);
	}

	[Fact]
	[Trait(root, succeed)]
	public void Succeed_CreateSuccessWithNullValue_ArgumentNullException()
	{
		//Arrange
		Func<Constellation> createSuccess = static () => null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			() => _ = ResultFactory.Succeed<Constellation, string>(createSuccess)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createSuccess), actualException);
	}

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

	#region Overload No. 01

	[Fact]
	[Trait(root, fail)]
	public void Fail_NullFailure_ArgumentNullException()
	{
		//Arrange
		const string failure = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			static () => _ = ResultFactory.Fail<Constellation, string>(failure)
		);

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
		Result<Constellation, string> actualResult = ResultFactory.Fail<Constellation, string>(expectedFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#region Overload No. 02

	[Fact]
	[Trait(root, fail)]
	public void Fail_NullCreateFailure_ArgumentNullException()
	{
		//Arrange
		const Func<string> createFailure = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			static () => _ = ResultFactory.Fail<Constellation, string>(createFailure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createFailure), actualException);
	}

	[Fact]
	[Trait(root, fail)]
	public void Fail_CreateFailureWithNullValue_ArgumentNullException()
	{
		//Arrange
		Func<string> createFailure = static () => null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			() => _ = ResultFactory.Fail<Constellation, string>(createFailure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createFailure), actualException);
	}

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
