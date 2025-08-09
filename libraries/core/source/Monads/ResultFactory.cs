// ---------------------------------------------------------------------------------------------------------- 
// Copyright (c) David Andrés Hernández Triana. All rights reserved. 
// Licensed under the MIT License. Please refer to the license file in the project root for more information. 
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.Monads;

/// <summary>Provide global factory methods to initialize <see cref="Result{TFailure,TSuccess}" />.</summary>
[SuppressMessage(DesignAnalysisCategory.Name, DesignAnalysisCategory.Rules.ValidateArgumentsOfPublicMethods)]
public static class ResultFactory
{
	/// <summary>Treats <typeparamref name="TException" /> as a new failed result.</summary>
	/// <param name="createSuccess">Creates an expected success.</param>
	/// <param name="createFailure">Creates a possible failure.</param>
	/// <typeparam name="TException">Type of possible exception.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new failed result if the value of <paramref name="createSuccess" /> throws <typeparamref name="TException" />; otherwise, a new successful result.</returns>
	public static Result<TFailure, TSuccess> Catch<TException, TFailure, TSuccess>(
		Func<TSuccess> createSuccess, Func<TException, TFailure> createFailure
	)
		where TException : Exception
	{
		try
		{
			return Succeed<TFailure, TSuccess>(createSuccess);
		}
		catch (TException exception)
		{
			return Fail<TFailure, TSuccess>(createFailure(exception));
		}
	}

	/// <summary>Creates a new failed result.</summary>
	/// <param name="failure">The possible failure.</param>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new failed result.</returns>
	public static Result<TFailure, TSuccess> Fail<TFailure, TSuccess>(TFailure failure)
		=> new(failure);

	/// <summary>Creates a new failed result.</summary>
	/// <param name="createFailure">Creates a possible failure.</param>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new failed result.</returns>
	public static Result<TFailure, TSuccess> Fail<TFailure, TSuccess>(Func<TFailure> createFailure)
		=> new(createFailure());

	/// <summary>Creates a new successful result.</summary>
	/// <param name="success">The expected success.</param>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new successful result.</returns>
	public static Result<TFailure, TSuccess> Succeed<TFailure, TSuccess>(TSuccess success)
		=> new(success);

	/// <summary>Creates a new successful result.</summary>
	/// <param name="createSuccess">Creates an expected success.</param>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new successful result.</returns>
	public static Result<TFailure, TSuccess> Succeed<TFailure, TSuccess>(Func<TSuccess> createSuccess)
		=> new(createSuccess());
}
