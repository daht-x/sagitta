namespace Daht.Sagitta.Core.UnitTest.Monads;

public sealed class ResultFactoryTest
{
	private const string root = nameof(ResultFactory);

	private const string @catch = nameof(ResultFactory.Catch);

	private const string ensure = nameof(ResultFactory.Ensure);

	private const string succeed = nameof(ResultFactory.Succeed);

	private const string fail = nameof(ResultFactory.Fail);

	#region Catch

	[Fact]
	[Trait(root, @catch)]
	public void Catch_CreateSuccessPlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Constellation CreateSuccess()
			=> expectedSuccess;
		static string CreateFailure(InvalidOperationException exception)
			=> exception.Message;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Catch<InvalidOperationException, Constellation, string>(CreateSuccess, CreateFailure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	[Fact]
	[Trait(root, @catch)]
	public void Catch_ExceptionPlusCreateFailure_FailedResult()
	{
		// Arrange
		static Constellation CreateSuccess()
			=> throw new InvalidOperationException();
		static string CreateFailure(InvalidOperationException exception)
			=> exception.Message;
		const string expectedFailure = "Operation is not valid due to the current state of the object.";

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Catch<InvalidOperationException, Constellation, string>(CreateSuccess, CreateFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#region Ensure

	#region Overload

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusTruePredicatePlusFailure_FailedResult()
	{
		// Arrange
		Constellation success = ResultFixture.Success;
		static bool Predicate(Constellation _)
			=> true;
		const string expectedFailure = ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(success, Predicate, expectedFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusFalsePredicatePlusFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		static bool Predicate(Constellation _)
			=> false;
		const string failure = ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(expectedSuccess, Predicate, failure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusTruePredicatePlusCreateFailure_FailedResult()
	{
		// Arrange
		Constellation success = ResultFixture.Success;
		static bool Predicate(Constellation _)
			=> true;
		const string expectedFailure = ResultFixture.Failure;
		static string CreateFailure(Constellation _)
			=> expectedFailure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(success, Predicate, CreateFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessPlusFalsePredicatePlusCreateFailure_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		static bool Predicate(Constellation _)
			=> false;
		static string CreateFailure(Constellation _)
			=> ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Ensure(expectedSuccess, Predicate, CreateFailure);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#endregion

	#region Succeed

	#region Overload

	[Fact]
	[Trait(root, succeed)]
	public void Succeed_Success_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Succeed<Constellation, string>(expectedSuccess);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, succeed)]
	public void Succeed_CreateSuccess_SuccessfulResult()
	{
		// Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Constellation CreateSuccess()
			=> expectedSuccess;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Succeed<Constellation, string>(CreateSuccess);

		// Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#endregion

	#region Fail

	#region Overload

	[Fact]
	[Trait(root, fail)]
	public void Fail_Failure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Fail<Constellation, string>(expectedFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, fail)]
	public void Fail_CreateFailure_FailedResult()
	{
		// Arrange
		const string expectedFailure = ResultFixture.Failure;
		static string CreateFailure()
			=> expectedFailure;

		// Act
		Result<Constellation, string> actualResult = ResultFactory.Fail<Constellation, string>(CreateFailure);

		// Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#endregion
}
