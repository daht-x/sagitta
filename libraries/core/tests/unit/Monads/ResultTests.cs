namespace Daht.Sagitta.Core.UnitTests.Monads;

public sealed class ResultTests
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
		const string expected = ResultFixture.Failure;
		Result<string, Constellation> actual = new(expected);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberConstructor)]
	public void Constructor_Success_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		Result<string, Constellation> actual = new(expected);
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
		const string expected = ResultFixture.Failure;
		Result<string, Constellation> actual = expected;
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberImplicitOperator)]
	public void ImplicitOperator_Success_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		Result<string, Constellation> actual = expected;
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
		bool status = false;
		Action<Constellation> execute = _ => status = true;
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;
		Result<string, Constellation> actual = ResultMother.Fail()
			.Catch(execute, createFailure);
		Assert.False(status);
		ResultAsserter.CheckIfIsFailed(actual);
	}

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_SuccessfulResultPlusExecutePlusCreateFailure_SuccessfulResult()
	{
		bool status = false;
		Action<Constellation> execute = _ => status = true;
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Catch(execute, createFailure);
		Assert.True(status);
		ResultAsserter.CheckIfIsSuccessful(actual);
	}

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_SuccessfulResultPlusExceptionInExecutePlusCreateFailure_FailedResult()
	{
		Action<Constellation> execute = _ => throw new InvalidOperationException();
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;
		const string expected = "Operation is not valid due to the current state of the object.";
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Catch(execute, createFailure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_FailedResultPlusCreateSuccessPlusCreateFailure_FailedResult()
	{
		Func<Constellation, Constellation> createSuccess = _ => ResultFixture.Success;
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;
		Result<string, Constellation> actual = ResultMother.Fail()
			.Catch(createSuccess, createFailure);
		ResultAsserter.CheckIfIsFailed(actual);
	}

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_SuccessfulResultPlusCreateSuccessPlusCreateFailure_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		Func<Constellation, Constellation> createSuccess = _ => expected;
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Catch(createSuccess, createFailure);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_SuccessfulResultPlusExceptionInCreateSuccessPlusCreateFailure_FailedResult()
	{
		Func<Constellation, Constellation> createSuccess = _ => throw new InvalidOperationException();
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;
		const string expected = "Operation is not valid due to the current state of the object.";
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Catch(createSuccess, createFailure);
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
		const string expected = ResultFixture.Failure;
		Func<Constellation, bool> predicate = _ => true;
		Func<Constellation, string> createFailure = _ => string.Empty;
		Result<string, Constellation> actual = ResultMother.Fail(expected)
			.Ensure(predicate, createFailure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		Func<Constellation, bool> predicate = _ => true;
		const string expected = ResultFixture.Failure;
		Func<Constellation, string> createFailure = _ => expected;
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Ensure(predicate, createFailure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => false;
		Func<Constellation, string> createFailure = _ => ResultFixture.Failure;
		Result<string, Constellation> actual = ResultMother.Succeed(expected)
			.Ensure(predicate, createFailure);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_FailedResultPlusTruePredicatePlusFailure_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<Constellation, bool> predicate = _ => true;
		string failure = string.Empty;
		Result<string, Constellation> actual = ResultMother.Fail(expected)
			.Ensure(predicate, failure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusTruePredicatePlusFailure_FailedResult()
	{
		Func<Constellation, bool> predicate = _ => true;
		const string expected = ResultFixture.Failure;
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Ensure(predicate, expected);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusFalsePredicatePlusFailure_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => false;
		const string failure = ResultFixture.Failure;
		Result<string, Constellation> actual = ResultMother.Succeed(expected)
			.Ensure(predicate, failure);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_FailedResultPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		Func<Constellation, string, string> createFailure = (_, _) => string.Empty;
		Result<string, Constellation> actual = ResultMother.Fail(expected)
			.Ensure(createAuxiliary, predicate, createFailure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		const string expected = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = (_, _) => expected;
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Ensure(createAuxiliary, predicate, createFailure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusCreateAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => false;
		Func<Constellation, string, string> createFailure = (_, _) => ResultFixture.Failure;
		Result<string, Constellation> actual = ResultMother.Succeed(expected)
			.Ensure(createAuxiliary, predicate, createFailure);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_FailedResultPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		Func<Constellation, string, string> createFailure = (_, _) => string.Empty;
		Result<string, Constellation> actual = ResultMother.Fail(expected)
			.Ensure(auxiliary, predicate, createFailure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		const string expected = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = (_, _) => expected;
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Ensure(auxiliary, predicate, createFailure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => false;
		Func<Constellation, string, string> createFailure = (_, _) => ResultFixture.Failure;
		Result<string, Constellation> actual = ResultMother.Succeed(expected)
			.Ensure(auxiliary, predicate, createFailure);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#endregion

	#region DoOnFailure

	[Fact]
	[Trait(@base, memberDoOnFailure)]
	public void DoOnFailure_SuccessfulResultPlusExecute_SuccessfulResult()
	{
		bool status = false;
		Action<string> execute = _ => status = true;
		Result<string, Constellation> actual = ResultMother.Succeed()
			.DoOnFailure(execute);
		Assert.False(status);
		ResultAsserter.CheckIfIsSuccessful(actual);
	}

	[Fact]
	[Trait(@base, memberDoOnFailure)]
	public void DoOnFailure_FailedResultPlusExecute_FailedResult()
	{
		bool status = false;
		Action<string> execute = _ => status = true;
		Result<string, Constellation> actual = ResultMother.Fail()
			.DoOnFailure(execute);
		Assert.True(status);
		ResultAsserter.CheckIfIsFailed(actual);
	}

	#endregion

	#region DoOnSuccess

	[Fact]
	[Trait(@base, memberDoOnSuccess)]
	public void DoOnSuccess_FailedResultPlusExecute_FailedResult()
	{
		bool status = false;
		Action<Constellation> execute = _ => status = true;
		Result<string, Constellation> actual = ResultMother.Fail()
			.DoOnSuccess(execute);
		Assert.False(status);
		ResultAsserter.CheckIfIsFailed(actual);
	}

	[Fact]
	[Trait(@base, memberDoOnSuccess)]
	public void DoOnSuccess_SuccessfulResultPlusExecute_SuccessfulResult()
	{
		bool status = false;
		Action<Constellation> execute = _ => status = true;
		Result<string, Constellation> actual = ResultMother.Succeed()
			.DoOnSuccess(execute);
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
		const string expected = ResultFixture.Failure;
		Func<Constellation, Start> createSuccessToMap = _ => ResultFixture.SuccessToMap;
		Result<string, Start> actual = ResultMother.Fail(expected)
			.Map(createSuccessToMap);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberMap)]
	public void Map_SuccessfulResultPlusCreateSuccessToMap_SuccessfulResult()
	{
		Start expected = ResultFixture.SuccessToMap;
		Func<Constellation, Start> createSuccessToMap = _ => expected;
		Result<string, Start> actual = ResultMother.Succeed()
			.Map(createSuccessToMap);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberMap)]
	public void Map_FailedResultPlusSuccessToMap_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Start successToMap = ResultFixture.SuccessToMap;
		Result<string, Start> actual = ResultMother.Fail(expected)
			.Map(successToMap);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberMap)]
	public void Map_SuccessfulResultPlusSuccessToMap_SuccessfulResult()
	{
		Start expected = ResultFixture.SuccessToMap;
		Result<string, Start> actual = ResultMother.Succeed()
			.Map(expected);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#endregion

	#region Bind

	[Fact]
	[Trait(@base, memberBind)]
	public void Bind_FailedResultPlusCreateResultToBindWithSuccessfulResult_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<Constellation, Result<string, Constellation>> createResultToBind = _ => ResultMother.Succeed();
		Result<string, Constellation> actual = ResultMother.Fail(expected)
			.Bind(createResultToBind);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberBind)]
	public void Bind_SuccessfulResultPlusCreateResultToBindWithFailedResult_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<Constellation, Result<string, Constellation>> createResultToBind = _ => ResultMother.Fail(expected);
		Result<string, Constellation> actual = ResultMother.Succeed()
			.Bind(createResultToBind);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberBind)]
	public void Bind_SuccessfulResultPlusCreateResultToBindWithSuccessfulResult_SuccessfulResult()
	{
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
		Result<string, Constellation> actual = ResultMother.Succeed(success)
			.Bind(createResultToBind);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Reduce

	[Fact]
	[Trait(@base, memberReduce)]
	public void Reduce_FailedResultPlusReduceFailurePlusReduceSuccess_ReducedFailure()
	{
		object expected = ResultFixture.Failure;
		Func<string, object> reduceFailure = _ => expected;
		Func<Constellation, object> reduceSuccess = _ => ResultFixture.Success;
		object actual = ResultMother.Fail()
			.Reduce(reduceFailure, reduceSuccess);
		Assert.Equal(expected, actual);
	}

	[Fact]
	[Trait(@base, memberReduce)]
	public void Reduce_SuccessfulResultPlusReduceFailurePlusReduceSuccess_ReducedSuccess()
	{
		Constellation expected = ResultFixture.Success;
		Func<string, object> reduceFailure = _ => ResultFixture.Failure;
		Func<Constellation, object> reduceSuccess = _ => expected;
		object actual = ResultMother.Succeed()
			.Reduce(reduceFailure, reduceSuccess);
		Assert.Equal(expected, actual);
	}

	#endregion
}
