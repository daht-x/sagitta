namespace Daht.Sagitta.Core.UnitTest.Monads;

public sealed class ResultFactoryTest
{
	private const string @base = nameof(ResultFactory);

	private const string memberCatch = nameof(ResultFactory.Catch);

	private const string memberEnsure = nameof(ResultFactory.Ensure);

	private const string memberFail = nameof(ResultFactory.Fail);

	private const string memberSucceed = nameof(ResultFactory.Succeed);

	#region Catch

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_CreateSuccessPlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expectedSuccess;
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;

		// Act
		Result<string, Constellation> actualResult = ResultFactory.Catch(createSuccess, createFailure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_ExceptionInCreateSuccessPlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<Constellation> createSuccess = () => throw new InvalidOperationException();
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;
		const string expectedFailure = "Operation is not valid due to the current state of the object.";

		// Act
		Result<string, Constellation> actualResult = ResultFactory.Catch(createSuccess, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	#endregion

	#region Ensure

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Constellation success = ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string> createFailure = _ => expectedFailure;

		// Act
		Result<string, Constellation> actualResult = ResultFactory.Ensure(success, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => false;
		Func<Constellation, string> createFailure = _ => ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult = ResultFactory.Ensure(expectedSuccess, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<Constellation> createSuccess = () => ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string> createFailure = _ => expectedFailure;

		// Act
		Result<string, Constellation> actualResult = ResultFactory.Ensure(createSuccess, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expectedSuccess;
		Func<Constellation, bool> predicate = _ => false;
		Func<Constellation, string> createFailure = _ => ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult = ResultFactory.Ensure(createSuccess, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusTruePredicatePlusFailure_FailedResult()
	{
		// Arrange
		Func<Constellation> createSuccess = () => ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => true;
		const string expectedFailure = ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult = ResultFactory.Ensure(createSuccess, predicate, expectedFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusFalsePredicatePlusFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expectedSuccess;
		Func<Constellation, bool> predicate = _ => false;
		const string failure = ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult = ResultFactory.Ensure(createSuccess, predicate, failure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusTruePredicatePlusFailure_FailedResult()
	{
		// Arrange
		Constellation success = ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => true;
		const string expectedFailure = ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult = ResultFactory.Ensure(success, predicate, expectedFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusFalsePredicatePlusFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => false;
		const string failure = ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult = ResultFactory.Ensure(expectedSuccess, predicate, failure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Constellation success = ResultFixture.Success;
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = (_, _) => expectedFailure;

		// Act
		Result<string, Constellation> actualResult =
			ResultFactory.Ensure(success, createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusCreateAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => false;
		Func<Constellation, string, string> createFailure = (_, _) => ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult =
			ResultFactory.Ensure(expectedSuccess, createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<Constellation> createSuccess = () => ResultFixture.Success;
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = (_, _) => expectedFailure;

		// Act
		Result<string, Constellation> actualResult =
			ResultFactory.Ensure(createSuccess, createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusCreateAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expectedSuccess;
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => false;
		Func<Constellation, string, string> createFailure = (_, _) => ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult =
			ResultFactory.Ensure(createSuccess, createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<Constellation> createSuccess = () => ResultFixture.Success;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = (_, _) => expectedFailure;

		// Act
		Result<string, Constellation> actualResult =
			ResultFactory.Ensure(createSuccess, auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expectedSuccess;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => false;
		Func<Constellation, string, string> createFailure = (_, _) => ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult =
			ResultFactory.Ensure(createSuccess, auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Constellation success = ResultFixture.Success;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = (_, _) => expectedFailure;

		// Act
		Result<string, Constellation> actualResult = ResultFactory.Ensure(success, auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => false;
		Func<Constellation, string, string> createFailure = (_, _) => ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult =
			ResultFactory.Ensure(expectedSuccess, auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#endregion

	#region Fail

	#region Overload

	[Fact]
	[Trait(@base, memberFail)]
	public void Fail_Failure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult = ResultFactory.Fail<string, Constellation>(expectedFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberFail)]
	public void Fail_CreateFailure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<string> createFailure = () => expectedFailure;

		// Act
		Result<string, Constellation> actualResult = ResultFactory.Fail<string, Constellation>(createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	#endregion

	#endregion

	#region Succeed

	#region Overload

	[Fact]
	[Trait(@base, memberSucceed)]
	public void Succeed_Success_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;

		// Act
		Result<string, Constellation> actualResult = ResultFactory.Succeed<string, Constellation>(expectedSuccess);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberSucceed)]
	public void Succeed_CreateSuccess_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expectedSuccess;

		// Act
		Result<string, Constellation> actualResult = ResultFactory.Succeed<string, Constellation>(createSuccess);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#endregion
}
