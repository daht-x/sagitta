// ---------------------------------------------------------------------------------------------------------- 
// Copyright (c) David Andrés Hernández Triana. All rights reserved. 
// Licensed under the MIT License. Please refer to the license file in the project root for more information. 
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core;

/// <summary>Represents the absence of a specific value, explicitly simulating the <see langword="void"/> type.</summary>
public readonly record struct Unit
{
	/// <summary>The placeholder that indicates the discarding of a specific value.</summary>
	public static Unit Default
		=> default;
}
