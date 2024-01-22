namespace Daht.Sagitta.Core.UnitTest.Monads;

public sealed class ResultTest
{
	private const string root = nameof(Result<object, object>);

	private const string constructor = "Constructor";

	private const string implicitOperator = "Implicit Operator";

	private const string ensure = nameof(Result<object, object>.Ensure);

	private const string doOnSuccess = nameof(Result<object, object>.DoOnSuccess);

	private const string map = nameof(Result<object, object>.Map);

	private const string bind = nameof(Result<object, object>.Bind);

	private const string reduce = nameof(Result<object, object>.Reduce);

	#region Constructor

	#region Overload

	[Fact]
	[Trait(root, constructor)]
	public void Constructor_Success_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;

		// Act
		Result<Constellation, string> actualResult = new(expectedSuccess);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, constructor)]
	public void Constructor_Failure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = new(expectedFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#endregion

	#region Implicit Operator

	#region Overload

	[Fact]
	[Trait(root, implicitOperator)]
	public void ImplicitOperator_Success_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;

		// Act
		Result<Constellation, string> actualResult = expectedSuccess;

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, implicitOperator)]
	public void ImplicitOperator_Failure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = expectedFailure;

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#endregion

	#region Ensure

	#region Overload

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_FailedResultPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, bool> predicate = static _ => true;
		Func<Constellation, string> createFailure = static _ => ResultFixture.RandomFailure;

		// Act
		Result<Constellation, string> actualResult = ResultMother.Fail(expectedFailure)
			.Ensure(predicate, createFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessfulResultPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<Constellation, bool> predicate = static _ => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string> createFailure = static _ => expectedFailure;

		// Act
		Result<Constellation, string> actualResult = ResultMother.Succeed()
			.Ensure(predicate, createFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessfulResultPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation, bool> predicate = static _ => false;
		Func<Constellation, string> createFailure = static _ => ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultMother.Succeed(expectedSuccess)
			.Ensure(predicate, createFailure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_FailedResultPlusTruePredicatePlusFailure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, bool> predicate = static _ => true;
		string failure = ResultFixture.RandomFailure;

		// Act
		Result<Constellation, string> actualResult = ResultMother.Fail(expectedFailure)
			.Ensure(predicate, failure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessfulResultPlusTruePredicatePlusFailure_FailedResult()
	{
		// Arrange
		Func<Constellation, bool> predicate = static _ => true;
		const string expectedFailure = ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultMother.Succeed()
			.Ensure(predicate, expectedFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessfulResultPlusFalsePredicatePlusFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation, bool> predicate = static _ => false;
		const string failure = ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultMother.Succeed(expectedSuccess)
			.Ensure(predicate, failure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_FailedResultPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<string> createAuxiliary = static () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = static (_, _) => true;
		Func<Constellation, string, string> createFailure = static (_, _) => ResultFixture.RandomFailure;

		// Act
		Result<Constellation, string> actualResult = ResultMother.Fail(expectedFailure)
			.Ensure(createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessfulResultPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Func<string> createAuxiliary = static () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = static (_, _) => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = static (_, _) => expectedFailure;

		// Act
		Result<Constellation, string> actualResult = ResultMother.Succeed()
			.Ensure(createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessfulResultPlusCreateAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<string> createAuxiliary = static () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = static (_, _) => false;
		Func<Constellation, string, string> createFailure = static (_, _) => ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultMother.Succeed(expectedSuccess)
			.Ensure(createAuxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_FailedResultPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = static (_, _) => true;
		Func<Constellation, string, string> createFailure = static (_, _) => ResultFixture.RandomFailure;

		// Act
		Result<Constellation, string> actualResult = ResultMother.Fail(expectedFailure)
			.Ensure(auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessfulResultPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = static (_, _) => true;
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = static (_, _) => expectedFailure;

		// Act
		Result<Constellation, string> actualResult = ResultMother.Succeed()
			.Ensure(auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessfulResultPlusAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = static (_, _) => false;
		Func<Constellation, string, string> createFailure = static (_, _) => ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultMother.Succeed(expectedSuccess)
			.Ensure(auxiliary, predicate, createFailure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#endregion

	#region DoOnSuccess

	[Fact]
	[Trait(root, doOnSuccess)]
	public void DoOnSuccess_FailedResultPlusExecute_FailedResult()
	{
		// Arrange
		bool status = false;
		Action<Constellation> execute = _ => status = true;

		// Act
		Result<Constellation, string> actualResult = ResultMother.Fail()
			.DoOnSuccess(execute);

		// Assert
		Assert.False(status);
		ResultAsserter.IsFailed(actualResult);
	}

	[Fact]
	[Trait(root, doOnSuccess)]
	public void DoOnSuccess_SuccessfulResultPlusExecute_SuccessfulResult()
	{
		// Arrange
		bool status = false;
		Action<Constellation> execute = _ => status = true;

		// Act
		Result<Constellation, string> actualResult = ResultMother.Succeed()
			.DoOnSuccess(execute);

		// Assert
		Assert.True(status);
		ResultAsserter.IsSuccessful(actualResult);
	}

	#endregion

	#region Map

	#region Overload

	[Fact]
	[Trait(root, map)]
	public void Map_FailedResultPlusCreateSuccessToMap_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, Start> createSuccessToMap = static _ => ResultFixture.SuccessToMap;

		// Act
		Result<Start, string> actualResult = ResultMother.Fail(expectedFailure)
			.Map(createSuccessToMap);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, map)]
	public void Map_SuccessfulResultPlusCreateSuccessToMap_SuccessfulResult()
	{
		// Arrange
		Start expectedSuccess = ResultFixture.SuccessToMap;
		Func<Constellation, Start> createSuccessToMap = _ => expectedSuccess;

		// Act
		Result<Start, string> actualResult = ResultMother.Succeed()
			.Map(createSuccessToMap);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, map)]
	public void Map_FailedResultPlusSuccessToMap_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Start successToMap = ResultFixture.SuccessToMap;

		// Act
		Result<Start, string> actualResult = ResultMother.Fail(expectedFailure)
			.Map(successToMap);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, map)]
	public void Map_SuccessfulResultPlusSuccessToMap_SuccessfulResult()
	{
		// Arrange
		Start expectedSuccess = ResultFixture.SuccessToMap;

		// Act
		Result<Start, string> actualResult = ResultMother.Succeed()
			.Map(expectedSuccess);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#endregion

	#region Bind

	[Fact]
	[Trait(root, bind)]
	public void Bind_FailedResultPlusCreateResultToBindWithSuccessfulResult_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, Result<Constellation, string>> createResultToBind = static _ => ResultMother.Succeed();

		// Act
		Result<Constellation, string> actualResult = ResultMother.Fail(expectedFailure)
			.Bind(createResultToBind);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, bind)]
	public void Bind_SuccessfulResultPlusCreateResultToBindWithFailedResult_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, Result<Constellation, string>> createResultToBind = static _ => ResultMother.Fail(expectedFailure);

		// Act
		Result<Constellation, string> actualResult = ResultMother.Succeed()
			.Bind(createResultToBind);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, bind)]
	public void Bind_SuccessfulResultPlusCreateResultToBindWithSuccessfulResult_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation, Result<Constellation, string>> createResultToBind = _ => ResultMother.Succeed(expectedSuccess);

		// Act
		Result<Constellation, string> actualResult = ResultMother.SucceedRandomly()
			.Bind(createResultToBind);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Reduce

	[Fact]
	[Trait(root, reduce)]
	public void Reduce_FailedResultPlusCreateReducedSuccessPlusCreateReducedFailure_ReducedFailure()
	{
		// Arrange
		object expectedReduction = ResultFixture.Failure;
		Func<Constellation, object> createReducedSuccess = static _ => ResultFixture.Success;
		Func<string, object> createReducedFailure = _ => expectedReduction;

		// Act
		object actualReduction = ResultMother.Fail()
			.Reduce(createReducedSuccess, createReducedFailure);

		// Assert
		Assert.Equal(expectedReduction, actualReduction);
	}

	[Fact]
	[Trait(root, reduce)]
	public void Reduce_SuccessfulResultPlusCreateReducedSuccessPlusCreateReducedFailure_ReducedSuccess()
	{
		// Arrange
		Constellation expectedReduction = ResultFixture.Success;
		Func<Constellation, object> createReducedSuccess = _ => expectedReduction;
		Func<string, object> createReducedFailure = static _ => ResultFixture.Failure;

		// Act
		object actualReduction = ResultMother.Succeed()
			.Reduce(createReducedSuccess, createReducedFailure);

		// Assert
		Assert.Equal(expectedReduction, actualReduction);
	}

	#endregion
}
