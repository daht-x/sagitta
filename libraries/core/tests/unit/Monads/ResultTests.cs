// ---------------------------------------------------------------------------------------------------------- 
// Copyright (c) David Andrés Hernández Triana. All rights reserved. 
// Licensed under the MIT License. Please refer to the license file in the project root for more information. 
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests.Monads;

public sealed class ResultTests
{
	private const string @base = nameof(Result<object, object>);

	private const string memberEqualOperator = "==";

	private const string memberNotEqualOperator = "!=";

	private const string memberConstructor = "Constructor";

	private const string memberImplicitOperator = "Implicit operator";

	private const string memberTryGetFailure = nameof(Result<object, object>.TryGetFailure);

	private const string memberTryGetSuccess = nameof(Result<object, object>.TryGetSuccess);

	private const string memberDeconstruct = nameof(Result<object, object>.Deconstruct);

	private const string memberCatch = nameof(Result<object, object>.Catch);

	private const string memberEnsure = nameof(Result<object, object>.Ensure);

	private const string memberDoOnFailure = nameof(Result<object, object>.DoOnFailure);

	private const string memberDoOnSuccess = nameof(Result<object, object>.DoOnSuccess);

	private const string memberMatch = nameof(Result<object, object>.Match);

	private const string memberMap = nameof(Result<object, object>.Map);

	private const string memberBind = nameof(Result<object, object>.Bind);

	private const string memberReduce = nameof(Result<object, object>.Reduce);

	private const string memberReset = nameof(Result<object, object>.Reset);

	private const string memberDiscard = nameof(Result<object, object>.Discard);

	private const string memberEquals = nameof(Result<object, object>.Equals);

	private const string memberGetHashCode = nameof(Result<object, object>.GetHashCode);

