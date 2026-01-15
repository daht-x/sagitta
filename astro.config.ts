import starlight from "@astrojs/starlight";
import { defineConfig } from "astro/config";

const configuration = defineConfig({
	integrations: [
		starlight({
			favicon: "./docs/public/favicon.svg",
			sidebar: [
				{
					items: [{ label: "Example Guide", slug: "guides/example" }],
					label: "Guides"
				},
				{
					autogenerate: { directory: "reference" },
					label: "Reference"
				}
			],
			social: [{ href: "https://github.com/withastro/starlight", icon: "github", label: "GitHub" }],
			title: "My Docs"
		})
	],
	srcDir: "./docs/src"
});

export default configuration;
