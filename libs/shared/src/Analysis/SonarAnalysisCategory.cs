// ----------------------------------------------------------------------------------------------------------
// Copyright (c) David Andrés Hernández Triana. All rights reserved.
// Licensed under the MIT License. Please refer to the license file in the project root for more information.
// ----------------------------------------------------------------------------------------------------------

namespace Daht.Sagitta.Shared.Analysis;

public static class SonarAnalysisCategory
{
	public const string Name = "Sonar";

	public static class Rules
	{
		public const string BooleanLiteralsShouldNotBeRedundant = "S1125: Boolean literals should not be redundant";
	}
}
