import type { UserConfig } from "@commitlint/types";
import { RuleConfigSeverity } from "@commitlint/types";

enum RuleCompliance {
	Always = "always",
	Never = "never"
}
const fullStop = ".";
const defaultMaximumLength = 120;
const defaultMaximumLineLength = 300;
const defaultMinimumLength = 0;
enum NamingStyle {
	LowerCase = "lower-case"
}
const signatureLabel = "Signed-off-by:";
const rootConfiguration: UserConfig = {
	rules: {
		"body-full-stop": [RuleConfigSeverity.Error, RuleCompliance.Always, fullStop],
		"body-leading-blank": [RuleConfigSeverity.Error, RuleCompliance.Always],
		"body-empty": [RuleConfigSeverity.Warning, RuleCompliance.Never],
		"body-max-length": [RuleConfigSeverity.Error, RuleCompliance.Always, Number.POSITIVE_INFINITY],
		"body-max-line-length": [RuleConfigSeverity.Error, RuleCompliance.Always, defaultMaximumLineLength],
		"body-min-length": [RuleConfigSeverity.Error, RuleCompliance.Always, defaultMinimumLength],
		"body-case": [RuleConfigSeverity.Disabled],
		"footer-leading-blank": [RuleConfigSeverity.Error, RuleCompliance.Always],
		"footer-empty": [RuleConfigSeverity.Warning, RuleCompliance.Never],
		"footer-max-length": [RuleConfigSeverity.Error, RuleCompliance.Always, Number.POSITIVE_INFINITY],
		"footer-max-line-length": [RuleConfigSeverity.Error, RuleCompliance.Always, defaultMaximumLineLength],
		"footer-min-length": [RuleConfigSeverity.Error, RuleCompliance.Always, defaultMinimumLength],
		"header-trim": [RuleConfigSeverity.Error, RuleCompliance.Always],
		"header-case": [RuleConfigSeverity.Warning, RuleCompliance.Always, NamingStyle.LowerCase],
		"header-full-stop": [RuleConfigSeverity.Error, RuleCompliance.Never, fullStop],
		"header-max-length": [RuleConfigSeverity.Error, RuleCompliance.Always, defaultMaximumLength],
		"header-min-length": [RuleConfigSeverity.Error, RuleCompliance.Always, defaultMinimumLength],
		"references-empty": [RuleConfigSeverity.Warning, RuleCompliance.Never],
		"scope-enum": [RuleConfigSeverity.Disabled],
		"scope-case": [RuleConfigSeverity.Warning, RuleCompliance.Always, NamingStyle.LowerCase],
		"scope-empty": [RuleConfigSeverity.Warning, RuleCompliance.Never],
		"scope-max-length": [RuleConfigSeverity.Error, RuleCompliance.Always, defaultMaximumLength],
		"scope-min-length": [RuleConfigSeverity.Error, RuleCompliance.Always, defaultMinimumLength],
		"subject-case": [RuleConfigSeverity.Warning, RuleCompliance.Always, NamingStyle.LowerCase],
		"subject-empty": [RuleConfigSeverity.Error, RuleCompliance.Never],
		"subject-full-stop": [RuleConfigSeverity.Error, RuleCompliance.Never, fullStop],
		"subject-max-length": [RuleConfigSeverity.Error, RuleCompliance.Always, defaultMaximumLength],
		"subject-min-length": [RuleConfigSeverity.Error, RuleCompliance.Always, defaultMinimumLength],
		"subject-exclamation-mark": [RuleConfigSeverity.Error, RuleCompliance.Never],
		"type-enum": [
			RuleConfigSeverity.Error,
			RuleCompliance.Always,
			[
				"compatibility",
				"feature",
				"test",
				"build",
				"dependency",
				"bug",
				"refactor",
				"style",
				"chore",
				"documentation",
				"workflow"
			]
		],
		"type-case": [RuleConfigSeverity.Error, RuleCompliance.Always, NamingStyle.LowerCase],
		"type-empty": [RuleConfigSeverity.Error, RuleCompliance.Never],
		"type-max-length": [RuleConfigSeverity.Error, RuleCompliance.Always, defaultMaximumLength],
		"type-min-length": [RuleConfigSeverity.Error, RuleCompliance.Always, defaultMinimumLength],
		"signed-off-by": [RuleConfigSeverity.Warning, RuleCompliance.Always, signatureLabel],
		"trailer-exists": [RuleConfigSeverity.Warning, RuleCompliance.Always, signatureLabel]
	}
};

export default rootConfiguration;
