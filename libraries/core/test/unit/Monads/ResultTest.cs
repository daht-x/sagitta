namespace Daht.Sagitta.Core.UnitTest.Monads;

public sealed class ResultTest
{
	private const string @base = nameof(Result<object, object>);

	private const string memberConstructor = "Constructor";

	private const string memberImplicitOperator = "Implicit Operator";

	private const string memberCatch = nameof(Result<object, object>.Catch);

	private const string memberEnsure = nameof(Result<object, object>.Ensure);

	private const string memberDoOnFailure = nameof(Result<object, object>.DoOnFailure);

	private const string memberDoOnSuccess = nameof(Result<object, object>.DoOnSuccess);

	private const string memberMap = nameof(Result<object, object>.Map);

	private const string memberBind = nameof(Result<object, object>.Bind);

	private const string memberReduce = nameof(Result<object, object>.Reduce);

	#region Constructor

	#region Overload

	[Fact]
	[Trait(@base, memberConstructor)]
	public void Constructor_Failure_FailedResult()
	{
		// Arrange
		const string expected = ResultFixture.Failure;

		// Act
		Result<string, Constellation> actual = new(expected);

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberConstructor)]
	public void Constructor_Success_SuccessfulResult()
	{
		// Arrange
		Constellation expected = ResultFixture.Success;

		// Act
		Result<string, Constellation> actual = new(expected);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#endregion

	#region Implicit Operator

	#region Overload

	[Fact]
	[Trait(@base, memberImplicitOperator)]
	public void ImplicitOperator_Failure_FailedResult()
	{
		// Arrange
		const string expected = ResultFixture.Failure;

		// Act
		Result<string, Constellation> actual = expected;

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberImplicitOperator)]
	public void ImplicitOperator_Success_SuccessfulResult()
	{
		// Arrange
		Constellation expected = ResultFixture.Success;

		// Act
		Result<string, Constellation> actual = expected;

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#endregion

	#region Catch

	#region Overload

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_FailedResultPlusExecutePlusCreateFailure_FailedResult()
	{
		// Arrange
		bool status = false;
		Action<Constellation> execute = _ => status = true;
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;

		// Act
		Result<string, Constellation> actual = ResultMother.Fail()
			.Catch(execute, createFailure);

		// Assert
		Assert.False(status);
		ResultAsserter.CheckIfIsFailed(actual);
	}

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_SuccessfulResultPlusExecutePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		bool status = false;
		Action<Constellation> execute = _ => status = true;
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Catch(execute, createFailure);

		// Assert
		Assert.True(status);
		ResultAsserter.CheckIfIsSuccessful(actual);
	}

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_SuccessfulResultPlusExceptionInExecutePlusCreateFailure_FailedResult()
	{
		// Arrange
		Action<Constellation> execute = _ => throw new InvalidOperationException();
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;
		const string expected = "Operation is not valid due to the current state of the object.";

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Catch(execute, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_FailedResultPlusCreateSuccessPlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<Constellation, Constellation> createSuccess = _ => ResultFixture.Success;
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;

		// Act
		Result<string, Constellation> actual = ResultMother.Fail()
			.Catch(createSuccess, createFailure);

		// Assert
		ResultAsserter.CheckIfIsFailed(actual);
	}

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_SuccessfulResultPlusCreateSuccessPlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expected = ResultFixture.Success;
		Func<Constellation, Constellation> createSuccess = _ => expected;
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Catch(createSuccess, createFailure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_SuccessfulResultPlusExceptionInCreateSuccessPlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<Constellation, Constellation> createSuccess = _ => throw new InvalidOperationException();
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;
		const string expected = "Operation is not valid due to the current state of the object.";

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Catch(createSuccess, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	#endregion

	#endregion

	#region Ensure

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_FailedResultPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		const string expected = ResultFixture.Failure;
		Func<Constellation, bool> predicate = _ => true;
		Func<Constellation, string> createFailure = _ => string.Empty;

		// Act
		Result<string, Constellation> actual = ResultMother.Fail(expected)
			.Ensure(predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<Constellation, bool> predicate = _ => true;
		const string expected = ResultFixture.Failure;
		Func<Constellation, string> createFailure = _ => expected;

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Ensure(predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expected = ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => false;
		Func<Constellation, string> createFailure = _ => ResultFixture.Failure;

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed(expected)
			.Ensure(predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_FailedResultPlusTruePredicatePlusFailure_FailedResult()
	{
		// Arrange
		const string expected = ResultFixture.Failure;
		Func<Constellation, bool> predicate = _ => true;
		string failure = string.Empty;

		// Act
		Result<string, Constellation> actual = ResultMother.Fail(expected)
			.Ensure(predicate, failure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusTruePredicatePlusFailure_FailedResult()
	{
		// Arrange
		Func<Constellation, bool> predicate = _ => true;
		const string expected = ResultFixture.Failure;

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Ensure(predicate, expected);

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusFalsePredicatePlusFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expected = ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => false;
		const string failure = ResultFixture.Failure;

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed(expected)
			.Ensure(predicate, failure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_FailedResultPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		const string expected = ResultFixture.Failure;
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		Func<Constellation, string, string> createFailure = (_, _) => string.Empty;

		// Act
		Result<string, Constellation> actual = ResultMother.Fail(expected)
			.Ensure(createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		const string expected = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = (_, _) => expected;

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Ensure(createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusCreateAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expected = ResultFixture.Success;
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => false;
		Func<Constellation, string, string> createFailure = (_, _) => ResultFixture.Failure;

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed(expected)
			.Ensure(createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_FailedResultPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		const string expected = ResultFixture.Failure;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		Func<Constellation, string, string> createFailure = (_, _) => string.Empty;

		// Act
		Result<string, Constellation> actual = ResultMother.Fail(expected)
			.Ensure(auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		const string expected = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = (_, _) => expected;

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Ensure(auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expected = ResultFixture.Success;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => false;
		Func<Constellation, string, string> createFailure = (_, _) => ResultFixture.Failure;

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed(expected)
			.Ensure(auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#endregion

	#region DoOnFailure

	[Fact]
	[Trait(@base, memberDoOnFailure)]
	public void DoOnFailure_SuccessfulResultPlusExecute_SuccessfulResult()
	{
		// Arrange
		bool status = false;
		Action<string> execute = _ => status = true;

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed()
			.DoOnFailure(execute);

		// Assert
		Assert.False(status);
		ResultAsserter.CheckIfIsSuccessful(actual);
	}

	[Fact]
	[Trait(@base, memberDoOnFailure)]
	public void DoOnFailure_FailedResultPlusExecute_FailedResult()
	{
		// Arrange
		bool status = false;
		Action<string> execute = _ => status = true;

		// Act
		Result<string, Constellation> actual = ResultMother.Fail()
			.DoOnFailure(execute);

		// Assert
		Assert.True(status);
		ResultAsserter.CheckIfIsFailed(actual);
	}

	#endregion

	#region DoOnSuccess

	[Fact]
	[Trait(@base, memberDoOnSuccess)]
	public void DoOnSuccess_FailedResultPlusExecute_FailedResult()
	{
		// Arrange
		bool status = false;
		Action<Constellation> execute = _ => status = true;

		// Act
		Result<string, Constellation> actual = ResultMother.Fail()
			.DoOnSuccess(execute);

		// Assert
		Assert.False(status);
		ResultAsserter.CheckIfIsFailed(actual);
	}

	[Fact]
	[Trait(@base, memberDoOnSuccess)]
	public void DoOnSuccess_SuccessfulResultPlusExecute_SuccessfulResult()
	{
		// Arrange
		bool status = false;
		Action<Constellation> execute = _ => status = true;

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed()
			.DoOnSuccess(execute);

		// Assert
		Assert.True(status);
		ResultAsserter.CheckIfIsSuccessful(actual);
	}

	#endregion

	#region Map

	#region Overload

	[Fact]
	[Trait(@base, memberMap)]
	public void Map_FailedResultPlusCreateSuccessToMap_FailedResult()
	{
		// Arrange
		const string expected = ResultFixture.Failure;
		Func<Constellation, Start> createSuccessToMap = _ => ResultFixture.SuccessToMap;

		// Act
		Result<string, Start> actual = ResultMother.Fail(expected)
			.Map(createSuccessToMap);

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberMap)]
	public void Map_SuccessfulResultPlusCreateSuccessToMap_SuccessfulResult()
	{
		// Arrange
		Start expected = ResultFixture.SuccessToMap;
		Func<Constellation, Start> createSuccessToMap = _ => expected;

		// Act
		Result<string, Start> actual = ResultMother.Succeed()
			.Map(createSuccessToMap);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberMap)]
	public void Map_FailedResultPlusSuccessToMap_FailedResult()
	{
		// Arrange
		const string expected = ResultFixture.Failure;
		Start successToMap = ResultFixture.SuccessToMap;

		// Act
		Result<string, Start> actual = ResultMother.Fail(expected)
			.Map(successToMap);

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberMap)]
	public void Map_SuccessfulResultPlusSuccessToMap_SuccessfulResult()
	{
		// Arrange
		Start expected = ResultFixture.SuccessToMap;

		// Act
		Result<string, Start> actual = ResultMother.Succeed()
			.Map(expected);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#endregion

	#region Bind

	[Fact]
	[Trait(@base, memberBind)]
	public void Bind_FailedResultPlusCreateResultToBindWithSuccessfulResult_FailedResult()
	{
		// Arrange
		const string expected = ResultFixture.Failure;
		Func<Constellation, Result<string, Constellation>> createResultToBind = _ => ResultMother.Succeed();

		// Act
		Result<string, Constellation> actual = ResultMother.Fail(expected)
			.Bind(createResultToBind);

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberBind)]
	public void Bind_SuccessfulResultPlusCreateResultToBindWithFailedResult_FailedResult()
	{
		// Arrange
		const string expected = ResultFixture.Failure;
		Func<Constellation, Result<string, Constellation>> createResultToBind = _ => ResultMother.Fail(expected);

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Bind(createResultToBind);

		// Assert
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberBind)]
	public void Bind_SuccessfulResultPlusCreateResultToBindWithSuccessfulResult_SuccessfulResult()
	{
		// Arrange
		string empty = string.Empty;
		Constellation success = new()
		{
			Galaxy = empty,
			Abbreviation = empty,
			Name = empty,
			Symbolism = empty
		};
		Constellation expected = ResultFixture.Success;
		Func<Constellation, Result<string, Constellation>> createResultToBind = _ => ResultMother.Succeed(expected);

		// Act
		Result<string, Constellation> actual = ResultMother.Succeed(success)
			.Bind(createResultToBind);

		// Assert
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Reduce

	[Fact]
	[Trait(@base, memberReduce)]
	public void Reduce_FailedResultPlusReduceFailurePlusReduceSuccess_ReducedFailure()
	{
		// Arrange
		object expected = ResultFixture.Failure;
		Func<string, object> reduceFailure = _ => expected;
		Func<Constellation, object> reduceSuccess = _ => ResultFixture.Success;

		// Act
		object actual = ResultMother.Fail()
			.Reduce(reduceFailure, reduceSuccess);

		// Assert
		Assert.Equal(expected, actual);
	}

	[Fact]
	[Trait(@base, memberReduce)]
	public void Reduce_SuccessfulResultPlusReduceFailurePlusReduceSuccess_ReducedSuccess()
	{
		// Arrange
		Constellation expected = ResultFixture.Success;
		Func<string, object> reduceFailure = _ => ResultFixture.Failure;
		Func<Constellation, object> reduceSuccess = _ => expected;

		// Act
		object actual = ResultMother.Succeed()
			.Reduce(reduceFailure, reduceSuccess);

		// Assert
		Assert.Equal(expected, actual);
	}

	#endregion
}
