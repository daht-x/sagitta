// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.Monads.Exceptions.Helpers;

internal static class ResultExceptionMessages
{
	internal const string AccessToFailureWhenSuccessful =
		"The failure cannot be accessed when the state is successful.";

	internal const string AccessToSuccessWhenFailed = "The success cannot be accessed when the state is failed.";
}
