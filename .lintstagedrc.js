import path from "path";

const rootConfiguration = {
	"**.md": ["markdownlint --fix", "markdown-link-check --progress --config \".markdownlc.json\""],
	"**.js": "eslint --fix",
	"**/*.cs": absolutePaths =>
	{
		const currentWorkingDirectory = process.cwd();
		const relativePaths = absolutePaths
			.map(absolutePath => path.relative(currentWorkingDirectory, absolutePath))
			.join(" ");
		const command = `dotnet format --include ${relativePaths}`;
		return command;
	}
};

export default rootConfiguration;
