// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.Monads;

/// <summary>Provide global factory methods to initialize <see cref="ValueResult{TFailure, TSuccess}" />.</summary>
public static class ValueResultFactory
{
	/// <summary>Creates a new failed result.</summary>
	/// <param name="failure">The possible failure.</param>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new failed result.</returns>
	[Pure]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ValueResult<TFailure, TSuccess> Fail<TFailure, TSuccess>(TFailure failure)
		where TFailure : struct, Enum
		where TSuccess : struct
		=> new(failure);

	/// <summary>Creates a new successful result.</summary>
	/// <param name="success">The expected success.</param>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <returns>A new successful result.</returns>
	[Pure]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ValueResult<TFailure, TSuccess> Succeed<TFailure, TSuccess>(TSuccess success)
		where TFailure : struct, Enum
		where TSuccess : struct
		=> new(success);
}
