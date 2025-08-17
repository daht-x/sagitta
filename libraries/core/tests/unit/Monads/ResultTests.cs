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

	private const string memberMapFailure = nameof(Result<object, object>.MapFailure);

	private const string memberMapSuccess = nameof(Result<object, object>.MapSuccess);

	private const string memberBind = nameof(Result<object, object>.Bind);

	private const string memberReduce = nameof(Result<object, object>.Reduce);

	private const string memberReset = nameof(Result<object, object>.Reset);

	private const string memberDiscard = nameof(Result<object, object>.Discard);

	private const string memberEquals = nameof(Result<object, object>.Equals);

	private const string memberGetHashCode = nameof(Result<object, object>.GetHashCode);

	private const string memberToString = nameof(Result<object, object>.ToString);

	#region ==

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_NullLeftAndFailedRight_False()
	{
		Result<string, sbyte> left = null!;
		Result<string, sbyte> right = ResultMother.Fail();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_FailedLeftAndNullRight_False()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		Result<string, sbyte> right = null!;
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_NullLeftAndSuccessfulRight_False()
	{
		Result<string, sbyte> left = null!;
		Result<string, sbyte> right = ResultMother.Succeed();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_SuccessfulLeftAndNullRight_False()
	{
		Result<string, sbyte> left = ResultMother.Succeed();
		Result<string, sbyte> right = null!;
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_FailedLeftAndSuccessfulRight_False()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		Result<string, sbyte> right = ResultMother.Succeed();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_SuccessfulLeftAndFailedRight_False()
	{
		Result<string, sbyte> left = ResultMother.Succeed();
		Result<string, sbyte> right = ResultMother.Fail();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_DifferentFailedLeftAndDifferentFailedRight_False()
	{
		Result<string, sbyte> left = ResultMother.FailRandomly();
		Result<string, sbyte> right = ResultMother.FailRandomly();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_DifferentSuccessfulLeftAndDifferentSuccessfulRight_False()
	{
		Result<string, sbyte> left = ResultMother.Succeed(1);
		Result<string, sbyte> right = ResultMother.Succeed(2);
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	[SuppressMessage(
		MaintainabilityAnalysisCategory.Name,
		MaintainabilityAnalysisCategory.Rules.AvoidDeadConditionalCode
	)]
	public void EqualOperator_NullLeftAndNullRight_True()
	{
		Result<string, sbyte> left = null!;
		Result<string, sbyte> right = null!;
		bool actual = left == right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_FailedLeftAndFailedRight_True()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		Result<string, sbyte> right = ResultMother.Fail();
		bool actual = left == right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_SuccessfulLeftAndSuccessfulRight_True()
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
	public void NotEqualOperator_SuccessfulLeftAndSuccessfulRight_False()
	{
		Result<string, sbyte> left = ResultMother.Succeed();
		Result<string, sbyte> right = ResultMother.Succeed();
		bool actual = left != right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_FailedLeftAndFailedRight_False()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		Result<string, sbyte> right = ResultMother.Fail();
		bool actual = left != right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	[SuppressMessage(
		MaintainabilityAnalysisCategory.Name,
		MaintainabilityAnalysisCategory.Rules.AvoidDeadConditionalCode
	)]
	public void NotEqualOperator_NullLeftAndNullRight_False()
	{
		Result<string, sbyte> left = null!;
		Result<string, sbyte> right = null!;
		bool actual = left != right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_DifferentSuccessfulLeftAndDifferentSuccessfulRight_True()
	{
		Result<string, sbyte> left = ResultMother.Succeed(1);
		Result<string, sbyte> right = ResultMother.Succeed(2);
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_DifferentFailedLeftAndDifferentFailedRight_True()
	{
		Result<string, sbyte> left = ResultMother.FailRandomly();
		Result<string, sbyte> right = ResultMother.FailRandomly();
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_SuccessfulLeftAndFailedRight_True()
	{
		Result<string, sbyte> left = ResultMother.Succeed();
		Result<string, sbyte> right = ResultMother.Fail();
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_FailedLeftAndSuccessfulRight_True()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		Result<string, sbyte> right = ResultMother.Succeed();
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_SuccessfulLeftAndNullRight_True()
	{
		Result<string, sbyte> left = ResultMother.Succeed();
		Result<string, sbyte> right = null!;
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_NullLeftAndSuccessfulRight_True()
	{
		Result<string, sbyte> left = null!;
		Result<string, sbyte> right = ResultMother.Succeed();
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_FailedLeftAndNullRight_True()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		Result<string, sbyte> right = null!;
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_NullLeftAndFailedRight_True()
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

	#region MapFailure

	[Fact]
	[Trait(@base, memberMapFailure)]
	public void MapFailure_SuccessfulResultPlusCreate_SuccessfulResult()
	{
		const sbyte expected = ResultFixture.Success;
		Func<Failure, string> create = static _ => ResultFixture.Failure;
		Result<string, sbyte> actual = new Result<Failure, sbyte>(expected).MapFailure(create);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	[Fact]
	[Trait(@base, memberMapFailure)]
	public void MapFailure_FailedResultPlusCreate_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<Failure, string> create = static _ => expected;
		Result<string, sbyte> actual = new Result<Failure, sbyte>(Failure.Availability).MapFailure(create);
		ResultAsserter.IsFailed(expected, actual);
	}

	#endregion MapFailure

	#region MapSuccess

	[Fact]
	[Trait(@base, memberMapSuccess)]
	public void MapSuccess_FailedResultPlusCreate_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<sbyte, short> create = static _ => ResultFixture.SuccessToMap;
		Result<string, short> actual = ResultMother.Fail(expected)
			.MapSuccess(create);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberMapSuccess)]
	public void MapSuccess_SuccessfulResultPlusCreate_SuccessfulResult()
	{
		const short expected = ResultFixture.SuccessToMap;
		Func<sbyte, short> create = static _ => expected;
		Result<string, short> actual = ResultMother.Succeed()
			.MapSuccess(create);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion MapSuccess

	#region Bind

	[Fact]
	[Trait(@base, memberBind)]
	public void Bind_FailedResultPlusCreateWithFailedResult_FailedResult()
	{
		string expected = ResultFixture.RandomFailure;
		Func<sbyte, Result<string, sbyte>> create = static _ => ResultMother.Fail();
		Result<string, sbyte> actual = ResultMother.Fail(expected)
			.Bind(create);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberBind)]
	public void Bind_FailedResultPlusCreateWithSuccessfulResult_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<sbyte, Result<string, sbyte>> create = static _ => ResultMother.Succeed();
		Result<string, sbyte> actual = ResultMother.Fail(expected)
			.Bind(create);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberBind)]
	public void Bind_SuccessfulResultPlusCreateWithFailedResult_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<sbyte, Result<string, sbyte>> create = static _ => ResultMother.Fail(expected);
		Result<string, sbyte> actual = ResultMother.Succeed()
			.Bind(create);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberBind)]
	public void Bind_SuccessfulResultPlusCreateWithSuccessfulResult_SuccessfulResult()
	{
		const sbyte success = ResultFixture.SuccessToBind;
		const sbyte expected = ResultFixture.Success;
		Func<sbyte, Result<string, sbyte>> create = static _ => ResultMother.Succeed(expected);
		Result<string, sbyte> actual = ResultMother.Succeed(success)
			.Bind(create);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Bind

	#region Reset

	#region Reset overload

	[Fact]
	[Trait(@base, memberReset)]
	public void Reset_FailedResultPlusSuccess_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		const short success = ResultFixture.SuccessInitializer;
		Result<string, short> actual = ResultMother.Fail(expected)
			.Reset(success);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberReset)]
	public void Reset_SuccessfulResultPlusSuccess_SuccessfulResult()
	{
		const short expected = ResultFixture.SuccessInitializer;
		Result<string, short> actual = ResultMother.Succeed()
			.Reset(expected);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Reset overload

	#region Reset overload

	[Fact]
	[Trait(@base, memberReset)]
	public void Reset_FailedResultPlusFailedResult_FailedResult()
	{
		string expected = ResultFixture.RandomFailure;
		Result<string, short> result = new(ResultFixture.Failure);
		Result<string, short> actual = ResultMother.Fail(expected)
			.Reset(result);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberReset)]
	public void Reset_FailedResultPlusSuccessfulResult_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Result<string, short> result = new(ResultFixture.SuccessInitializer);
		Result<string, short> actual = ResultMother.Fail(expected)
			.Reset(result);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberReset)]
	public void Reset_SuccessfulResultPlusFailedResult_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Result<string, short> result = new(expected);
		Result<string, short> actual = ResultMother.Succeed()
			.Reset(result);
		ResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberReset)]
	public void Reset_SuccessfulResultPlusSuccessfulResult_SuccessfulResult()
	{
		const short expected = ResultFixture.SuccessInitializer;
		Result<string, short> result = new(expected);
		Result<string, short> actual = ResultMother.Succeed()
			.Reset(result);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Reset overload

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
	public void Equals_FailedResultAndNullObject_False()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		object? right = null;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedResultAndDifferentObject_False()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		object right = string.Empty;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulResultAndNullObject_False()
	{
		Result<string, sbyte> left = ResultMother.Succeed();
		object? right = null;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulResultAndDifferentObject_False()
	{
		Result<string, sbyte> left = ResultMother.Succeed();
		object right = string.Empty;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedResultAndSuccessfulObject_False()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		object right = ResultMother.Succeed();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulResultAndFailedObject_False()
	{
		Result<string, sbyte> left = ResultMother.Succeed();
		object right = ResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DifferentFailedResultAndDifferentFailedObject_False()
	{
		Result<string, sbyte> left = ResultMother.FailRandomly();
		object right = ResultMother.FailRandomly();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DifferentSuccessfulResultAndDifferentSuccessfulObject_False()
	{
		Result<string, sbyte> left = ResultMother.Succeed(1);
		object right = ResultMother.Succeed(2);
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedResultAndFailedObject_True()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		object right = ResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulResultAndSuccessfulObject_True()
	{
		Result<string, sbyte> left = ResultMother.Succeed();
		object right = ResultMother.Succeed();
		bool actual = left.Equals(right);
		Assert.True(actual);
	}

	#endregion Equals overload

	#region Equals overload

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedResultAndNullResult_False()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		Result<string, sbyte> right = null!;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulResultAndNullResult_False()
	{
		Result<string, sbyte> left = ResultMother.Succeed();
		Result<string, sbyte> right = null!;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedResultAndSuccessfulResult_False()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		Result<string, sbyte> right = ResultMother.Succeed();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulResultAndFailedResult_False()
	{
		Result<string, sbyte> left = ResultMother.Succeed();
		Result<string, sbyte> right = ResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DifferentFailedResultAndDifferentFailedResult_False()
	{
		Result<string, sbyte> left = ResultMother.FailRandomly();
		Result<string, sbyte> right = ResultMother.FailRandomly();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DifferentSuccessfulResultAndDifferentSuccessfulResult_False()
	{
		Result<string, sbyte> left = ResultMother.Succeed(1);
		Result<string, sbyte> right = ResultMother.Succeed(2);
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedResultAndFailedResult_True()
	{
		Result<string, sbyte> left = ResultMother.Fail();
		Result<string, sbyte> right = ResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulResultAndSuccessfulResult_True()
	{
		Result<string, sbyte> left = ResultMother.Succeed();
		Result<string, sbyte> right = ResultMother.Succeed();
		bool actual = left.Equals(right);
		Assert.True(actual);
	}

	#endregion Equals overload

	#endregion Equals

	#region GetHashCode

	[Fact]
	[Trait(@base, memberGetHashCode)]
	public void GetHashCode_DifferentStates_DifferentHashCodes()
	{
		int expected = ResultMother.Succeed()
			.GetHashCode();
		int actual = ResultMother.Fail()
			.GetHashCode();
		Assert.NotEqual(expected, actual);
	}

	[Fact]
	[Trait(@base, memberGetHashCode)]
	public void GetHashCode_DifferentFailedStates_DifferentHashCodes()
	{
		int expected = ResultMother.FailRandomly()
			.GetHashCode();
		int actual = ResultMother.FailRandomly()
			.GetHashCode();
		Assert.NotEqual(expected, actual);
	}

	[Fact]
	[Trait(@base, memberGetHashCode)]
	public void GetHashCode_DifferentSuccessfulStates_DifferentHashCodes()
	{
		int expected = ResultMother.Succeed(1)
			.GetHashCode();
		int actual = ResultMother.Succeed(2)
			.GetHashCode();
		Assert.NotEqual(expected, actual);
	}

	[Fact]
	[Trait(@base, memberGetHashCode)]
	public void GetHashCode_FailedStates_EqualHashCodes()
	{
		int expected = ResultMother.Fail()
			.GetHashCode();
		int actual = ResultMother.Fail()
			.GetHashCode();
		Assert.Equal(expected, actual);
	}

	[Fact]
	[Trait(@base, memberGetHashCode)]
	public void GetHashCode_SuccessfulStates_EqualHashCodes()
	{
		int expected = ResultMother.Succeed()
			.GetHashCode();
		int actual = ResultMother.Succeed()
			.GetHashCode();
		Assert.Equal(expected, actual);
	}

	#endregion GetHashCode

	#region ToString

	[Fact]
	[Trait(@base, memberToString)]
	public void ToString_FailedResultWithNullFailure_Empty()
	{
		const string? failure = null;
		Result<string?, sbyte> result = new(failure);
		string actual = result.ToString();
		Assert.Empty(actual);
	}

	[Fact]
	[Trait(@base, memberToString)]
	public void ToString_FailureWithNullToString_Empty()
	{
		Result<FailureWithNullToString, sbyte> result = new(new FailureWithNullToString());
		string actual = result.ToString();
		Assert.Empty(actual);
	}

	[Fact]
	[Trait(@base, memberToString)]
	public void ToString_FailedResult_Failure()
	{
		const string expected = ResultFixture.Failure;
		Result<string, sbyte> result = ResultMother.Fail(expected);
		string actual = result.ToString();
		Assert.Equal(expected, actual);
	}

	[Fact]
	[Trait(@base, memberToString)]
	public void ToString_SuccessfulResultWithNullSuccess_Empty()
	{
		sbyte? success = null;
		Result<string, sbyte?> result = new(success!);
		string actual = result.ToString();
		Assert.Empty(actual);
	}

	[Fact]
	[Trait(@base, memberToString)]
	public void ToString_SuccessWithNullToString_Empty()
	{
		Result<Failure, SuccessWithNullToString> result = new(new SuccessWithNullToString());
		string actual = result.ToString();
		Assert.Empty(actual);
	}

	[Fact]
	[Trait(@base, memberToString)]
	public void ToString_SuccessfulResult_Success()
	{
		const sbyte expected = ResultFixture.Success;
		Result<string, sbyte> result = ResultMother.Succeed(expected);
		string actual = result.ToString();
		Assert.Equal(expected.ToString(CultureInfo.InvariantCulture), actual);
	}

	#endregion ToString
}
