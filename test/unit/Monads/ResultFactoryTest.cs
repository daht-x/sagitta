namespace Daht.Sagitta.Core.UnitTest.Monads;

public sealed class ResultFactoryTest
{
	private const string root = nameof(ResultFactory);

	private const string @catch = nameof(ResultFactory.Catch);

	private const string ensure = nameof(ResultFactory.Ensure);

	private const string succeed = nameof(ResultFactory.Succeed);

	private const string fail = nameof(ResultFactory.Fail);

	#region Catch

	[Fact]
	[Trait(root, @catch)]
	public void Catch_CreateSuccessPlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expectedSuccess;
		Func<InvalidOperationException, string> createFailure = static exception => exception.Message;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Catch(createSuccess, createFailure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	[Fact]
	[Trait(root, @catch)]
	public void Catch_ExceptionPlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<Constellation> createSuccess = static () => throw new InvalidOperationException();
		Func<InvalidOperationException, string> createFailure = static exception => exception.Message;
		const string expectedFailure = "Operation is not valid due to the current state of the object.";

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Catch(createSuccess, createFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#region Ensure

	#region Overload

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Constellation success = ResultFixture.Success;
		Func<Constellation, bool> predicate = static _ => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string> createFailure = static _ => expectedFailure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(success, predicate, createFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation, bool> predicate = static _ => false;
		Func<Constellation, string> createFailure = static _ => ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(expectedSuccess, predicate, createFailure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_CreateSuccessPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<Constellation> createSuccess = static () => ResultFixture.Success;
		Func<Constellation, bool> predicate = static _ => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string> createFailure = static _ => expectedFailure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(createSuccess, predicate, createFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_CreateSuccessPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expectedSuccess;
		Func<Constellation, bool> predicate = static _ => false;
		Func<Constellation, string> createFailure = static _ => ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(createSuccess, predicate, createFailure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_CreateSuccessPlusTruePredicatePlusFailure_FailedResult()
	{
		// Arrange
		Func<Constellation> createSuccess = static () => ResultFixture.Success;
		Func<Constellation, bool> predicate = static _ => true;
		const string expectedFailure = ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(createSuccess, predicate, expectedFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_CreateSuccessPlusFalsePredicatePlusFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expectedSuccess;
		Func<Constellation, bool> predicate = static _ => false;
		const string failure = ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(createSuccess, predicate, failure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusTruePredicatePlusFailure_FailedResult()
	{
		// Arrange
		Constellation success = ResultFixture.Success;
		Func<Constellation, bool> predicate = static _ => true;
		const string expectedFailure = ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(success, predicate, expectedFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusFalsePredicatePlusFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation, bool> predicate = static _ => false;
		const string failure = ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(expectedSuccess, predicate, failure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Constellation success = ResultFixture.Success;
		Func<string> createAuxiliary = static () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = static (_, _) => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = static (_, _) => expectedFailure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(success, createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusCreateAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<string> createAuxiliary = static () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = static (_, _) => false;
		Func<Constellation, string, string> createFailure = static (_, _) => ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(expectedSuccess, createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_CreateSuccessPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<Constellation> createSuccess = static () => ResultFixture.Success;
		Func<string> createAuxiliary = static () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = static (_, _) => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = static (_, _) => expectedFailure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(createSuccess, createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_CreateSuccessPlusCreateAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expectedSuccess;
		Func<string> createAuxiliary = static () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = static (_, _) => false;
		Func<Constellation, string, string> createFailure = static (_, _) => ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(createSuccess, createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_CreateSuccessPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<Constellation> createSuccess = static () => ResultFixture.Success;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = static (_, _) => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = static (_, _) => expectedFailure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(createSuccess, auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_CreateSuccessPlusAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expectedSuccess;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = static (_, _) => false;
		Func<Constellation, string, string> createFailure = static (_, _) => ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(createSuccess, auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Constellation success = ResultFixture.Success;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = static (_, _) => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = static (_, _) => expectedFailure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(success, auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = static (_, _) => false;
		Func<Constellation, string, string> createFailure = static (_, _) => ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(expectedSuccess, auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#endregion

	#region Succeed

	#region Overload

	[Fact]
	[Trait(root, succeed)]
	public void Succeed_Success_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Succeed<Constellation, string>(expectedSuccess);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, succeed)]
	public void Succeed_CreateSuccess_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expectedSuccess;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Succeed<Constellation, string>(createSuccess);

		// Assert
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
		// Arrange
		const string expectedFailure = ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Fail<Constellation, string>(expectedFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, fail)]
	public void Fail_CreateFailure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<string> createFailure = static () => expectedFailure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Fail<Constellation, string>(createFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#endregion
}
