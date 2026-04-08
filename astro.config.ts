import starlight from "@astrojs/starlight";
import { defineConfig } from "astro/config";

const configuration = defineConfig({
	integrations: [
		starlight({
			favicon: "./docs/public/favicon.svg",
			sidebar: [
				{
					autogenerate: { directory: "api" },
					label: "API"
				}
			],
			social: [{ href: "https://github.com/withastro/starlight", icon: "github", label: "GitHub" }],
			title: "My Docs"
		})
	],
	srcDir: "./docs/src"
});

export default configuration;
