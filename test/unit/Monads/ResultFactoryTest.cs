namespace Daht.Sagitta.Core.UnitTest.Monads;

public sealed class ResultFactoryTest
{
	private const string root = nameof(ResultFactory);

	private const string ensure = nameof(ResultFactory.Ensure);

	private const string @catch = nameof(ResultFactory.Catch);

	private const string succeed = nameof(ResultFactory.Succeed);

	private const string fail = nameof(ResultFactory.Fail);

	#region Ensure

	#region Overload No. 01

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_NullSuccessPlusNullFailure_ArgumentNullException()
	{
		//Arrange
		const Constellation? success = null;
		const string failure = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			static () => _ = ResultFactory.Ensure(success, failure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(failure), actualException);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_NullSuccessPlusFailure_FailedResult()
	{
		//Arrange
		const Constellation? success = null;
		const string expectedFailure = ResultFixture.Failure;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(success, expectedFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusFailure_SuccessfulResult()
	{
		//Arrange
		Constellation? expectedSuccess = ResultFixture.Success;
		const string failure = ResultFixture.Failure;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(expectedSuccess, failure);

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload No. 02

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_NullSuccessPlusNullCreateFailure_ArgumentNullException()
	{
		//Arrange
		const Constellation? success = null;
		const Func<string> createFailure = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			static () => _ = ResultFactory.Ensure(success, createFailure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createFailure), actualException);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_NullSuccessPlusCreateFailureWithNullValue_ArgumentNullException()
	{
		//Arrange
		const Constellation? success = null;
		Func<string> createFailure = static () => null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			() => _ = ResultFactory.Ensure(success, createFailure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createFailure), actualException);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_NullSuccessPlusCreateFailure_FailedResult()
	{
		//Arrange
		const Constellation? success = null;
		const string expectedFailure = ResultFixture.Failure;
		Func<string> createFailure = static () => expectedFailure;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(success, createFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusCreateFailure_SuccessfulResult()
	{
		//Arrange
		Constellation? expectedSuccess = ResultFixture.Success;
		Func<string> createFailure = static () => ResultFixture.Failure;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(expectedSuccess, createFailure);

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload No. 03

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_NullCreateSuccessPlusFailure_ArgumentNullException()
	{
		//Arrange
		const Func<Constellation?> createSuccess = null!;
		const string failure = ResultFixture.Failure;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			static () => _ = ResultFactory.Ensure(createSuccess, failure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createSuccess), actualException);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_CreateSuccessWithNullValuePlusNullFailure_ArgumentNullException()
	{
		//Arrange
		Func<Constellation?> createSuccess = static () => null;
		const string failure = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			() => _ = ResultFactory.Ensure(createSuccess, failure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(failure), actualException);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_CreateSuccessWithNullValuePlusFailure_FailedResult()
	{
		//Arrange
		Func<Constellation?> createSuccess = static () => null;
		const string expectedFailure = ResultFixture.Failure;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(createSuccess, expectedFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_CreateSuccessPlusFailure_SuccessfulResult()
	{
		//Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation?> createSuccess = () => expectedSuccess;
		const string failure = ResultFixture.Failure;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(createSuccess, failure);

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload No. 04

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_NullCreateSuccessPlusCreateFailure_ArgumentNullException()
	{
		//Arrange
		const Func<Constellation?> createSuccess = null!;
		Func<string> createFailure = static () => ResultFixture.Failure;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			() => _ = ResultFactory.Ensure(createSuccess, createFailure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createSuccess), actualException);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_CreateSuccessWithNullValuePlusNullCreateFailure_ArgumentNullException()
	{
		//Arrange
		Func<Constellation?> createSuccess = static () => null;
		const Func<string> createFailure = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			() => _ = ResultFactory.Ensure(createSuccess, createFailure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createFailure), actualException);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_CreateSuccessWithNullValuePlusCreateFailureWithNullValue_ArgumentNullException()
	{
		//Arrange
		Func<Constellation?> createSuccess = static () => null;
		Func<string> createFailure = static () => null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			() => _ = ResultFactory.Ensure(createSuccess, createFailure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createFailure), actualException);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_CreateSuccessWithNullValuePlusCreateFailure_FailedResult()
	{
		//Arrange
		Func<Constellation?> createSuccess = static () => null;
		const string expectedFailure = ResultFixture.Failure;
		Func<string> createFailure = static () => expectedFailure;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(createSuccess, createFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_CreateSuccessPlusCreateFailure_SuccessfulResult()
	{
		//Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation?> createSuccess = () => expectedSuccess;
		Func<string> createFailure = static () => ResultFixture.Failure;

		//Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(createSuccess, createFailure);

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#endregion

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
