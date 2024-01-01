const rootConfiguration = {
	"**.md": [
		"markdownlint --fix",
		"lychee"
	],
	"**.js": "eslint --fix",
	"**/*.cs": "dotnet format --include"
};
export default rootConfiguration;
