import starlight from "@astrojs/starlight";
import { defineConfig } from "astro/config";

const apiDirectory = "api";
const configuration = defineConfig({
	integrations: [
		starlight({
			favicon: "./docs/public/favicon.svg",
			sidebar: [
				{
					items: [
						{
							label: "Unit",
							link: `${apiDirectory}/unit`
						},
						{
							autogenerate: {
								directory: `${apiDirectory}/results/`
							},
							label: "Results"
						}
					],
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
