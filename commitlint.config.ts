import type { UserConfig } from "@commitlint/types";
import { RuleConfigSeverity } from "@commitlint/types";

const ruleCompliance = {
	always: "always",
	never: "never"
} as const;
const fullStop = ".";
const defaultMaximumLength = 120;
const defaultMaximumLineLength = 300;
const defaultMinimumLength = 0;
const namingStyle = {
	lowerCase: "lower-case"
} as const;
const signatureLabel = "Signed-off-by:";
const rootConfiguration: UserConfig = {
	rules: {
		"body-case": [RuleConfigSeverity.Disabled],
		"body-empty": [RuleConfigSeverity.Warning, ruleCompliance.never],
		"body-full-stop": [RuleConfigSeverity.Error, ruleCompliance.always, fullStop],
		"body-leading-blank": [RuleConfigSeverity.Error, ruleCompliance.always],
		"body-max-length": [RuleConfigSeverity.Error, ruleCompliance.always, Number.POSITIVE_INFINITY],
		"body-max-line-length": [RuleConfigSeverity.Error, ruleCompliance.always, defaultMaximumLineLength],
		"body-min-length": [RuleConfigSeverity.Error, ruleCompliance.always, defaultMinimumLength],
		"footer-empty": [RuleConfigSeverity.Warning, ruleCompliance.never],
		"footer-leading-blank": [RuleConfigSeverity.Error, ruleCompliance.always],
		"footer-max-length": [RuleConfigSeverity.Error, ruleCompliance.always, Number.POSITIVE_INFINITY],
		"footer-max-line-length": [RuleConfigSeverity.Error, ruleCompliance.always, defaultMaximumLineLength],
		"footer-min-length": [RuleConfigSeverity.Error, ruleCompliance.always, defaultMinimumLength],
		"header-case": [RuleConfigSeverity.Warning, ruleCompliance.always, namingStyle.lowerCase],
		"header-full-stop": [RuleConfigSeverity.Error, ruleCompliance.never, fullStop],
		"header-max-length": [RuleConfigSeverity.Error, ruleCompliance.always, defaultMaximumLength],
		"header-min-length": [RuleConfigSeverity.Error, ruleCompliance.always, defaultMinimumLength],
		"header-trim": [RuleConfigSeverity.Error, ruleCompliance.always],
		"references-empty": [RuleConfigSeverity.Warning, ruleCompliance.never],
		"scope-case": [RuleConfigSeverity.Warning, ruleCompliance.always, namingStyle.lowerCase],
		"scope-empty": [RuleConfigSeverity.Warning, ruleCompliance.never],
		"scope-enum": [RuleConfigSeverity.Disabled],
		"scope-max-length": [RuleConfigSeverity.Error, ruleCompliance.always, defaultMaximumLength],
		"scope-min-length": [RuleConfigSeverity.Error, ruleCompliance.always, defaultMinimumLength],
		"signed-off-by": [RuleConfigSeverity.Warning, ruleCompliance.always, signatureLabel],
		"subject-case": [RuleConfigSeverity.Warning, ruleCompliance.always, namingStyle.lowerCase],
		"subject-empty": [RuleConfigSeverity.Error, ruleCompliance.never],
		"subject-exclamation-mark": [RuleConfigSeverity.Error, ruleCompliance.never],
		"subject-full-stop": [RuleConfigSeverity.Error, ruleCompliance.never, fullStop],
		"subject-max-length": [RuleConfigSeverity.Error, ruleCompliance.always, defaultMaximumLength],
		"subject-min-length": [RuleConfigSeverity.Error, ruleCompliance.always, defaultMinimumLength],
		"trailer-exists": [RuleConfigSeverity.Warning, ruleCompliance.always, signatureLabel],
		"type-case": [RuleConfigSeverity.Error, ruleCompliance.always, namingStyle.lowerCase],
		"type-empty": [RuleConfigSeverity.Error, ruleCompliance.never],
		"type-enum": [
			RuleConfigSeverity.Error,
			ruleCompliance.always,
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
		"type-max-length": [RuleConfigSeverity.Error, ruleCompliance.always, defaultMaximumLength],
		"type-min-length": [RuleConfigSeverity.Error, ruleCompliance.always, defaultMinimumLength]
	}
};

export default rootConfiguration;
