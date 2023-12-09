namespace Daht.Sagitta.Core.UnitTest.Monads.Extensions;

public sealed class ResultExtensionTest
{
	private const string root = nameof(ResultExtension);

	private const string ensure = nameof(ResultExtension.Ensure);

	#region Ensure

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_DefaultResultPlusFalsePredicatePlusFailure_DefaultResult()
	{
		//Arrange
		Func<Constellation, bool> predicate = static _ => false;
		const string failure = ResultFixture.Failure;

		//Act
		Result<Constellation, string> actualResult = ResultMother
			.Default
			.Ensure(predicate, failure);

		//Assert
		ResultAsserter.IsDefault(actualResult);
	}

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
	public void Ensure_SuccessfulResultPlusNullPredicatePlusFailure_ArgumentNullException()
	{
		//Arrange
		const Func<Constellation, bool> predicate = null!;
		const string failure = ResultFixture.Failure;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			static () => _ = ResultMother
				.Succeed()
				.Ensure(predicate, failure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(predicate), actualException);
	}

	[Fact]
	[Trait(root, ensure)]
	public void Ensure_SuccessfulResultPlusTruePredicatePlusNullFailure_ArgumentNullException()
	{
		//Arrange
		Func<Constellation, bool> predicate = static _ => true;
		const string failure = null!;

		//Act
		ArgumentNullException? actualException = ExceptionHandler.Catch<ArgumentNullException>(
			() => _ = ResultMother
				.Succeed()
				.Ensure(predicate, failure)
		);

		//Assert
		ArgumentNullExceptionAsserter.AreEqualParameterNames(nameof(failure), actualException);
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
