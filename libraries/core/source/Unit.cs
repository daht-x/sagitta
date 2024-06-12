namespace Daht.Sagitta.Core.Primitives;

/// <summary>Type intended to handle the absence of a specific value (explicit simulation of the <see langword="void"/> type).</summary>
public readonly record struct Unit
{
	/// <summary>The placeholder that indicates the discarding of a specific value.</summary>
	public static Unit Discarder
		=> new();
}
