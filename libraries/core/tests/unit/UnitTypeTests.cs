// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests;

public sealed class UnitTypeTests
{
	private const string @base = nameof(Unit);

	private const string memberEqualityOperator = "==";

	private const string memberInequalityOperator = "!=";

	private const string memberEquals = nameof(Unit.Equals);

	private const string memberGetHashCode = nameof(Unit.GetHashCode);

	private const string memberToString = nameof(Unit.ToString);

	#region Equality operator ==

	[Fact]
	[Trait(@base, memberEqualityOperator)]
	[SuppressMessage(
		MaintainabilityAnalysisCategory.Name,
		MaintainabilityAnalysisCategory.Rules.AvoidDeadConditionalCode
	)]
	public void EqualityOperator_DefaultLeftAndNullRight_False()
	{
		Unit left = Unit.Default;
		Unit? right = null;
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualityOperator)]
	[SuppressMessage(
		MaintainabilityAnalysisCategory.Name,
		MaintainabilityAnalysisCategory.Rules.AvoidDeadConditionalCode
	)]
	public void EqualityOperator_NullLeftAndDefaultRight_False()
	{
		Unit? left = null;
		Unit right = Unit.Default;
		bool actual = left == right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEqualityOperator)]
	[SuppressMessage(
		MaintainabilityAnalysisCategory.Name,
		MaintainabilityAnalysisCategory.Rules.AvoidDeadConditionalCode
	)]
	public void EqualityOperator_NullLeftAndNullRight_True()
	{
		Unit? left = null;
		Unit? right = null;
		bool actual = left == right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberEqualityOperator)]
	public void EqualityOperator_DefaultLeftAndDefaultRight_True()
	{
		Unit left = Unit.Default;
		Unit right = Unit.Default;
		bool actual = left == right;
		Assert.True(actual);
	}

	#endregion Equality operator ==

	#region Inequality operator !=

	[Fact]
	[Trait(@base, memberInequalityOperator)]
	public void InequalityOperator_DefaultLeftAndDefaultRight_False()
	{
		Unit left = Unit.Default;
		Unit right = Unit.Default;
		bool actual = left != right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberInequalityOperator)]
	[SuppressMessage(
		MaintainabilityAnalysisCategory.Name,
		MaintainabilityAnalysisCategory.Rules.AvoidDeadConditionalCode
	)]
	public void InequalityOperator_NullLeftAndNullRight_False()
	{
		Unit? left = null;
		Unit? right = null;
		bool actual = left != right;
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberInequalityOperator)]
	[SuppressMessage(
		MaintainabilityAnalysisCategory.Name,
		MaintainabilityAnalysisCategory.Rules.AvoidDeadConditionalCode
	)]
	public void InequalityOperator_NullLeftAndDefaultRight_True()
	{
		Unit? left = null;
		Unit right = Unit.Default;
		bool actual = left != right;
		Assert.True(actual);
	}

	[Fact]
	[Trait(@base, memberInequalityOperator)]
	[SuppressMessage(
		MaintainabilityAnalysisCategory.Name,
		MaintainabilityAnalysisCategory.Rules.AvoidDeadConditionalCode
	)]
	public void InequalityOperator_DefaultLeftAndNullRight_True()
	{
		Unit left = Unit.Default;
		Unit? right = null;
		bool actual = left != right;
		Assert.True(actual);
	}

	#endregion Inequality operator !=

	#region Equals

	#region Equals overload

	[Fact]
	[Trait(@base, memberEquals)]
	[SuppressMessage(
		MaintainabilityAnalysisCategory.Name,
		MaintainabilityAnalysisCategory.Rules.AvoidDeadConditionalCode
	)]
	public void Equals_DefaultUnitAndNullObject_False()
	{
		Unit left = Unit.Default;
		object? right = null;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultUnitAndDifferentObject_False()
	{
		Unit left = Unit.Default;
		object right = string.Empty;
		bool actual = left.Equals(right);
		Assert.False(actual);
	}

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultUnitAndDefaultUnitObject_True()
	{
		Unit left = Unit.Default;
		object right = Unit.Default;
		bool actual = left.Equals(right);
		Assert.True(actual);
	}

	#endregion Equals overload

	#region Equals overload

	[Fact]
	[Trait(@base, memberEquals)]
	public void Equals_DefaultUnitAndDefaultUnit_True()
	{
		Unit left = Unit.Default;
		Unit right = Unit.Default;
		bool actual = left.Equals(right);
		Assert.True(actual);
	}

	#endregion Equals overload

	#endregion Equals

	#region GetHashCode

	[Fact]
	[Trait(@base, memberGetHashCode)]
	public void GetHashCode_DefaultUnit_Zero()
	{
		const int expected = 0;
		int actual = Unit.Default
			.GetHashCode();
		Assert.Equal(expected, actual);
	}

	#endregion GetHashCode

	#region ToString

	[Fact]
	[Trait(@base, memberToString)]
	public void ToString_DefaultUnit_Empty()
	{
		Unit unit = Unit.Default;
		string actual = unit.ToString();
		Assert.Empty(actual);
	}

	#endregion ToString
}
