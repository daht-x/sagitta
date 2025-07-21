// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Core.UnitTests.Exceptions;

[SuppressMessage(AnalysisCategories.Design, AnalysisRules.ImplementStandardExceptionConstructors)]
public sealed class ProofOfConceptException : Exception
{
	internal const string DefaultMessage = "This is a proof of concept";

	internal ProofOfConceptException()
		: base(DefaultMessage)
	{
	}

	internal static void Throw()
		=> throw new ProofOfConceptException();
}
