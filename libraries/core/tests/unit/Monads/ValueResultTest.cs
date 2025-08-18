// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests.Monads;

public sealed class ValueResultTest
{
	private const string @base = nameof(ValueResult<Failure, byte>);

	private const string memberEqualityOperator = "Equality operator ==";

	private const string memberInequalityOperator = "Inequality operator !=";

	private const string memberConstructor = "Constructor";

	private const string memberImplicitOperator = "Implicit operator";

	private const string memberTryGetFailure = nameof(ValueResult<Failure, sbyte>.TryGetFailure);

	private const string memberTryGetSuccess = nameof(ValueResult<Failure, sbyte>.TryGetSuccess);

	private const string memberDeconstruct = nameof(ValueResult<Failure, sbyte>.Deconstruct);

	private const string memberDiscard = nameof(ValueResult<Failure, sbyte>.Discard);

	private const string memberEquals = nameof(ValueResult<Failure, sbyte>.Equals);

	private const string memberGetHashCode = nameof(ValueResult<Failure, sbyte>.GetHashCode);

	private const string memberToString = nameof(ValueResult<Failure, sbyte>.ToString);

	#region Equality operator ==

	[Fact]
	[Trait(@base, memberEqualityOperator)]
	public void EqualityOperator_DefaultLeftAndFailedRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualityOperator)]
	public void EqualityOperator_FailedLeftAndDefaultRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualityOperator)]
	public void EqualityOperator_DefaultLeftAndSuccessfulRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualityOperator)]
	public void EqualityOperator_SuccessfulLeftAndDefaultRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualityOperator)]
	public void EqualityOperator_FailedLeftAndSuccessfulRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualityOperator)]
	public void EqualityOperator_SuccessfulLeftAndFailedRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualityOperator)]
	public void EqualityOperator_DifferentFailedLeftAndDifferentFailedRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail(Failure.Availability);
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail(Failure.Range);
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualityOperator)]
	public void EqualityOperator_DifferentSuccessfulLeftAndDifferentSuccessfulRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed(1);
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed(2);
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualityOperator)]
	public void EqualityOperator_DefaultLeftAndDefaultRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left == right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEqualityOperator)]
	public void EqualityOperator_FailedLeftAndFailedRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left == right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEqualityOperator)]
	public void EqualityOperator_SuccessfulLeftAndSuccessfulRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left == right;
		Assert.True(actual);
	}

	#endregion Equality operator ==

	#region Inequality operator !=

	[Fact]
	[Trait(@base, memberInequalityOperator)]
	public void InequalityOperator_SuccessfulLeftAndSuccessfulRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left != right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberInequalityOperator)]
	public void InequalityOperator_FailedLeftAndFailedRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left != right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberInequalityOperator)]
	public void InequalityOperator_DefaultLeftAndDefaultRight_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left != right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberInequalityOperator)]
	public void InequalityOperator_DifferentSuccessfulLeftAndDifferentSuccessfulRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed(1);
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed(2);
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberInequalityOperator)]
	public void InequalityOperator_DifferentFailedLeftAndDifferentFailedRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail(Failure.Availability);
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail(Failure.Range);
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberInequalityOperator)]
	public void InequalityOperator_FailedLeftAndSuccessfulRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberInequalityOperator)]
	public void InequalityOperator_SuccessfulLeftAndFailedRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberInequalityOperator)]
	public void InequalityOperator_SuccessfulLeftAndDefaultRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberInequalityOperator)]
	public void InequalityOperator_DefaultLeftAndSuccessfulRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberInequalityOperator)]
	public void InequalityOperator_FailedLeftAndDefaultRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberInequalityOperator)]
	public void InequalityOperator_DefaultLeftAndFailedRight_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left != right;
		Assert.True(actual);
	}

	#endregion Inequality operator !=

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
	public void ImplicitOperator_FailureOnDefaultResult_InvalidOperationException()
		=> Assert.Throws<InvalidOperationException>(static () =>
			{
				Failure _ = ValueResultMother.GetDefault();
			}
		);

	[Fact]
	[Trait(@base, memberImplicitOperator)]
	public void ImplicitOperator_SuccessOnFailedResult_InvalidOperationException()
		=> Assert.Throws<InvalidOperationException>(static () =>
			{
				sbyte _ = ValueResultMother.Fail();
			}
		);

	[Fact]
	[Trait(@base, memberImplicitOperator)]
	public void ImplicitOperator_FailedResult_Failure()
	{
		Failure expected = ValueResultFixture.Failure;
		Failure actual = ValueResultMother.Fail(expected);
		Assert.Equal(expected, actual);
	}

	#endregion Implicit operator overload

	#region Implicit operator overload

	[Fact]
	[Trait(@base, memberImplicitOperator)]
	public void ImplicitOperator_SuccessOnDefaultResult_InvalidOperationException()
		=> Assert.Throws<InvalidOperationException>(static () =>
			{
				sbyte _ = ValueResultMother.GetDefault();
			}
		);

	[Fact]
	[Trait(@base, memberImplicitOperator)]
	public void ImplicitOperator_FailureOnSuccessfulResult_InvalidOperationException()
		=> Assert.Throws<InvalidOperationException>(static () =>
			{
				Failure _ = ValueResultMother.Succeed();
			}
		);

	[Fact]
	[Trait(@base, memberImplicitOperator)]
	public void ImplicitOperator_SuccessfulResult_Success()
	{
		const sbyte expected = ValueResultFixture.Success;
		sbyte actual = ValueResultMother.Succeed(expected);
		Assert.Equal(expected, actual);
	}

	#endregion Implicit operator overload

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
		=> Assert.Throws<InvalidOperationException>(() => (_, _, _) = ValueResultMother.GetDefault());

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
		=> Assert.Throws<InvalidOperationException>(() =>
			{
				ValueResult<Failure, Unit> actual = default;
				_ = actual.Discard();
			}
		);

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
	public void Equals_FailedResultAndNullObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		object? right = null;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedResultAndDifferentObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		object right = string.Empty;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultResultAndFailedObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		object right = ValueResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedResultAndDefaultObject_False()
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
	public void Equals_SuccessfulResultAndNullObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		object? right = null;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulResultAndDifferentObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		object right = string.Empty;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultResultAndSuccessfulObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		object right = ValueResultMother.Succeed();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulResultAndDefaultObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		object right = ValueResultMother.GetDefault();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedResultAndSuccessfulObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		object right = ValueResultMother.Succeed();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulResultAndFailedObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		object right = ValueResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DifferentFailedResultAndDifferentFailedObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail(Failure.Availability);
		object right = ValueResultMother.Fail(Failure.Range);
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DifferentSuccessfulResultAndDifferentSuccessfulObject_False()
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
	public void Equals_DefaultResultAndNullObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		object? right = null;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultResultAndDifferentObject_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		object right = string.Empty;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultResultAndDefaultObject_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		object right = ValueResultMother.GetDefault();
		bool actual = left.Equals(right);
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedResultAndFailedObject_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		object right = ValueResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulResultAndSuccessfulObject_True()
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
	public void Equals_DefaultResultAndFailedResult_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedResultAndDefaultResult_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultResultAndSuccessfulResult_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulResultAndDefaultResult_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedResultAndSuccessfulResult_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulResultAndFailedResult_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DifferentFailedResultAndDifferentFailedResult_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail(Failure.Availability);
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail(Failure.Range);
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DifferentSuccessfulResultAndDifferentSuccessfulResult_False()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Succeed(1);
		ValueResult<Failure, sbyte> right = ValueResultMother.Succeed(2);
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultResultAndDefaultResult_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.GetDefault();
		ValueResult<Failure, sbyte> right = ValueResultMother.GetDefault();
		bool actual = left.Equals(right);
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_FailedResultAndFailedResult_True()
	{
		ValueResult<Failure, sbyte> left = ValueResultMother.Fail();
		ValueResult<Failure, sbyte> right = ValueResultMother.Fail();
		bool actual = left.Equals(right);
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_SuccessfulResultAndSuccessfulResult_True()
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
