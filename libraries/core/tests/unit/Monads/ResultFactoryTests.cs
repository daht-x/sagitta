// ---------------------------------------------------------------------------------------------------------- 
// Copyright (c) David Andrés Hernández Triana. All rights reserved. 
// Licensed under the MIT License. Please refer to the license file in the project root for more information. 
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests.Monads;

public sealed class ResultFactoryTests
{
	private const string @base = nameof(ResultFactory);

	private const string memberCatch = nameof(ResultFactory.Catch);

	private const string memberFail = nameof(ResultFactory.Fail);

	private const string memberSucceed = nameof(ResultFactory.Succeed);

	#region Catch

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_CreateSuccessPlusCreateFailure_SuccessfulResult()
	{
		const sbyte expected = ResultFixture.Success;
		Func<sbyte> createSuccess = static () => expected;
		Func<ProofOfConceptException, string> createFailure = static exception => exception.Message;
		Result<string, sbyte> actual = ResultFactory.Catch(createSuccess, createFailure);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_ExceptionInCreateSuccessPlusCreateFailure_FailedResult()
	{
		Func<sbyte> createSuccess = static () => throw new ProofOfConceptException();
		Func<ProofOfConceptException, string> createFailure = static exception => exception.Message;
		const string expected = ProofOfConceptException.DefaultMessage;
		Result<string, sbyte> actual = ResultFactory.Catch(createSuccess, createFailure);
		ResultAsserter.IsFailed(expected, actual);
	}

	#endregion Catch

	#region Fail

	#region Fail overload

	[Fact]
	[Trait(@base, memberFail)]
	public void Fail_Failure_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Result<string, sbyte> actual = ResultFactory.Fail<string, sbyte>(expected);
		ResultAsserter.IsFailed(expected, actual);
	}

	#endregion Fail overload

	#region Fail overload

	[Fact]
	[Trait(@base, memberFail)]
	public void Fail_Create_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<string> create = static () => expected;
		Result<string, sbyte> actual = ResultFactory.Fail<string, sbyte>(create);
		ResultAsserter.IsFailed(expected, actual);
	}

	#endregion Fail overload

	#endregion Fail

	#region Succeed

	#region Succeed overload

	[Fact]
	[Trait(@base, memberSucceed)]
	public void Succeed_Success_SuccessfulResult()
	{
		const sbyte expected = ResultFixture.Success;
		Result<string, sbyte> actual = ResultFactory.Succeed<string, sbyte>(expected);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Succeed overload

	#region Succeed overload

	[Fact]
	[Trait(@base, memberSucceed)]
	public void Succeed_Create_SuccessfulResult()
	{
		const sbyte expected = ResultFixture.Success;
		Func<sbyte> create = static () => expected;
		Result<string, sbyte> actual = ResultFactory.Succeed<string, sbyte>(create);
		ResultAsserter.IsSuccessful(expected, actual);
	}

	#endregion Succeed overload

	#endregion Succeed
}
