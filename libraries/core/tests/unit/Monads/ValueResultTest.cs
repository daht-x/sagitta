// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests.Monads;

public sealed class ValueResultTest
{
	private const string @base = nameof(ValueResult<Failure, byte>);

	private const string memberEqualOperator = "==";

	private const string memberNotEqualOperator = "!=";

	private const string memberConstructor = "Constructor";

	private const string memberImplicitOperator = "Implicit operator";

	private const string memberTryGetFailure = nameof(ValueResult<Failure, sbyte>.TryGetFailure);

	private const string memberTryGetSuccess = nameof(ValueResult<Failure, sbyte>.TryGetSuccess);

	private const string memberDeconstruct = nameof(ValueResult<Failure, sbyte>.Deconstruct);

	private const string memberDiscard = nameof(ValueResult<Failure, sbyte>.Discard);

	private const string memberEquals = nameof(ValueResult<Failure, sbyte>.Equals);

	private const string memberGetHashCode = nameof(ValueResult<Failure, sbyte>.GetHashCode);

	private const string memberToString = nameof(ValueResult<Failure, sbyte>.ToString);

	#region ==

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_DefaultLeftAndFailedRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_FailedLeftAndDefaultRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_DefaultLeftAndSuccessfulRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_SuccessfulLeftAndDefaultRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_FailedLeftAndSuccessfulRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_SuccessfulLeftAndFailedRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_DifferentFailedLeftAndDifferentFailedRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail(Failure.Availability);
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail(Failure.Range);
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_DifferentSuccessfulLeftAndDifferentSuccessfulRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed(1);
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed(2);
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_DefaultLeftAndDefaultRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left == right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_FailedLeftAndFailedRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left == right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEqualOperator)]
	public void EqualOperator_SuccessfulLeftAndSuccessfulRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left == right;
		Assert.True(actual);
	}

	#endregion ==

	#region !=

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_SuccessfulLeftAndSuccessfulRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left != right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_FailedLeftAndFailedRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left != right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_DefaultLeftAndDefaultRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left != right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_DifferentSuccessfulLeftAndDifferentSuccessfulRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed(1);
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed(2);
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_DifferentFailedLeftAndDifferentFailedRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail(Failure.Availability);
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail(Failure.Range);
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_FailedLeftAndSuccessfulRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_SuccessfulLeftAndFailedRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_SuccessfulLeftAndDefaultRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_DefaultLeftAndSuccessfulRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_FailedLeftAndDefaultRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberNotEqualOperator)]
	public void NotEqualOperator_DefaultLeftAndFailedRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
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
		Failure expected = ValueResultFixture.Failure;
		ValueResult<Failure, sbyte> actual = new(expected);
		ValueResultAsserter.IsFailed(expected, actual);
	}

	#endregion Constructor overload

	#region Constructor overload

	[Fact]
	[Trait(@base, memberConstructor)]
	public void Constructor_Success_SuccessfulResult()
	{
		const sbyte expected = ValueResultFixture.Success;
		ValueResult<Failure, sbyte> actual = new(expected);
		ValueResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Constructor overload

	#endregion Constructor

	#region Implicit operator

	#region Implicit operator overload

	[Fact]
	[Trait(@base, memberImplicitOperator)]
	public void ImplicitOperator_Failure_FailedResult()
	{
		Failure expected = ValueResultFixture.Failure;
		ValueResult<Failure, sbyte> actual = expected;
		ValueResultAsserter.IsFailed(expected, actual);
	}

	#endregion Implicit operator overload

	#region Implicit operator overload

	[Fact]
	[Trait(@base, memberImplicitOperator)]
	public void ImplicitOperator_Success_SuccessfulResult()
	{
		const sbyte expected = ValueResultFixture.Success;
		ValueResult<Failure, sbyte> actual = expected;
		ValueResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Implicit operator overload

	#endregion Implicit operator

	#region Deconstruct

	[Fact]
	[Trait(@base, memberDeconstruct)]
	public void Deconstruct_DefaultResult_InvalidOperationException()
		=> ValueResultAsserter.IsDefault(static () => (_, _, _) = ValueResultMother.GetDefault());

	[Fact]
	[Trait(@base, memberDeconstruct)]
	public void Deconstruct_FailedResult_FailedStates()
	{
		Failure expectedFailure = ValueResultFixture.Failure;
		(bool isFailed, Failure failure, sbyte success) = ValueResultMother.Fail(expectedFailure);
		Assert.True(isFailed);
		Assert.Equal(expectedFailure, failure);
		Assert.Equal(default, success);
	}

	[Fact]
	[Trait(@base, memberDeconstruct)]
	public void Deconstruct_SuccessfulResult_SuccessfulStates()
	{
		const sbyte expectedSuccess = ValueResultFixture.Success;
		(bool isFailed, Failure failure, sbyte success) = ValueResultMother.Succeed(expectedSuccess);
		Assert.False(isFailed);
		Assert.Equal(Failure.Default, failure);
		Assert.Equal(expectedSuccess, success);
	}

	#endregion Deconstruct

	#region TryGetFailure

	[Fact]
	[Trait(@base, memberTryGetFailure)]
	public void TryGetFailure_DefaultResult_False()
	{
		ValueResult<Failure, sbyte> actual = ValueResultMother.GetDefault();
		bool status = actual.TryGetFailure(out Failure output);
		Assert.False(status);
		Assert.Equal(Failure.Default, output);
	}

	[Fact]
	[Trait(@base, memberTryGetFailure)]
	public void TryGetFailure_SuccessfulResult_False()
	{
		ValueResult<Failure, sbyte> actual = ValueResultMother.Succeed();
		bool status = actual.TryGetFailure(out Failure output);
		Assert.False(status);
		Assert.Equal(Failure.Default, output);
	}

	[Fact]
	[Trait(@base, memberTryGetFailure)]
	public void TryGetFailure_FailedResult_True()
	{
		Failure expected = ValueResultFixture.Failure;
		ValueResult<Failure, sbyte> actual = ValueResultMother.Fail(expected);
		bool status = actual.TryGetFailure(out Failure output);
		Assert.True(status);
		Assert.Equal(expected, output);
	}

	#endregion TryGetFailure

	#region TryGetSuccess

	[Fact]
	[Trait(@base, memberTryGetSuccess)]
	public void TryGetSuccess_DefaultResult_False()
	{
		ValueResult<Failure, sbyte> actual = ValueResultMother.GetDefault();
		bool status = actual.TryGetSuccess(out sbyte output);
		Assert.False(status);
		Assert.Equal(default, output);
	}

	[Fact]
	[Trait(@base, memberTryGetSuccess)]
	public void TryGetSuccess_FailedResult_False()
	{
		ValueResult<Failure, sbyte> actual = ValueResultMother.Fail();
		bool status = actual.TryGetSuccess(out sbyte output);
		Assert.False(status);
		Assert.Equal(default, output);
	}

	[Fact]
	[Trait(@base, memberTryGetSuccess)]
	public void TryGetSuccess_SuccessfulResult_True()
	{
		const sbyte expected = ValueResultFixture.Success;
		ValueResult<Failure, sbyte> actual = ValueResultMother.Succeed(expected);
		bool status = actual.TryGetSuccess(out sbyte output);
		Assert.True(status);
		Assert.Equal(expected, output);
	}

	#endregion TryGetSuccess

	#region Discard

	[Fact]
	[Trait(@base, memberDiscard)]
	public void Discard_Default_InvalidOperationException()
	{
		ValueResult<Failure, Unit> actual = default;
		ValueResultAsserter.IsDefault(() => actual.Discard());
	}

	[Fact]
	[Trait(@base, memberDiscard)]
	public void Discard_FailedResult_FailedResult()
	{
		Failure expected = ValueResultFixture.Failure;
		ValueResult<Failure, Unit> actual = ValueResultMother.Fail(expected)
			.Discard();
		ValueResultAsserter.IsFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberDiscard)]
	public void Discard_SuccessfulResult_Unit()
	{
		Unit expected = Unit.Default;
		ValueResult<Failure, Unit> actual = ValueResultMother.Succeed(ValueResultFixture.Success)
			.Discard();
		ValueResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Discard

	#region Equals

	#region Equals overload

	[Fact]
	[Trait(@base, memberEquals)]
	[SuppressMessage(
		MaintainabilityAnalysisCategory.Name,
		MaintainabilityAnalysisCategory.Rules.AvoidDeadConditionalCode
	)]
	public void Equals_FailedLeftAndNullObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		object? right = null;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedLeftAndDifferentObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		object right = string.Empty;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultLeftAndFailedObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		object right = ValueResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedLeftAndDefaultObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		object right = ValueResultMother.GetDefault();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	[SuppressMessage(
		MaintainabilityAnalysisCategory.Name,
		MaintainabilityAnalysisCategory.Rules.AvoidDeadConditionalCode
	)]
	public void Equals_SuccessfulLeftAndNullObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		object? right = null;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulLeftAndDifferentObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		object right = string.Empty;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultLeftAndSuccessfulObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		object right = ValueResultMother.Succeed();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulLeftAndDefaultObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		object right = ValueResultMother.GetDefault();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedLeftAndSuccessfulObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		object right = ValueResultMother.Succeed();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulLeftAndFailedObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		object right = ValueResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DifferentFailedLeftAndDifferentFailedObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail(Failure.Availability);
		object right = ValueResultMother.Fail(Failure.Range);
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DifferentSuccessfulLeftAndDifferentSuccessfulObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed(1);
		object right = ValueResultMother.Succeed(2);
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	[SuppressMessage(
		MaintainabilityAnalysisCategory.Name,
		MaintainabilityAnalysisCategory.Rules.AvoidDeadConditionalCode
	)]
	public void Equals_DefaultLeftAndNullObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		object? right = null;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultLeftAndDifferentObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		object right = string.Empty;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultLeftAndDefaultObject_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		object right = ValueResultMother.GetDefault();
		bool actual = left.Equals(right);
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedLeftAndFailedObject_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		object right = ValueResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulLeftAndSuccessfulObject_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		object right = ValueResultMother.Succeed();
		bool actual = left.Equals(right);
		Assert.True(actual);
	}

	#endregion Equals overload

	#region Equals overload

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultLeftAndFailedRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedLeftAndDefaultRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultLeftAndSuccessfulRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulLeftAndDefaultRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedLeftAndSuccessfulRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulLeftAndFailedRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DifferentFailedLeftAndDifferentFailedRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail(Failure.Availability);
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail(Failure.Range);
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DifferentSuccessfulLeftAndDifferentSuccessfulRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed(1);
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed(2);
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultLeftAndDefaultRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left.Equals(right);
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedLeftAndFailedRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulLeftAndSuccessfulRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
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
		int expected = ValueResultMother.Succeed()
			.GetHashCode();
		int actual = ValueResultMother.Fail()
			.GetHashCode();
		Assert.NotEqual(expected, actual);
	}

	[Fact]
	[Trait(@base, memberGetHashCode)]
	public void GetHashCode_DifferentFailedStates_DifferentHashCodes()
	{
		int expected = ValueResultMother.Fail(Failure.Availability)
			.GetHashCode();
		int actual = ValueResultMother.Fail(Failure.Range)
			.GetHashCode();
		Assert.NotEqual(expected, actual);
	}

	[Fact]
	[Trait(@base, memberGetHashCode)]
	public void GetHashCode_DifferentSuccessfulStates_DifferentHashCodes()
	{
		int expected = ValueResultMother.Succeed(1)
			.GetHashCode();
		int actual = ValueResultMother.Succeed(2)
			.GetHashCode();
		Assert.NotEqual(expected, actual);
	}

	[Fact]
	[Trait(@base, memberGetHashCode)]
	public void GetHashCode_DefaultStates_EqualHashCodes()
	{
		int expected = ValueResultMother.GetDefault()
			.GetHashCode();
		int actual = ValueResultMother.GetDefault()
			.GetHashCode();
		Assert.Equal(expected, actual);
	}

	[Fact]
	[Trait(@base, memberGetHashCode)]
	public void GetHashCode_FailedStates_EqualHashCodes()
	{
		int expected = ValueResultMother.Fail()
			.GetHashCode();
		int actual = ValueResultMother.Fail()
			.GetHashCode();
		Assert.Equal(expected, actual);
	}

	[Fact]
	[Trait(@base, memberGetHashCode)]
	public void GetHashCode_SuccessfulStates_EqualHashCodes()
	{
		int expected = ValueResultMother.Succeed()
			.GetHashCode();
		int actual = ValueResultMother.Succeed()
			.GetHashCode();
		Assert.Equal(expected, actual);
	}

	#endregion GetHashCode

	#region ToString

	[Fact]
	[Trait(@base, memberToString)]
	public void ToString_DefaultResult_Empty()
	{
		ValueResult<Failure, sbyte> result = ValueResultMother.GetDefault();
		string actual = result.ToString();
		Assert.Empty(actual);
	}

	[Fact]
	[Trait(@base, memberToString)]
	public void ToString_FailedResult_Failure()
	{
		Failure expected = ValueResultFixture.Failure;
		ValueResult<Failure, sbyte> result = ValueResultMother.Fail(expected);
		string actual = result.ToString();
		Assert.Equal(expected.ToString(), actual);
	}

	[Fact]
	[Trait(@base, memberToString)]
	public void ToString_SuccessWithNullToString_Empty()
	{
		ValueResult<Failure, SuccessWithNullToString> result = new(new SuccessWithNullToString());
		string actual = result.ToString();
		Assert.Empty(actual);
	}

	[Fact]
	[Trait(@base, memberToString)]
	public void ToString_SuccessfulResult_Success()
	{
		const sbyte expected = ValueResultFixture.Success;
		ValueResult<Failure, sbyte> result = ValueResultMother.Succeed(expected);
		string actual = result.ToString();
		Assert.Equal(expected.ToString(CultureInfo.InvariantCulture), actual);
	}

	#endregion ToString
}
