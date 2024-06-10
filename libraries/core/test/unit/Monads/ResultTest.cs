namespace Daht.Sagitta.Core.UnitTest.Monads;

public sealed class ResultTest
{
	private const string @base = nameof(Result<object, object>);

	private const string constructor = "Constructor";

	private const string implicitOperator = "Implicit Operator";

	private const string @catch = nameof(Result<object, object>.Catch);

	private const string ensure = nameof(Result<object, object>.Ensure);

	private const string doOnFailure = nameof(Result<object, object>.DoOnFailure);

	private const string doOnSuccess = nameof(Result<object, object>.DoOnSuccess);

	private const string map = nameof(Result<object, object>.Map);

	private const string bind = nameof(Result<object, object>.Bind);

	private const string reduce = nameof(Result<object, object>.Reduce);

	#region Constructor

	#region Overload

	[Fact]
	[Trait(@base, constructor)]
	public void Constructor_Failure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult = new(expectedFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, constructor)]
	public void Constructor_Success_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;

		// Act
		Result<string, Constellation> actualResult = new(expectedSuccess);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#endregion

	#region Implicit Operator

	#region Overload

	[Fact]
	[Trait(@base, implicitOperator)]
	public void ImplicitOperator_Failure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult = expectedFailure;

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, implicitOperator)]
	public void ImplicitOperator_Success_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;

		// Act
		Result<string, Constellation> actualResult = expectedSuccess;

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#endregion

	#region Catch

	#region Overload

	[Fact]
	[Trait(@base, @catch)]
	public void Catch_FailedResultPlusExecutePlusCreateFailure_FailedResult()
	{
		// Arrange
		bool status = false;
		Action<Constellation> execute = _ => status = true;
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Fail()
			.Catch(execute, createFailure);

		// Assert
		Assert.False(status);
		ResultAsserter.CheckIfIsFailed(actualResult);
	}

	[Fact]
	[Trait(@base, @catch)]
	public void Catch_SuccessfulResultPlusExecutePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		bool status = false;
		Action<Constellation> execute = _ => status = true;
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed()
			.Catch(execute, createFailure);

		// Assert
		Assert.True(status);
		ResultAsserter.CheckIfIsSuccessful(actualResult);
	}

	[Fact]
	[Trait(@base, @catch)]
	public void Catch_SuccessfulResultPlusExceptionInExecutePlusCreateFailure_FailedResult()
	{
		// Arrange
		Action<Constellation> execute = _ => throw new InvalidOperationException();
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;
		const string expectedFailure = "Operation is not valid due to the current state of the object.";

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed()
			.Catch(execute, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, @catch)]
	public void Catch_FailedResultPlusCreateSuccessPlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<Constellation, Constellation> createSuccess = _ => ResultFixture.Success;
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Fail()
			.Catch(createSuccess, createFailure);

		// Assert
		ResultAsserter.CheckIfIsFailed(actualResult);
	}

	[Fact]
	[Trait(@base, @catch)]
	public void Catch_SuccessfulResultPlusCreateSuccessPlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation, Constellation> createSuccess = _ => expectedSuccess;
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed()
			.Catch(createSuccess, createFailure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	[Fact]
	[Trait(@base, @catch)]
	public void Catch_SuccessfulResultPlusExceptionInCreateSuccessPlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<Constellation, Constellation> createSuccess = _ => throw new InvalidOperationException();
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;
		const string expectedFailure = "Operation is not valid due to the current state of the object.";

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed()
			.Catch(createSuccess, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	#endregion

	#endregion

	#region Ensure

	#region Overload

	[Fact]
	[Trait(@base, ensure)]
	public void Ensure_FailedResultPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, bool> predicate = _ => true;
		Func<Constellation, string> createFailure = _ => string.Empty;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Fail(expectedFailure)
			.Ensure(predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, ensure)]
	public void Ensure_SuccessfulResultPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<Constellation, bool> predicate = _ => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string> createFailure = _ => expectedFailure;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed()
			.Ensure(predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, ensure)]
	public void Ensure_SuccessfulResultPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => false;
		Func<Constellation, string> createFailure = _ => ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed(expectedSuccess)
			.Ensure(predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, ensure)]
	public void Ensure_FailedResultPlusTruePredicatePlusFailure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, bool> predicate = _ => true;
		string failure = string.Empty;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Fail(expectedFailure)
			.Ensure(predicate, failure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, ensure)]
	public void Ensure_SuccessfulResultPlusTruePredicatePlusFailure_FailedResult()
	{
		// Arrange
		Func<Constellation, bool> predicate = _ => true;
		const string expectedFailure = ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed()
			.Ensure(predicate, expectedFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, ensure)]
	public void Ensure_SuccessfulResultPlusFalsePredicatePlusFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => false;
		const string failure = ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed(expectedSuccess)
			.Ensure(predicate, failure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, ensure)]
	public void Ensure_FailedResultPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		Func<Constellation, string, string> createFailure = (_, _) => string.Empty;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Fail(expectedFailure)
			.Ensure(createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, ensure)]
	public void Ensure_SuccessfulResultPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = (_, _) => expectedFailure;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed()
			.Ensure(createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, ensure)]
	public void Ensure_SuccessfulResultPlusCreateAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => false;
		Func<Constellation, string, string> createFailure = (_, _) => ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed(expectedSuccess)
			.Ensure(createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, ensure)]
	public void Ensure_FailedResultPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		Func<Constellation, string, string> createFailure = (_, _) => string.Empty;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Fail(expectedFailure)
			.Ensure(auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, ensure)]
	public void Ensure_SuccessfulResultPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = (_, _) => expectedFailure;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed()
			.Ensure(auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, ensure)]
	public void Ensure_SuccessfulResultPlusAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => false;
		Func<Constellation, string, string> createFailure = (_, _) => ResultFixture.Failure;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed(expectedSuccess)
			.Ensure(auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#endregion

	#region DoOnFailure

	[Fact]
	[Trait(@base, doOnFailure)]
	public void DoOnFailure_SuccessfulResultPlusExecute_SuccessfulResult()
	{
		// Arrange
		bool status = false;
		Action<string> execute = _ => status = true;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed()
			.DoOnFailure(execute);

		// Assert
		Assert.False(status);
		ResultAsserter.CheckIfIsSuccessful(actualResult);
	}

	[Fact]
	[Trait(@base, doOnFailure)]
	public void DoOnFailure_FailedResultPlusExecute_FailedResult()
	{
		// Arrange
		bool status = false;
		Action<string> execute = _ => status = true;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Fail()
			.DoOnFailure(execute);

		// Assert
		Assert.True(status);
		ResultAsserter.CheckIfIsFailed(actualResult);
	}

	#endregion

	#region DoOnSuccess

	[Fact]
	[Trait(@base, doOnSuccess)]
	public void DoOnSuccess_FailedResultPlusExecute_FailedResult()
	{
		// Arrange
		bool status = false;
		Action<Constellation> execute = _ => status = true;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Fail()
			.DoOnSuccess(execute);

		// Assert
		Assert.False(status);
		ResultAsserter.CheckIfIsFailed(actualResult);
	}

	[Fact]
	[Trait(@base, doOnSuccess)]
	public void DoOnSuccess_SuccessfulResultPlusExecute_SuccessfulResult()
	{
		// Arrange
		bool status = false;
		Action<Constellation> execute = _ => status = true;

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed()
			.DoOnSuccess(execute);

		// Assert
		Assert.True(status);
		ResultAsserter.CheckIfIsSuccessful(actualResult);
	}

	#endregion

	#region Map

	#region Overload

	[Fact]
	[Trait(@base, map)]
	public void Map_FailedResultPlusCreateSuccessToMap_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, Start> createSuccessToMap = _ => ResultFixture.SuccessToMap;

		// Act
		Result<string, Start> actualResult = ResultMother.Fail(expectedFailure)
			.Map(createSuccessToMap);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, map)]
	public void Map_SuccessfulResultPlusCreateSuccessToMap_SuccessfulResult()
	{
		// Arrange
		Start expectedSuccess = ResultFixture.SuccessToMap;
		Func<Constellation, Start> createSuccessToMap = _ => expectedSuccess;

		// Act
		Result<string, Start> actualResult = ResultMother.Succeed()
			.Map(createSuccessToMap);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, map)]
	public void Map_FailedResultPlusSuccessToMap_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Start successToMap = ResultFixture.SuccessToMap;

		// Act
		Result<string, Start> actualResult = ResultMother.Fail(expectedFailure)
			.Map(successToMap);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, map)]
	public void Map_SuccessfulResultPlusSuccessToMap_SuccessfulResult()
	{
		// Arrange
		Start expectedSuccess = ResultFixture.SuccessToMap;

		// Act
		Result<string, Start> actualResult = ResultMother.Succeed()
			.Map(expectedSuccess);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#endregion

	#region Bind

	[Fact]
	[Trait(@base, bind)]
	public void Bind_FailedResultPlusCreateResultToBindWithSuccessfulResult_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, Result<string, Constellation>> createResultToBind = _ => ResultMother.Succeed();

		// Act
		Result<string, Constellation> actualResult = ResultMother.Fail(expectedFailure)
			.Bind(createResultToBind);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, bind)]
	public void Bind_SuccessfulResultPlusCreateResultToBindWithFailedResult_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, Result<string, Constellation>> createResultToBind = _ => ResultMother.Fail(expectedFailure);

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed()
			.Bind(createResultToBind);

		// Assert
		ResultAsserter.CheckIfAreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(@base, bind)]
	public void Bind_SuccessfulResultPlusCreateResultToBindWithSuccessfulResult_SuccessfulResult()
	{
		// Arrange
		Constellation success = new()
		{
			Galaxy = string.Empty,
			Abbreviation = string.Empty,
			Name = string.Empty,
			Symbolism = string.Empty
		};
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation, Result<string, Constellation>> createResultToBind = _
			=> ResultMother.Succeed(expectedSuccess);

		// Act
		Result<string, Constellation> actualResult = ResultMother.Succeed(success)
			.Bind(createResultToBind);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Reduce

	[Fact]
	[Trait(@base, reduce)]
	public void Reduce_FailedResultPlusReduceFailurePlusReduceSuccess_ReducedFailure()
	{
		// Arrange
		object expectedReduction = ResultFixture.Failure;
		Func<string, object> reduceFailure = _ => expectedReduction;
		Func<Constellation, object> reduceSuccess = _ => ResultFixture.Success;

		// Act
		object actualReduction = ResultMother.Fail()
			.Reduce(reduceFailure, reduceSuccess);

		// Assert
		Assert.Equal(expectedReduction, actualReduction);
	}

	[Fact]
	[Trait(@base, reduce)]
	public void Reduce_SuccessfulResultPlusReduceFailurePlusReduceSuccess_ReducedSuccess()
	{
		// Arrange
		Constellation expectedReduction = ResultFixture.Success;
		Func<string, object> reduceFailure = _ => ResultFixture.Failure;
		Func<Constellation, object> reduceSuccess = _ => expectedReduction;

		// Act
		object actualReduction = ResultMother.Succeed()
			.Reduce(reduceFailure, reduceSuccess);

		// Assert
		Assert.Equal(expectedReduction, actualReduction);
	}

	#endregion
}
