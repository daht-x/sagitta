namespace Daht.Sagitta.Core.Monads;

/// <summary>Type that encapsulates both the expected success and the possible failure of a given action.</summary>
/// <typeparam name="TSuccess">Type of expected success.</typeparam>
///	<typeparam name="TFailure">Type of possible failure.</typeparam>
public readonly record struct Result<TSuccess, TFailure>
{
	/// <summary>Indicates whether the status is successful or <see langword="default"/>.</summary>
	public bool IsSuccessfulOrDefault => IsSuccessful || IsDefault;

	/// <summary>Indicates whether the status is failed or <see langword="default"/>.</summary>
	public bool IsFailedOrDefault => IsFailed || IsDefault;

	/// <summary>Indicates whether the status is <see langword="default"/>.</summary>
	public bool IsDefault => this is
	{
		IsSuccessful: false,
		IsFailed: false
	};

	/// <summary>Indicates whether the status is successful.</summary>
	public bool IsSuccessful { get; internal init; }

	/// <summary>The expected success.</summary>
	public TSuccess Success { get; internal init; }

	/// <summary>Indicates whether the status is failed.</summary>
	public bool IsFailed { get; internal init; }

	/// <summary>The possible failure.</summary>
	public TFailure Failure { get; internal init; }

	/// <summary>Creates a new successful result.</summary>
	/// <param name="success">
	///		<para>The expected success.</para>
	///     <para>If <paramref name="success"/> is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <returns>A new successful result.</returns>
	/// <exception cref="ArgumentNullException"/>
	public static implicit operator Result<TSuccess, TFailure>(TSuccess success)
		=> ResultFactory.Succeed<TSuccess, TFailure>(success);

	/// <summary>Creates a new failed result.</summary>
	/// <param name="failure">
	///     <para>The possible failure.</para>
	///     <para>If <paramref name="failure"/> is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <returns>A new failed result.</returns>
	/// <exception cref="ArgumentNullException"/>
	public static implicit operator Result<TSuccess, TFailure>(TFailure failure)
		=> ResultFactory.Fail<TSuccess, TFailure>(failure);
}