	#region ==

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_NullLeftPlusRight_False()
	{
		Result<string, sbyte> left = null!;
		Result<string, sbyte> right = ResultMother.Fail();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_LeftPlusNullRight_False()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		Result<string, sbyte> right = null!;
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_LeftPlusRightWithDifferentStates_False()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		Result<string, sbyte> right = ResultMother.Succeed();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	[SuppressMessage(MaintainabilityAnalysisCategory.Name, MaintainabilityAnalysisCategory.Rules.AvoidDeadConditionalCode)]
	public void EqualOperator_LeftPlusRightWithNulls_True()
	{
		Result<string, sbyte> left = null!;
		Result<string, sbyte> right = null!;
		bool actual = left == right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_LeftPlusRightWithEqualStates_True()
	{
		Result<string, sbyte> left = ResultMother.Succeed();
		Result<string, sbyte> right = ResultMother.Succeed();
		bool actual = left == right;
		Assert.True(actual);
	}

	#endregion ==

	#region !=

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_LeftPlusRightWithEqualStates_False()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		Result<string, sbyte> right = ResultMother.Fail();
		bool actual = left != right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	[SuppressMessage(MaintainabilityAnalysisCategory.Name, MaintainabilityAnalysisCategory.Rules.AvoidDeadConditionalCode)]
	public void NotEqualOperator_LeftPlusRightWithNulls_False()
	{
		Result<string, sbyte> left = null!;
		Result<string, sbyte> right = null!;
		bool actual = left != right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_LeftPlusRightWithDifferentStates_True()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		Result<string, sbyte> right = ResultMother.Succeed();
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_LeftPlusNullRight_True()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		Result<string, sbyte> right = null!;
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_NullLeftPlusRight_True()
	{
		Result<string, sbyte> left = null!;
		Result<string, sbyte> right = ResultMother.Fail();
		bool actual = left != right;
		Assert.True(actual);
	}

	#endregion !=

	#region Constructor

	#region Constructor overload

	[Fact]
	[Trait(@base, memberConstructor)]
	public void Constructor_Failure_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Result<string, sbyte> actual = new(expected);
		ResultAsserter.IsFailed(expected, actual);
	}

	#endregion Constructor overload

	#region Constructor overload

	[Fact]
	[Trait(@base, memberConstructor)]
	public void Constructor_Success_SuccessfulResult()
	{
		const sbyte expected = ResultFixture.Success;
		Result<string, sbyte> actual = new(expected);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Constructor overload

	#endregion Constructor

	#region Implicit operator

	#region Implicit operator overload

	[Fact]
	[Trait(@base, memberImplicitOperator)]
	public void ImplicitOperator_Failure_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Result<string, sbyte> actual = expected;
		ResultAsserter.IsFailed(expected, actual);
	}

	#endregion Implicit operator overload

	#region Implicit operator overload

	[Fact]
	[Trait(@base, memberImplicitOperator)]
	public void ImplicitOperator_Success_SuccessfulResult()
	{
		const sbyte expected = ResultFixture.Success;
		Result<string, sbyte> actual = expected;
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Implicit operator overload

	#endregion Implicit operator

	#region Deconstruct

	[Fact]
	[Trait(@base, memberDeconstruct)]
	public void Deconstruct_FailedResult_FailedStates()
	{
		const string expectedFailure = ResultFixture.Failure;
		(bool isFailed, string? failure, sbyte success) = ResultMother.Fail(expectedFailure);
		Assert.True(isFailed);
		Assert.Equal(expectedFailure, failure);
		Assert.Equal(default, success);
	}

	[Fact]
	[Trait(@base, memberDeconstruct)]
	public void Deconstruct_SuccessfulResult_SuccessfulStates()
	{
		const sbyte expectedSuccess = ResultFixture.Success;
		(bool isFailed, string? failure, sbyte success) = ResultMother.Succeed(expectedSuccess);
		Assert.False(isFailed);
		Assert.Null(failure);
		Assert.Equal(expectedSuccess, success);
	}

	#endregion Deconstruct

	#region TryGetFailure

	[Fact]
	[Trait(@base, memberTryGetFailure)]
	public void TryGetFailure_SuccessfulResult_False()
	{
		Result<string, sbyte> actual = ResultMother.Succeed();
		bool status = actual.TryGetFailure(out string? output);
		Assert.False(status);
		Assert.Null(output);
	}

	[Fact]
	[Trait(@base, memberTryGetFailure)]
	public void TryGetFailure_FailedResult_True()
	{
		const string expected = ResultFixture.Failure;
		Result<string, sbyte> actual = ResultMother.Fail(expected);
		bool status = actual.TryGetFailure(out string? output);
		Assert.True(status);
		Assert.Equal(expected, output);
	}

	#endregion TryGetFailure

	#region TryGetSuccess

	[Fact]
	[Trait(@base, memberTryGetSuccess)]
	public void TryGetSuccess_FailedResult_False()
	{
		Result<string, sbyte> actual = ResultMother.Fail();
		bool status = actual.TryGetSuccess(out sbyte output);
		Assert.False(status);
		Assert.Equal(default, output);
	}

	[Fact]
	[Trait(@base, memberTryGetSuccess)]
	public void TryGetSuccess_SuccessfulResult_True()
	{
		const sbyte expected = ResultFixture.Success;
		Result<string, sbyte> actual = ResultMother.Succeed(expected);
		bool status = actual.TryGetSuccess(out sbyte output);
		Assert.True(status);
		Assert.Equal(expected, output);
	}

	#endregion TryGetSuccess

	#region Catch

	#region Catch overload

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_FailedResultPlusExecutePlusCreateFailure_FailedResult()
	{
		bool status = false;
		Action<sbyte> execute = _ => status = true;
		Func<ProofOfConceptException, string> createFailure = static exception => exception.Message;
		Result<string, sbyte> actual = ResultMother.Fail()
			.Catch(execute, createFailure);
		Assert.False(status);
		ResultAsserter.IsFailed(ResultFixture.Failure, actual);
	}

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_SuccessfulResultPlusExecutePlusCreateFailure_SuccessfulResult()
	{
		bool status = false;
		Action<sbyte> execute = _ => status = true;
		Func<ProofOfConceptException, string> createFailure = static exception => exception.Message;
		Result<string, sbyte> actual = ResultMother.Succeed()
			.Catch(execute, createFailure);
		Assert.True(status);
		ResultAsserter.IsSuccessful(ResultFixture.Success, actual);
	}

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_SuccessfulResultPlusExceptionInExecutePlusCreateFailure_FailedResult()
	{
		Action<sbyte> execute = static _ => ProofOfConceptException.Throw();
		Func<ProofOfConceptException, string> createFailure = static exception => exception.Message;
		const string expected = ProofOfConceptException.DefaultMessage;
		Result<string, sbyte> actual = ResultMother.Succeed()
			.Catch(execute, createFailure);
		ResultAsserter.IsFailed(expected, actual);
	}

	#endregion Catch overload

	#region Catch overload

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_FailedResultPlusCreateSuccessPlusCreateFailure_FailedResult()
	{
		Func<sbyte, sbyte> createSuccess = static _ => ResultFixture.Success;
		Func<ProofOfConceptException, string> createFailure = static exception => exception.Message;
		Result<string, sbyte> actual = ResultMother.Fail()
			.Catch(createSuccess, createFailure);
		ResultAsserter.IsFailed(ResultFixture.Failure, actual);
	}

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_SuccessfulResultPlusCreateSuccessPlusCreateFailure_SuccessfulResult()
	{
		const sbyte expected = ResultFixture.Success;
		Func<sbyte, sbyte> createSuccess = static _ => expected;
		Func<ProofOfConceptException, string> createFailure = static exception => exception.Message;
		Result<string, sbyte> actual = ResultMother.Succeed()
			.Catch(createSuccess, createFailure);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_SuccessfulResultPlusExceptionInCreateSuccessPlusCreateFailure_FailedResult()
	{
		Func<sbyte, sbyte> createSuccess = static _ => throw new ProofOfConceptException();
		Func<ProofOfConceptException, string> createFailure = static exception => exception.Message;
		const string expected = ProofOfConceptException.DefaultMessage;
		Result<string, sbyte> actual = ResultMother.Succeed()
			.Catch(createSuccess, createFailure);
		ResultAsserter.IsFailed(expected, actual);
	}

	#endregion Catch overload

	#endregion Catch

	#region Ensure

	#region Ensure overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_FailedResultPlusTruePredicatePlusFailure_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<sbyte, bool> predicate = static _ => true;
		string failure = string.Empty;
		Result<string, sbyte> actual = ResultMother.Fail(expected)
			.Ensure(predicate, failure);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusTruePredicatePlusFailure_FailedResult()
	{
		Func<sbyte, bool> predicate = static _ => true;
		const string expected = ResultFixture.Failure;
		Result<string, sbyte> actual = ResultMother.Succeed()
			.Ensure(predicate, expected);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusFalsePredicatePlusFailure_SuccessfulResult()
	{
		const sbyte expected = ResultFixture.Success;
		Func<sbyte, bool> predicate = static _ => false;
		const string failure = ResultFixture.Failure;
		Result<string, sbyte> actual = ResultMother.Succeed(expected)
			.Ensure(predicate, failure);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Ensure overload

	#region Ensure overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_FailedResultPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<sbyte, bool> predicate = static _ => true;
		Func<sbyte, string> createFailure = static _ => string.Empty;
		Result<string, sbyte> actual = ResultMother.Fail(expected)
			.Ensure(predicate, createFailure);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		Func<sbyte, bool> predicate = static _ => true;
		const string expected = ResultFixture.Failure;
		Func<sbyte, string> createFailure = static _ => expected;
		Result<string, sbyte> actual = ResultMother.Succeed()
			.Ensure(predicate, createFailure);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		const sbyte expected = ResultFixture.Success;
		Func<sbyte, bool> predicate = static _ => false;
		Func<sbyte, string> createFailure = static _ => ResultFixture.Failure;
		Result<string, sbyte> actual = ResultMother.Succeed(expected)
			.Ensure(predicate, createFailure);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Ensure overload

	#region Ensure overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_FailedResultPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		const char auxiliary = ResultFixture.Auxiliary;
		Func<sbyte, char, bool> predicate = static (_, _) => true;
		Func<sbyte, char, string> createFailure = static (_, _) => string.Empty;
		Result<string, sbyte> actual = ResultMother.Fail(expected)
			.Ensure(auxiliary, predicate, createFailure);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		const char auxiliary = ResultFixture.Auxiliary;
		Func<sbyte, char, bool> predicate = static (_, _) => true;
		const string expected = ResultFixture.Failure;
		Func<sbyte, char, string> createFailure = static (_, _) => expected;
		Result<string, sbyte> actual = ResultMother.Succeed()
			.Ensure(auxiliary, predicate, createFailure);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		const sbyte expected = ResultFixture.Success;
		const char auxiliary = ResultFixture.Auxiliary;
		Func<sbyte, char, bool> predicate = static (_, _) => false;
		Func<sbyte, char, string> createFailure = static (_, _) => ResultFixture.Failure;
		Result<string, sbyte> actual = ResultMother.Succeed(expected)
			.Ensure(auxiliary, predicate, createFailure);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Ensure overload

	#region Ensure overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_FailedResultPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<char> createAuxiliary = static () => ResultFixture.Auxiliary;
		Func<sbyte, char, bool> predicate = static (_, _) => true;
		Func<sbyte, char, string> createFailure = static (_, _) => string.Empty;
		Result<string, sbyte> actual = ResultMother.Fail(expected)
			.Ensure(createAuxiliary, predicate, createFailure);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		Func<char> createAuxiliary = static () => ResultFixture.Auxiliary;
		Func<sbyte, char, bool> predicate = static (_, _) => true;
		const string expected = ResultFixture.Failure;
		Func<sbyte, char, string> createFailure = static (_, _) => expected;
		Result<string, sbyte> actual = ResultMother.Succeed()
			.Ensure(createAuxiliary, predicate, createFailure);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessfulResultPlusCreateAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		const sbyte expected = ResultFixture.Success;
		Func<char> createAuxiliary = static () => ResultFixture.Auxiliary;
		Func<sbyte, char, bool> predicate = static (_, _) => false;
		Func<sbyte, char, string> createFailure = static (_, _) => ResultFixture.Failure;
		Result<string, sbyte> actual = ResultMother.Succeed(expected)
			.Ensure(createAuxiliary, predicate, createFailure);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Ensure overload

	#endregion Ensure

	#region DoOnFailure

	#region DoOnFailure overload

	[Fact]
	[Trait(@base, memberDoOnFailure)]
	public void DoOnFailure_SuccessfulResultPlusExecute_SuccessfulResult()
	{
		bool status = false;
		Action execute = () => status = true;
		Result<string, sbyte> actual = ResultMother.Succeed()
			.DoOnFailure(execute);
		Assert.False(status);
		ResultAsserter.IsSuccessful(ResultFixture.Success, actual);
	}

	[Fact]
	[Trait(@base, memberDoOnFailure)]
	public void DoOnFailure_FailedResultPlusExecute_FailedResult()
	{
		bool status = false;
		Action execute = () => status = true;
		Result<string, sbyte> actual = ResultMother.Fail()
			.DoOnFailure(execute);
		Assert.True(status);
		ResultAsserter.IsFailed(ResultFixture.Failure, actual);
	}

	#endregion DoOnFailure overload

	#region DoOnFailure overload

	[Fact]
	[Trait(@base, memberDoOnFailure)]
	public void DoOnFailure_SuccessfulResultPlusExecuteWithFailure_SuccessfulResult()
	{
		bool status = false;
		Action<string> execute = _ => status = true;
		Result<string, sbyte> actual = ResultMother.Succeed()
			.DoOnFailure(execute);
		Assert.False(status);
		ResultAsserter.IsSuccessful(ResultFixture.Success, actual);
	}

	[Fact]
	[Trait(@base, memberDoOnFailure)]
	public void DoOnFailure_FailedResultPlusExecuteWithFailure_FailedResult()
	{
		bool status = false;
		Action<string> execute = _ => status = true;
		Result<string, sbyte> actual = ResultMother.Fail()
			.DoOnFailure(execute);
		Assert.True(status);
		ResultAsserter.IsFailed(ResultFixture.Failure, actual);
	}

	#endregion DoOnFailure overload

	#endregion DoOnFailure

	#region DoOnSuccess

	#region DoOnSuccess overload

	[Fact]
	[Trait(@base, memberDoOnSuccess)]
	public void DoOnSuccess_FailedResultPlusExecute_FailedResult()
	{
		bool status = false;
		Action execute = () => status = true;
		Result<string, sbyte> actual = ResultMother.Fail()
			.DoOnSuccess(execute);
		Assert.False(status);
		ResultAsserter.IsFailed(ResultFixture.Failure, actual);
	}

	[Fact]
	[Trait(@base, memberDoOnSuccess)]
	public void DoOnSuccess_SuccessfulResultPlusExecute_SuccessfulResult()
	{
		bool status = false;
		Action execute = () => status = true;
		Result<string, sbyte> actual = ResultMother.Succeed()
			.DoOnSuccess(execute);
		Assert.True(status);
		ResultAsserter.IsSuccessful(ResultFixture.Success, actual);
	}

	#endregion DoOnSuccess overload

	#region DoOnSuccess overload

	[Fact]
	[Trait(@base, memberDoOnSuccess)]
	public void DoOnSuccess_FailedResultPlusExecuteWithSuccess_FailedResult()
	{
		bool status = false;
		Action<sbyte> execute = _ => status = true;
		Result<string, sbyte> actual = ResultMother.Fail()
			.DoOnSuccess(execute);
		Assert.False(status);
		ResultAsserter.IsFailed(ResultFixture.Failure, actual);
	}

	[Fact]
	[Trait(@base, memberDoOnSuccess)]
	public void DoOnSuccess_SuccessfulResultPlusExecuteWithSuccess_SuccessfulResult()
	{
		bool status = false;
		Action<sbyte> execute = _ => status = true;
		Result<string, sbyte> actual = ResultMother.Succeed()
			.DoOnSuccess(execute);
		Assert.True(status);
		ResultAsserter.IsSuccessful(ResultFixture.Success, actual);
	}

	#endregion DoOnSuccess overload

	#endregion DoOnSuccess

	#region Match

	#region Match overload

	[Fact]
	[Trait(@base, memberMatch)]
	public void Match_FailedResultPlusDoOnFailurePlusDoOnSuccess_FailedResult()
	{
		bool status = false;
		Action doOnFailure = () => status = true;
		Action doOnSuccess = () => status = false;
		Result<string, sbyte> actual = ResultMother.Fail()
			.Match(doOnFailure, doOnSuccess);
		Assert.True(status);
		ResultAsserter.IsFailed(ResultFixture.Failure, actual);
	}

	[Fact]
	[Trait(@base, memberMatch)]
	public void Match_SuccessfulResultPlusDoOnFailurePlusDoOnSuccess_SuccessfulResult()
	{
		bool status = false;
		Action doOnFailure = () => status = false;
		Action doOnSuccess = () => status = true;
		Result<string, sbyte> actual = ResultMother.Succeed()
			.Match(doOnFailure, doOnSuccess);
		Assert.True(status);
		ResultAsserter.IsSuccessful(ResultFixture.Success, actual);
	}

	#endregion Match overload

	#region Match overload

	[Fact]
	[Trait(@base, memberMatch)]
	public void Match_FailedResultPlusDoOnFailureWithFailurePlusDoOnSuccessWithSuccess_FailedResult()
	{
		bool status = false;
		Action<string> doOnFailure = _ => status = true;
		Action<sbyte> doOnSuccess = _ => status = false;
		Result<string, sbyte> actual = ResultMother.Fail()
			.Match(doOnFailure, doOnSuccess);
		Assert.True(status);
		ResultAsserter.IsFailed(ResultFixture.Failure, actual);
	}

	[Fact]
	[Trait(@base, memberMatch)]
	public void Match_SuccessfulResultPlusDoOnFailureWithFailurePlusDoOnSuccessWithSuccess_SuccessfulResult()
	{
		bool status = false;
		Action<string> doOnFailure = _ => status = false;
		Action<sbyte> doOnSuccess = _ => status = true;
		Result<string, sbyte> actual = ResultMother.Succeed()
			.Match(doOnFailure, doOnSuccess);
		Assert.True(status);
		ResultAsserter.IsSuccessful(ResultFixture.Success, actual);
	}

	#endregion Match overload

	#endregion Match

	#region Map

	#region Map overload

	[Fact]
	[Trait(@base, memberMap)]
	public void Map_FailedResultPlusSuccessToMap_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		const short successToMap = ResultFixture.SuccessToMap;
		Result<string, short> actual = ResultMother.Fail(expected)
			.Map(successToMap);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberMap)]
	public void Map_SuccessfulResultPlusSuccessToMap_SuccessfulResult()
	{
		const short expected = ResultFixture.SuccessToMap;
		Result<string, short> actual = ResultMother.Succeed()
			.Map(expected);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Map overload

	#region Map overload

	[Fact]
	[Trait(@base, memberMap)]
	public void Map_FailedResultPlusCreateSuccessToMap_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<sbyte, short> createSuccessToMap = static _ => ResultFixture.SuccessToMap;
		Result<string, short> actual = ResultMother.Fail(expected)
			.Map(createSuccessToMap);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberMap)]
	public void Map_SuccessfulResultPlusCreateSuccessToMap_SuccessfulResult()
	{
		const short expected = ResultFixture.SuccessToMap;
		Func<sbyte, short> createSuccessToMap = static _ => expected;
		Result<string, short> actual = ResultMother.Succeed()
			.Map(createSuccessToMap);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Map overload

	#endregion Map

	#region Bind

	[Fact]
	[Trait(@base, memberBind)]
	public void Bind_FailedResultPlusCreateResultToBindWithSuccessfulResult_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<sbyte, Result<string, sbyte>> createResultToBind = static _ => ResultMother.Succeed();
		Result<string, sbyte> actual = ResultMother.Fail(expected)
			.Bind(createResultToBind);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberBind)]
	public void Bind_SuccessfulResultPlusCreateResultToBindWithFailedResult_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<sbyte, Result<string, sbyte>> createResultToBind = static _ => ResultMother.Fail(expected);
		Result<string, sbyte> actual = ResultMother.Succeed()
			.Bind(createResultToBind);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberBind)]
	public void Bind_SuccessfulResultPlusCreateResultToBindWithSuccessfulResult_SuccessfulResult()
	{
		const sbyte success = ResultFixture.SuccessToBind;
		const sbyte expected = ResultFixture.Success;
		Func<sbyte, Result<string, sbyte>> createResultToBind = static _ => ResultMother.Succeed(expected);
		Result<string, sbyte> actual = ResultMother.Succeed(success)
			.Bind(createResultToBind);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Bind

	#region Reset

	[Fact]
	[Trait(@base, memberReset)]
	public void Reset_FailedResultPlusInitializerResult_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Result<string, short> initializerResult = new(ResultFixture.SuccessToInitialize);
		Result<string, short> actual = ResultMother.Fail(expected)
			.Reset(initializerResult);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberReset)]
	public void Reset_SuccessfulResultPlusInitializerResult_SuccessfulResult()
	{
		const short expected = ResultFixture.SuccessToInitialize;
		Result<string, short> initializerResult = new(expected);
		Result<string, short> actual = ResultMother.Succeed()
			.Reset(initializerResult);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Reset

	#region Discard

	[Fact]
	[Trait(@base, memberDiscard)]
	public void Discard_FailedResult_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Result<string, Unit> actual = ResultMother.Fail(expected)
			.Discard();
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberDiscard)]
	public void Discard_SuccessfulResult_Unit()
	{
		Unit expected = Unit.Default;
		Result<string, Unit> actual = ResultMother.Succeed(ResultFixture.Success)
			.Discard();
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Discard

	#region Reduce

	[Fact]
	[Trait(@base, memberReduce)]
	public void Reduce_FailedResultPlusReduceFailurePlusReduceSuccess_ReducedFailure()
	{
		object expected = ResultFixture.Failure;
		Func<string, object> reduceFailure = _ => expected;
		Func<sbyte, object> reduceSuccess = static _ => ResultFixture.Success;
		object actual = ResultMother.Fail()
			.Reduce(reduceFailure, reduceSuccess);
		Assert.Equal(expected, actual);
	}

	[Fact]
	[Trait(@base, memberReduce)]
	public void Reduce_SuccessfulResultPlusReduceFailurePlusReduceSuccess_ReducedSuccess()
	{
		const sbyte expected = ResultFixture.Success;
		Func<string, object> reduceFailure = static _ => ResultFixture.Failure;
		Func<sbyte, object> reduceSuccess = static _ => expected;
		object actual = ResultMother.Succeed()
			.Reduce(reduceFailure, reduceSuccess);
		Assert.Equal(expected, actual);
	}

	#endregion Reduce

	#region Equals

	#region Equals overload

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_LeftPlusNullObj_False()
	{
		Result<string, sbyte> current = ResultMother.Fail();
		object obj = null!;
		bool actual = current.Equals(obj);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_LeftPlusObjWithDifferentStates_False()
	{
		Result<string, sbyte> current = ResultMother.Fail();
		object obj = ResultMother.Succeed();
		bool actual = current.Equals(obj);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_LeftFailedPlusObjFailed_True()
	{

		Result<string, sbyte> current = ResultMother.Fail();
		object obj = ResultMother.Fail();
		bool actual = current.Equals(obj);
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_LeftSuccessfulPlusObjSuccessful_True()
	{
		Result<string, sbyte> current = ResultMother.Succeed();
		object obj = ResultMother.Succeed();
		bool actual = current.Equals(obj);
		Assert.True(actual);
	}

	#endregion Equals overload

	#region Equals overload

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_LeftPlusNullRight_False()
	{
		Result<string, sbyte> current = ResultMother.Fail();
		Result<string, sbyte> other = null!;
		bool actual = current.Equals(other);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_LeftPlusRightWithDifferentStates_False()
	{
		Result<string, sbyte> current = ResultMother.Fail();
		Result<string, sbyte> other = ResultMother.Succeed();
		bool actual = current.Equals(other);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_LeftFailedPlusRightFailed_True()
	{
		Result<string, sbyte> current = ResultMother.Fail();
		Result<string, sbyte> other = ResultMother.Fail();
		bool actual = current.Equals(other);
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_LeftSuccessfulPlusRightSuccessful_True()
	{
		Result<string, sbyte> current = ResultMother.Succeed();
		Result<string, sbyte> other = ResultMother.Succeed();
		bool actual = current.Equals(other);
		Assert.True(actual);
	}

	#endregion Equals overload

	#endregion Equals

	#region GetHashCode

	[Fact]
	[Trait(@base, memberGetHashCode)]
	public void GetHashCode_ResultsWithDifferentStates_DifferentHashCodes()
	{
		int expected = ResultMother.Succeed()
			.GetHashCode();
		int actual = ResultMother.Fail()
			.GetHashCode();
		Assert.NotEqual(expected, actual);
	}

	[Fact]
	[Trait(@base, memberGetHashCode)]
	public void GetHashCode_ResultsWithEqualStates_EqualHashCodes()
	{
		int expected = ResultMother.Succeed()
			.GetHashCode();
		int actual = ResultMother.Succeed()
			.GetHashCode();
		Assert.Equal(expected, actual);
	}

	#endregion GetHashCode
}
