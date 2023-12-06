namespace Daht.Sagitta.Core.UnitTest.Monads;

public sealed class ResultTest
{
	private const string root = nameof(Result);

	private const string ensure = nameof(Result.Ensure);

	private const string @catch = nameof(Result.Catch);

	private const string succeed = nameof(Result.Succeed);

	private const string fail = nameof(Result.Fail);

	#region Ensure

	#region Overload No. 01

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_NullSuccessPlusNullFailure_ArgumentNullException()
	{
		//Arrange
		const string success = null!;
		const string failure = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(static () => _ = Result.Ensure(success, failure));

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(failure), actualException);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_NullSuccessPlusFailure_FailedResult()
	{
		//Arrange
		const string success = null!;
		const string expectedFailure = ResultFixture.Failure;

		//Act
		Result<string, string> actualResult = Result.Ensure(success, expectedFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusFailure_SuccessfulResult()
	{
		//Arrange
		const string expectedSuccess = ResultFixture.Success;
		const string failure = ResultFixture.Failure;

		//Act
		Result<string, string> actualResult = Result.Ensure(expectedSuccess, failure);

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
		const string success = null!;
		const Func<string> createFailure = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(static () => _ = Result.Ensure(success, createFailure));

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createFailure), actualException);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_NullSuccessPlusCreateFailureWithNullValue_ArgumentNullException()
	{
		//Arrange
		const string success = null!;
		Func<string> createFailure = static () => null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(() => _ = Result.Ensure(success, createFailure));

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createFailure), actualException);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_NullSuccessPlusCreateFailure_FailedResult()
	{
		//Arrange
		const string? success = null;
		const string expectedFailure = ResultFixture.Failure;
		Func<string> createFailure = static () => expectedFailure;

		//Act
		Result<string, string> actualResult = Result.Ensure(success, createFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusCreateFailure_SuccessfulResult()
	{
		//Arrange
		const string expectedSuccess = ResultFixture.Success;
		Func<string> createFailure = static () => ResultFixture.Failure;

		//Act
		Result<string, string> actualResult = Result.Ensure(expectedSuccess, createFailure);

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
		const Func<string> createSuccess = null!;
		Func<InvalidOperationException, string> createFailure = static exception => exception.Message;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(() => _ = Result.Catch(createSuccess, createFailure));

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createSuccess), actualException);
	}

	[Fact]
	[Trait(root, @catch)]
	public void Catch_CreateSuccessWithNullValuePlusCreateFailure_ArgumentNullException()
	{
		//Arrange
		Func<string> createSuccess = static () => null!;
		Func<InvalidOperationException, string> createFailure = static exception => exception.Message;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(() => _ = Result.Catch(createSuccess, createFailure));

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createSuccess), actualException);
	}

	[Fact]
	[Trait(root, @catch)]
	public void Catch_CreateSuccessPlusCreateFailure_SuccessfulResult()
	{
		//Arrange
		const string expectedSuccess = ResultFixture.Success;
		Func<string> createSuccess = static () => expectedSuccess;
		Func<InvalidOperationException, string> createFailure = static exception => exception.Message;

		//Act
		Result<string, string> actualResult = Result.Catch(createSuccess, createFailure);

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	[Fact]
	[Trait(root, @catch)]
	public void Catch_ExceptionPlusNullCreateFailure_ArgumentNullException()
	{
		//Arrange
		Func<string> createSuccess = static () => throw new InvalidOperationException();
		const Func<InvalidOperationException, string> createFailure = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(() => _ = Result.Catch(createSuccess, createFailure));

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createFailure), actualException);
	}

	[Fact]
	[Trait(root, @catch)]
	public void Catch_ExceptionPlusCreateFailureWithNullValue_ArgumentNullException()
	{
		//Arrange
		Func<string> createSuccess = static () => throw new InvalidOperationException();
		Func<InvalidOperationException, string> createFailure = static _ => null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(() => _ = Result.Catch(createSuccess, createFailure));

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(createFailure), actualException);
	}

	[Fact]
	[Trait(root, @catch)]
	public void Catch_ExceptionPlusCreateFailure_FailedResult()
	{
		//Arrange
		Func<string> createSuccess = static () => throw new InvalidOperationException();
		Func<InvalidOperationException, string> createFailure = static exception => exception.Message;
		const string expectedFailure = "Operation is not valid due to the current state of the object.";

		//Act
		Result<string, string> actualResult = Result.Catch(createSuccess, createFailure);

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

	#region Fail

	#region Overload No. 01

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

	#region Overload No. 02

	[Fact]
	[Trait(root, fail)]
	public void Fail_NullCreateFailure_ArgumentNullException()
	{
		//Arrange
		const Func<string> createFailure = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(static () => _ = Result.Fail<string, string>(createFailure));

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
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(() => _ = Result.Fail<string, string>(createFailure));

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
		Result<string, string> actualResult = Result.Fail<string, string>(createFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#endregion
}
