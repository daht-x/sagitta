namespace Daht.Sagitta.Core.Monads;

/// <summary>Reference point to initialize <see cref="Result{TSuccess, TFailure}"/>.</summary>
public static class Result
{
	/// <summary>Creates a new failed result if <paramref name="success"/> is <see langword="null"/>; otherwise, creates a new successful result.</summary>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="success">The expected success.</param>
	/// <param name="failure">
	///		<para>The possible failure.</para>
	///     <para>If <paramref name="failure"/> is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <returns>A new failed result if <paramref name="success"/> is <see langword="null"/>; otherwise, a new successful result.</returns>
	/// <exception cref="ArgumentNullException"/>
	public static Result<TSuccess, TFailure> Ensure<TSuccess, TFailure>(TSuccess? success, TFailure failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> success is null
			? Fail<TSuccess, TFailure>(failure)
			: Succeed<TSuccess, TFailure>(success);

	/// <summary>Creates a new failed result if <paramref name="success"/> is <see langword="null"/>; otherwise, creates a new successful result.</summary>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="success">The expected success.</param>
	/// <param name="createFailure">
	///     <para>Creates the possible failure.</para>
	///     <para>If <paramref name="createFailure"/> is <see langword="null"/> or its value is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <returns>A new failed result if <paramref name="success"/> is <see langword="null"/>; otherwise, a new successful result.</returns>
	///	<exception cref="ArgumentNullException"/>
	public static Result<TSuccess, TFailure> Ensure<TSuccess, TFailure>(TSuccess? success, Func<TFailure> createFailure)
		where TSuccess : notnull
		where TFailure : notnull
		=> success is null
			? Fail<TSuccess, TFailure>(createFailure)
			: Succeed<TSuccess, TFailure>(success);

	/// <summary>Creates a new failed result if the value of <paramref name="createSuccess"/> is <see langword="null"/>; otherwise, creates a new successful result.</summary>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="createSuccess">
	///     <para>Creates the expected success.</para>
	///     <para>If <paramref name="createSuccess"/> is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <param name="failure">
	///		<para>The possible failure.</para>
	///     <para>If <paramref name="failure"/> is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <returns>A new failed result if the value of <paramref name="createSuccess"/> is <see langword="null"/>; otherwise, a new successful result.</returns>
	///	<exception cref="ArgumentNullException"/>
	public static Result<TSuccess, TFailure> Ensure<TSuccess, TFailure>(Func<TSuccess?> createSuccess, TFailure failure)
		where TSuccess : notnull
		where TFailure : notnull
	{
		ArgumentNullException.ThrowIfNull(createSuccess);
		TSuccess? success = createSuccess();
		return success is null
			? Fail<TSuccess, TFailure>(failure)
			: Succeed<TSuccess, TFailure>(success);
	}

	/// <summary>Creates a new failed result if the value of <paramref name="createSuccess"/> is <see langword="null"/>; otherwise, creates a new successful result.</summary>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="createSuccess">
	///     <para>Creates the expected success.</para>
	///     <para>If <paramref name="createSuccess"/> is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <param name="createFailure">
	///     <para>Creates the possible failure.</para>
	///     <para>If <paramref name="createFailure"/> is <see langword="null"/> or its value is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <returns>A new failed result if the value of <paramref name="createSuccess"/> is <see langword="null"/>; otherwise, a new successful result.</returns>
	/// <exception cref="ArgumentNullException"/>
	public static Result<TSuccess, TFailure> Ensure<TSuccess, TFailure>(Func<TSuccess?> createSuccess, Func<TFailure> createFailure)
		where TSuccess : notnull
		where TFailure : notnull
	{
		ArgumentNullException.ThrowIfNull(createSuccess);
		TSuccess? success = createSuccess();
		return success is null
			? Fail<TSuccess, TFailure>(createFailure)
			: Succeed<TSuccess, TFailure>(success);
	}

	/// <summary>Creates a new failed result if the value of <paramref name="createSuccess"/> throws <typeparamref name="TException"/>; otherwise, creates a new successful result.</summary>
	/// <typeparam name="TException">Type of possible exception.</typeparam>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="createSuccess">
	///		<para>Creates the expected success.</para>
	///     <para>If <paramref name="createSuccess"/> is <see langword="null"/> or its value is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <param name="createFailure">
	///		<para>Creates the possible failure in combination with <typeparamref name="TException"/>.</para>
	///     <para>If <paramref name="createFailure"/> is <see langword="null"/> or its value is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <returns>A new failed result if the value of <paramref name="createSuccess"/> throws <typeparamref name="TException"/>; otherwise, a new successful result.</returns>
	/// <exception cref="ArgumentNullException"/>
	public static Result<TSuccess, TFailure> Catch<TException, TSuccess, TFailure>(Func<TSuccess> createSuccess, Func<TException, TFailure> createFailure)
		where TException : Exception
		where TSuccess : notnull
		where TFailure : notnull
	{
		try
		{
			return Succeed<TSuccess, TFailure>(createSuccess);
		}
		catch (TException exception)
		{
			ArgumentNullException.ThrowIfNull(createFailure);
			TFailure failure = createFailure(exception) ?? throw new ArgumentNullException(nameof(createFailure));
			return Fail<TSuccess, TFailure>(failure);
		}
	}

	/// <summary>Creates a new successful result.</summary>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="createSuccess">
	///     <para>Creates the expected success.</para>
	///     <para>If <paramref name="createSuccess"/> is <see langword="null"/> or its value is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <returns>A new successful result.</returns>
	/// <exception cref="ArgumentNullException"/>
	public static Result<TSuccess, TFailure> Succeed<TSuccess, TFailure>(Func<TSuccess> createSuccess)
		where TSuccess : notnull
		where TFailure : notnull
	{
		ArgumentNullException.ThrowIfNull(createSuccess);
		TSuccess success = createSuccess() ?? throw new ArgumentNullException(nameof(createSuccess));
		return Succeed<TSuccess, TFailure>(success);
	}

	/// <summary>Creates a new successful result.</summary>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="success">
	///		<para>The expected success.</para>
	///     <para>If <paramref name="success"/> is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <returns>A new successful result.</returns>
	/// <exception cref="ArgumentNullException"/>
	public static Result<TSuccess, TFailure> Succeed<TSuccess, TFailure>(TSuccess success)
		where TSuccess : notnull
		where TFailure : notnull
		=> success is null
			? throw new ArgumentNullException(nameof(success))
			: new Result<TSuccess, TFailure>()
			{
				IsSuccessful = true,
				Success = success
			};

	/// <summary>Creates a new failed result.</summary>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="createFailure">
	///     <para>Creates the possible failure.</para>
	///     <para>If <paramref name="createFailure"/> is <see langword="null"/> or its value is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <returns>A new failed result.</returns>
	/// <exception cref="ArgumentNullException"/>
	public static Result<TSuccess, TFailure> Fail<TSuccess, TFailure>(Func<TFailure> createFailure)
		where TSuccess : notnull
		where TFailure : notnull
	{
		ArgumentNullException.ThrowIfNull(createFailure);
		TFailure failure = createFailure() ?? throw new ArgumentNullException(nameof(createFailure));
		return Fail<TSuccess, TFailure>(failure);
	}

	/// <summary>Creates a new failed result.</summary>
	/// <typeparam name="TSuccess">Type of expected success.</typeparam>
	/// <typeparam name="TFailure">Type of possible failure.</typeparam>
	/// <param name="failure">
	///     <para>The possible failure.</para>
	///     <para>If <paramref name="failure"/> is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <returns>A new failed result.</returns>
	/// <exception cref="ArgumentNullException"/>
	public static Result<TSuccess, TFailure> Fail<TSuccess, TFailure>(TFailure failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> failure is null
			? throw new ArgumentNullException(nameof(failure))
			: new Result<TSuccess, TFailure>()
			{
				IsFailed = true,
				Failure = failure
			};
}

/// <summary>Type that encapsulates both the expected success and the possible failure of a given action.</summary>
/// <typeparam name="TSuccess">Type of expected success.</typeparam>
///	<typeparam name="TFailure">Type of possible failure.</typeparam>
public readonly record struct Result<TSuccess, TFailure>
	where TSuccess : notnull
	where TFailure : notnull
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
		=> Result.Succeed<TSuccess, TFailure>(success);

	/// <summary>Creates a new successful result.</summary>
	/// <param name="createSuccess">
	///     <para>Creates the expected success.</para>
	///     <para>If <paramref name="createSuccess"/> is <see langword="null"/> or its value is <see langword="null"/>, <seealso cref="ArgumentNullException"/> will be thrown.</para>
	/// </param>
	/// <returns>A new successful result.</returns>
	/// <exception cref="ArgumentNullException"/>
	public static implicit operator Result<TSuccess, TFailure>(Func<TSuccess> createSuccess)
		=> Result.Succeed<TSuccess, TFailure>(createSuccess);
}
