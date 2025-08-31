// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.Results;

/// <summary>Provide global factory methods to initialize <see cref="ValueResult{TFailure, TSuccess}" />.</summary>
public static class ValueResultFactory
{
	/// <summary>Creates a new failed result.</summary>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <param name="failure">The possible failure.</param>
	/// <returns>A new failed result.</returns>
	public static ValueResult<TFailure, TSuccess> Fail<TFailure, TSuccess>(TFailure failure)
		where TFailure : struct, Enum
		where TSuccess : struct
		=> new(failure);

	/// <summary>Creates a new successful result.</summary>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <param name="success">The expected success.</param>
	/// <returns>A new successful result.</returns>
	public static ValueResult<TFailure, TSuccess> Succeed<TFailure, TSuccess>(TSuccess success)
		where TFailure : struct, Enum
		where TSuccess : struct
		=> new(success);
}
