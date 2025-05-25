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
		Constellation expected = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expected;
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;
		Result<string, Constellation> actual = ResultFactory.Catch(createSuccess, createFailure);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	[Fact]
	[Trait(@base, memberCatch)]
	public void Catch_ExceptionInCreateSuccessPlusCreateFailure_FailedResult()
	{
		Func<Constellation> createSuccess = () => throw new InvalidOperationException();
		Func<InvalidOperationException, string> createFailure = exception => exception.Message;
		const string expected = "Operation is not valid due to the current state of the object.";
		Result<string, Constellation> actual = ResultFactory.Catch(createSuccess, createFailure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	#endregion

	#region Fail

	#region Overload

	[Fact]
	[Trait(@base, memberFail)]
	public void Fail_Failure_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Result<string, Constellation> actual = ResultFactory.Fail<string, Constellation>(expected);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberFail)]
	public void Fail_CreateFailure_FailedResult()
	{
		const string expected = ResultFixture.Failure;
		Func<string> createFailure = () => expected;
		Result<string, Constellation> actual = ResultFactory.Fail<string, Constellation>(createFailure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	#endregion

	#endregion

	#region Succeed

	#region Overload

	[Fact]
	[Trait(@base, memberSucceed)]
	public void Succeed_Success_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		Result<string, Constellation> actual = ResultFactory.Succeed<string, Constellation>(expected);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberSucceed)]
	public void Succeed_CreateSuccess_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expected;
		Result<string, Constellation> actual = ResultFactory.Succeed<string, Constellation>(createSuccess);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#endregion
}
