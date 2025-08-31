// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests.Results;

public sealed class ValueResultFactoryTests
{
	private const string @base = nameof(ValueResultFactory);

	private const string memberFail = nameof(ValueResultFactory.Fail);

	private const string memberSucceed = nameof(ValueResultFactory.Succeed);

	#region Fail

	[Fact]
	[Trait(@base, memberFail)]
	public void Fail_Failure_FailedResult()
	{
		Failure expected = ValueResultFixture.Failure;
		ValueResult<Failure, sbyte> actual = ValueResultFactory.Fail<Failure, sbyte>(expected);
		ValueResultAsserter.IsFailed(expected, actual);
	}

	#endregion Fail

	#region Succeed

	[Fact]
	[Trait(@base, memberSucceed)]
	public void Succeed_Success_SuccessfulResult()
	{
		const sbyte expected = ResultFixture.Success;
		ValueResult<Failure, sbyte> actual = ValueResultFactory.Succeed<Failure, sbyte>(expected);
		ValueResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Succeed
}
