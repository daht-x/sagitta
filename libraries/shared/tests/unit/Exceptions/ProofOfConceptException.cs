// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Shared.UnitTests.Exceptions;

[SuppressMessage(DesignAnalysisCategory.Name, DesignAnalysisCategory.Rules.ImplementStandardExceptionConstructors)]
[SuppressMessage(RoslynatorAnalysisCategory.Name, RoslynatorAnalysisCategory.Rules.ImplementExceptionConstructors)]
public sealed class ProofOfConceptException() : Exception(DefaultMessage)
{
	public const string DefaultMessage = "This is a proof of concept";

	[DoesNotReturn]
	public static void Throw()
		=> throw new ProofOfConceptException();
}
