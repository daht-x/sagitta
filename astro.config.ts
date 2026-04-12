import starlight from "@astrojs/starlight";
import { defineConfig } from "astro/config";

const coreDirectory = "api/core";
const corePackageName = "Daht.Sagitta.Core";
const configuration = defineConfig({
	integrations: [
		starlight({
			favicon: "./docs/public/favicon.svg",
			sidebar: [
				{
					items: [
						{
							items: [
								{
									label: "Unit",
									link: `${coreDirectory}/unit`
								},
								{
									autogenerate: {
										directory: `${coreDirectory}/results/`
									},
									label: "Results"
								}
							],
							label: corePackageName
						}
					],
					label: "API"
				}
			],
			social: [{ href: "https://github.com/daht-x/sagitta", icon: "github", label: "GitHub" }],
			title: "Sagitta"
		})
	],
	srcDir: "./docs/src"
});

export default configuration;
