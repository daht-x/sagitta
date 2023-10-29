const rootConfiguration = {
	"**.md": ["markdownlint --fix", "markdown-link-check --progress --config '.markdownlc.json'"],
	"**.js": "eslint --fix",
	"**/*.cs": "dotnet format --include"
};

export default rootConfiguration;
