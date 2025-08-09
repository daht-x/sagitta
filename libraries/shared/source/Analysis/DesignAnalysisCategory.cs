// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Shared.Analysis;

public static class DesignAnalysisCategory
{
	public const string Name = "Design";

	public static class Rules
	{
		public const string ValidateArgumentsOfPublicMethods = "CA1062: Validate arguments of public methods";

		public const string ImplementStandardExceptionConstructors =
			"CA1032: Implement standard exception constructors";
	}
}
