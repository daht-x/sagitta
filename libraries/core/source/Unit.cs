// ---------------------------------------------------------------------------------------------------------- 
// Copyright (c) David Andrés Hernández Triana. All rights reserved. 
// Licensed under the MIT License. Please refer to the license file in the project root for more information. 
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core;

/// <summary>Represents the absence of a specific value, explicitly simulating the <see langword="void"/> type.</summary>
public readonly struct Unit : IEquatable<Unit>
{
	/// <summary>The placeholder that indicates the discarding of a value.</summary>
	public static Unit Default
		=> default;

	/// <summary>Determines whether the left unit is not equal to the right unit.</summary>
	/// <param name="left">The main unit.</param>
	/// <param name="right">The unit to compare.</param>
	/// <returns><see langword="true" /> if the left unit is not equal to the right unit; otherwise, <see langword="false" />.</returns>
	[Pure]
	public static bool operator !=(Unit left, Unit right)
		=> !(left == right);

	/// <summary>Determines whether the left unit is equal to the right unit.</summary>
	/// <param name="left">The main unit.</param>
	/// <param name="right">The unit to compare.</param>
	/// <returns><see langword="true" /> if the left unit is equal to the right unit; otherwise, <see langword="false" />.</returns>
	[Pure]
	public static bool operator ==(Unit left, Unit right)
		=> left.Equals(right);

	/// <summary>Determines whether the specified unit is equal to the current unit.</summary>
	/// <param name="obj">The unit to compare with the current reference.</param>
	/// <returns><see langword="true" /> if the specified unit is equal to the current unit; otherwise, <see langword="false" />.</returns>
	[Pure]
	public override bool Equals(object? obj)
		=> obj is Unit;

	/// <summary>Determines whether the specified unit is equal to the current unit.</summary>
	/// <param name="other">The unit to compare with the current reference.</param>
	/// <returns><see langword="true" /> if the specified unit is equal to the current unit; otherwise, <see langword="false" />.</returns>
	[Pure]
	public bool Equals(Unit other)
		=> true;

	/// <summary>Gets the hash code of the current unit.</summary>
	/// <returns>The hash code of the current unit.</returns>
	[Pure]
	public override int GetHashCode()
		=> 0;

	/// <summary>Gets the value of the current unit.</summary>
	/// <returns>The value of the current unit.</returns>
	[Pure]
	public override string ToString()
		=> string.Empty;
}
