import { ruleSeverity, ruleCompliance } from "./linter-configuration.js";

const namingStyle = {
	lowerCase: "lower-case"
};
const defaultMaximumLength = 100;
const defaultMaximumLineLength = 400;
const defaultMinimumLength = 0;
const rootConfiguration = {
	rules: {
		"body-full-stop": [ruleSeverity.error, ruleCompliance.never],
		"body-leading-blank": [ruleSeverity.error, ruleCompliance.always],
		"body-empty": [ruleSeverity.warning, ruleCompliance.never],
		"body-max-length": [ruleSeverity.error, ruleCompliance.always, Infinity],
		"body-max-line-length": [ruleSeverity.error, ruleCompliance.always, defaultMaximumLineLength],
		"body-min-length": [ruleSeverity.error, ruleCompliance.always, defaultMinimumLength],
		"body-case": [ruleSeverity.disabled],
		"footer-leading-blank": [ruleSeverity.error, ruleCompliance.always],
		"footer-empty": [ruleSeverity.warning, ruleCompliance.never],
		"footer-max-length": [ruleSeverity.error, ruleCompliance.always, Infinity],
		"footer-max-line-length": [ruleSeverity.error, ruleCompliance.always, defaultMaximumLineLength],
		"footer-min-length": [ruleSeverity.error, ruleCompliance.always, defaultMinimumLength],
		"header-case": [ruleSeverity.warning, ruleCompliance.always, namingStyle.lowerCase],
		"header-full-stop": [ruleSeverity.error, ruleCompliance.never],
		"header-max-length": [ruleSeverity.error, ruleCompliance.always, defaultMaximumLength],
		"header-min-length": [ruleSeverity.error, ruleCompliance.always, defaultMinimumLength],
		"references-empty": [ruleSeverity.warning, ruleCompliance.never],
		"scope-enum": [ruleSeverity.disabled],
		"scope-case": [ruleSeverity.warning, ruleCompliance.always, namingStyle.lowerCase],
		"scope-empty": [ruleSeverity.warning, ruleCompliance.never],
		"scope-max-length": [ruleSeverity.error, ruleCompliance.always, defaultMaximumLength],
		"scope-min-length": [ruleSeverity.error, ruleCompliance.always, defaultMinimumLength],
		"subject-case": [ruleSeverity.warning, ruleCompliance.always, namingStyle.lowerCase],
		"subject-empty": [ruleSeverity.error, ruleCompliance.never],
		"subject-full-stop": [ruleSeverity.error, ruleCompliance.never],
		"subject-max-length": [ruleSeverity.error, ruleCompliance.always, defaultMaximumLength],
		"subject-min-length": [ruleSeverity.error, ruleCompliance.always, defaultMinimumLength],
		"subject-exclamation-mark": [ruleSeverity.error, ruleCompliance.never],
		"type-enum": [
			ruleSeverity.error,
			ruleCompliance.always,
			["feature", "test", "build", "refactor", "style", "chore", "documentation", "workflow"]
		],
		"type-case": [ruleSeverity.error, ruleCompliance.always, namingStyle.lowerCase],
		"type-empty": [ruleSeverity.error, ruleCompliance.never],
		"type-max-length": [ruleSeverity.error, ruleCompliance.always, defaultMaximumLength],
		"type-min-length": [ruleSeverity.error, ruleCompliance.always, defaultMinimumLength],
		"signed-off-by": [ruleSeverity.warning, ruleCompliance.always],
		"trailer-exists": [ruleSeverity.warning, ruleCompliance.always]
	}
};

export default rootConfiguration;
