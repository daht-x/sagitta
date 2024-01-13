const rootConfiguration = {

	"**.md": [
		"markdownlint --fix",
		"lychee"
	],
	"**.sh": "shellcheck --severity 'style'",
	"**.js": "eslint --fix",
	"**/*.cs": "dotnet format --include"
};
export default rootConfiguration;
