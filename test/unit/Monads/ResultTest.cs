namespace Daht.Sagitta.Core.UnitTest.Monads;

public sealed class ResultTest
{
	private const string root = nameof(Result<object, object>);

	private const string constructor = "Constructor";

	private const string implicitOperator = "Implicit Operator";

	private const string ensure = nameof(Result<object, object>.Ensure);

	#region Constructor

	#region Overload

	[Fact]
	[Trait(root, constructor)]
	public void Constructor_Success_SuccessfulResult()
	{
		//Arrange
		Constellation expectedSuccess = ResultFixture.Success;

		//Act
		Result<Constellation, string> actualResult = new(expectedSuccess);

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, constructor)]
	public void Constructor_Failure_FailedResult()
	{
		//Arrange
		const string expectedFailure = ResultFixture.Failure;

		//Act
		Result<Constellation, string> actualResult = new(expectedFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#endregion

	#region Implicit Operator

	#region Overload

	[Fact]
	[Trait(root, implicitOperator)]
	public void ImplicitOperator_Success_SuccessfulResult()
	{
		//Arrange
		Constellation expectedSuccess = ResultFixture.Success;

		//Act
		Result<Constellation, string> actualResult = expectedSuccess;

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion

	#region Overload

	[Fact]
	[Trait(root, implicitOperator)]
	public void ImplicitOperator_Failure_FailedResult()
	{
		//Arrange
		const string expectedFailure = ResultFixture.Failure;

		//Act
		Result<Constellation, string> actualResult = expectedFailure;

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	#endregion

	#endregion

	#region Ensure

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_FailedResultPlusFalsePredicatePlusFailure_FailedResult()
	{
		//Arrange
		const string expectedFailure = ResultFixture.Failure;
		Func<Constellation, bool> predicate = static _ => false;
		string failure = ResultFixture.RandomFailure;

		//Act
		Result<Constellation, string> actualResult = ResultMother
			.Fail(expectedFailure)
			.Ensure(predicate, failure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessfulResultPlusTruePredicatePlusFailure_FailedResult()
	{
		//Arrange
		Func<Constellation, bool> predicate = static _ => true;
		const string expectedFailure = ResultFixture.Failure;

		//Act
		Result<Constellation, string> actualResult = ResultMother
			.Succeed()
			.Ensure(predicate, expectedFailure);

		//Assert
		ResultAsserter.AreFailed(expectedFailure, actualResult);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessfulResultPlusFalsePredicatePlusFailure_SuccessfulResult()
	{
		//Arrange
		Constellation expectedSuccess = ResultFixture.Success;
		Func<Constellation, bool> predicate = static _ => false;
		const string failure = ResultFixture.Failure;

		//Act
		Result<Constellation, string> actualResult = ResultMother
			.Succeed(expectedSuccess)
			.Ensure(predicate, failure);

		//Assert
		ResultAsserter.AreSuccessful(expectedSuccess, actualResult);
	}

	#endregion
}
