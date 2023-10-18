import { FlatCompat } from "@eslint/eslintrc";
import eslintJs from "@eslint/js";
import importPlugin from "eslint-plugin-import";
import { ruleSeverity, ruleCompliance } from "./linter-configuration.js";

const eslintJsConfiguration = eslintJs.configs.recommended;
const compatibilityManager = new FlatCompat();
const airbnbConfiguration = compatibilityManager.extends("airbnb-base");
const rootConfiguration = [
	eslintJsConfiguration,
	...airbnbConfiguration,
	{
		plugins: {
			importPlugin
		},
		rules: {
			indent: [ruleSeverity.error, "tab"],
			"no-tabs": ruleSeverity.disabled,
			quotes: [ruleSeverity.error, "double"],
			"arrow-parens": [ruleSeverity.error, "as-needed"],
			"comma-dangle": [ruleSeverity.error, ruleCompliance.never],
			"import/extensions": [ruleSeverity.error, ruleCompliance.always],
			"import/no-extraneous-dependencies": ruleSeverity.disabled,
			"import/exports-last": ruleSeverity.error
		}
	}
];

export default rootConfiguration;
