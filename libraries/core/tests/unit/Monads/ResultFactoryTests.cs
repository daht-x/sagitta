namespace Daht.Sagitta.Core.UnitTests.Monads;

public sealed class ResultFactoryTests
{
	private const string @base = nameof(ResultFactory);

	private const string memberCatch = nameof(ResultFactory.Catch);

	private const string memberEnsure = nameof(ResultFactory.Ensure);

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

	#region Ensure

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		Constellation success = ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => true;
		const string expected = ResultFixture.Failure;
		Func<Constellation, string> createFailure = _ => expected;
		Result<string, Constellation> actual = ResultFactory.Ensure(success, predicate, createFailure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => false;
		Func<Constellation, string> createFailure = _ => ResultFixture.Failure;
		Result<string, Constellation> actual = ResultFactory.Ensure(expected, predicate, createFailure);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		Func<Constellation> createSuccess = () => ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => true;
		const string expected = ResultFixture.Failure;
		Func<Constellation, string> createFailure = _ => expected;
		Result<string, Constellation> actual = ResultFactory.Ensure(createSuccess, predicate, createFailure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expected;
		Func<Constellation, bool> predicate = _ => false;
		Func<Constellation, string> createFailure = _ => ResultFixture.Failure;
		Result<string, Constellation> actual = ResultFactory.Ensure(createSuccess, predicate, createFailure);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusTruePredicatePlusFailure_FailedResult()
	{
		Func<Constellation> createSuccess = () => ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => true;
		const string expected = ResultFixture.Failure;
		Result<string, Constellation> actual = ResultFactory.Ensure(createSuccess, predicate, expected);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusFalsePredicatePlusFailure_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expected;
		Func<Constellation, bool> predicate = _ => false;
		const string failure = ResultFixture.Failure;
		Result<string, Constellation> actual = ResultFactory.Ensure(createSuccess, predicate, failure);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusTruePredicatePlusFailure_FailedResult()
	{
		Constellation success = ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => true;
		const string expected = ResultFixture.Failure;
		Result<string, Constellation> actual = ResultFactory.Ensure(success, predicate, expected);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusFalsePredicatePlusFailure_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		Func<Constellation, bool> predicate = _ => false;
		const string failure = ResultFixture.Failure;
		Result<string, Constellation> actual = ResultFactory.Ensure(expected, predicate, failure);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		Constellation success = ResultFixture.Success;
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		const string expected = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = (_, _) => expected;
		Result<string, Constellation> actual = ResultFactory.Ensure(success, createAuxiliary, predicate, createFailure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusCreateAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => false;
		Func<Constellation, string, string> createFailure = (_, _) => ResultFixture.Failure;
		Result<string, Constellation> actual =
			ResultFactory.Ensure(expected, createAuxiliary, predicate, createFailure);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusCreateAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		Func<Constellation> createSuccess = () => ResultFixture.Success;
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		const string expected = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = (_, _) => expected;
		Result<string, Constellation> actual =
			ResultFactory.Ensure(createSuccess, createAuxiliary, predicate, createFailure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusCreateAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expected;
		Func<string> createAuxiliary = () => ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => false;
		Func<Constellation, string, string> createFailure = (_, _) => ResultFixture.Failure;
		Result<string, Constellation> actual =
			ResultFactory.Ensure(createSuccess, createAuxiliary, predicate, createFailure);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		Func<Constellation> createSuccess = () => ResultFixture.Success;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		const string expected = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = (_, _) => expected;
		Result<string, Constellation> actual = ResultFactory.Ensure(createSuccess, auxiliary, predicate, createFailure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_CreateSuccessPlusAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		Func<Constellation> createSuccess = () => expected;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => false;
		Func<Constellation, string, string> createFailure = (_, _) => ResultFixture.Failure;
		Result<string, Constellation> actual = ResultFactory.Ensure(createSuccess, auxiliary, predicate, createFailure);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusAuxiliaryPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		Constellation success = ResultFixture.Success;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => true;
		const string expected = ResultFixture.Failure;
		Func<Constellation, string, string> createFailure = (_, _) => expected;
		Result<string, Constellation> actual = ResultFactory.Ensure(success, auxiliary, predicate, createFailure);
		ResultAsserter.CheckIfAreFailed(expected, actual);
	}

	[Fact]
	[Trait(@base, memberEnsure)]
	public void Ensure_SuccessPlusAuxiliaryPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		Constellation expected = ResultFixture.Success;
		const string auxiliary = ResultFixture.Auxiliary;
		Func<Constellation, string, bool> predicate = (_, _) => false;
		Func<Constellation, string, string> createFailure = (_, _) => ResultFixture.Failure;
		Result<string, Constellation> actual = ResultFactory.Ensure(expected, auxiliary, predicate, createFailure);
		ResultAsserter.CheckIfAreSuccessful(expected, actual);
	}

	#endregion

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
