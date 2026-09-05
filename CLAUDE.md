# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

Sagitta is a .NET library (`Daht.Sagitta.Core`, NuGet) of functional-paradigm abstractions — `Result`,
`ValueResult`, their factories and `Unit`. The repository also carries its own Astro/Starlight documentation site, so
every change touches two toolchains: .NET (library) and Node.js/PNPM (docs plus every non-C# linter).

## Layout

- `libs/core/src` — the shipped package. `libs/core/tests/unit` — its xUnit v3 suite. `libs/core/bench` is an empty
  placeholder.
- `libs/shared/src` — `Daht.Sagitta.Shared`, a non-packable (`PrivateAssets="all"`) helper assembly. It exists almost
  entirely to hold `Analysis/*AnalysisCategory.cs`: constants that name analyzer rules so `SuppressMessage` is written
  as `[SuppressMessage(DesignAnalysisCategory.Name, DesignAnalysisCategory.Rules.ValidateArgumentsOfPublicMethods)]`
  instead of raw strings. Add a constant there before suppressing a rule anywhere.
- `libs/shared/tests/unit` — shared test-only types (e.g. `ProofOfConceptException`), referenced by the core test
  project rather than run on its own; the CI and `pre-push` test command targets only `Sagitta.Core.UnitTests.csproj`.
- `docs/src` — the Starlight site (`srcDir` is set in `astro.config.ts`; `@/*` maps to `docs/src/*`).
- `Sagitta.slnx` is the solution (XML slnx format, not `.sln`).

### Two parallel documentation trees

The public API is documented twice and both copies must be updated together when a public member changes:

- `libs/core/docs/**.md` — GitHub-rendered Markdown, linked from `libs/core/readme.md` (which is the packed NuGet
  readme) with absolute `github.com/daht-x/sagitta/blob/main/...` links.
- `docs/src/content/docs/api/core/**.mdx` — the same content for the Starlight site, using `<Code>` from
  `@astrojs/starlight/components` with `MarkdownCodeBlockType` from `@/global.ts`, plus the local `ParameterTable` /
  `GenericTable` Astro components. New pages under `api/core/results/` are picked up by the `autogenerate` sidebar
  entry; anything else needs an explicit entry in `astro.config.ts`.

## Build, test, docs

`Directory.Build.props` applies to every project: `net10.0`, nullable + implicit usings, `AnalysisMode=all`,
`EnforceCodeStyleInBuild`, and **`TreatWarningsAsErrors` including analyzer warnings** — an analyzer diagnostic fails
the build. Package versions are centrally managed in `Directory.Packages.props`; `PackageReference` entries carry no
`Version`. Build output goes to `./artifacts` (`UseArtifactsOutput`).

```bash
dotnet restore
dotnet build --no-restore --configuration 'Release'

# Test host is Microsoft.Testing.Platform (global.json `test.runner`), so tests are *run*, not `dotnet test`
dotnet run --project './libs/core/tests/unit/Sagitta.Core.UnitTests.csproj' --no-build --configuration 'Release'

# A single test / class / trait (arguments after `--` go to the xunit MTP runner)
dotnet run --project './libs/core/tests/unit/Sagitta.Core.UnitTests.csproj' -- \
  --filter-method 'Daht.Sagitta.Core.UnitTests.Results.ResultTests.Constructor_Failure_FailedResult'
dotnet run --project './libs/core/tests/unit/Sagitta.Core.UnitTests.csproj' -- --filter-class '*ResultTests'

dotnet format --include <changed .cs files>   # what CI and lint-staged run; CI adds --verify-no-changes
```

Coverage (cobertura → `artifacts/coverage/core.xml`, uploaded to Codecov) is only enabled when `GITHUB_ACTIONS=true`.

```bash
pnpm install
pnpm run prepare          # husky hooks + astro sync; required once per clone
pnpm run astro:dev
pnpm run astro:check      # type-checks .astro/.mdx — part of pre-push
pnpm run astro:build
```

Non-C# linters are external binaries, not PNPM dependencies (see `contributing.md` for the full prerequisite list):
`biome check --write` for `.json/.js/.ts`, `markdownlint-cli2 --fix` + `lychee` for `.md`, `yamllint --strict` for
YAML, `shfmt --write` + `shellcheck --severity 'style'` for `.sh` and `.husky/*`. `lint-staged --relative` runs the
applicable set over staged files.

Git hooks: `commit-msg` → commitlint; `pre-commit` → TruffleHog over the pending commit, then lint-staged;
`pre-push` → full clean/restore/Release build + core unit tests + `astro:check` + `astro:build`. Expect `git push` to
be slow.

## Conventions

- `.editorconfig` is the authority for C# style and analyzer severities (~1000 lines). Notable: tabs at width 4, LF,
  120-column Markdown/JSON, 2-space Markdown and YAML, `file_header_template` (the four-line MIT banner every `.cs`
  file starts with), `this.` required for fields only, explicit types instead of `var`, and
  `dotnet_style_namespace_match_folder = error`.
- Usings live in each project's `Global.cs` as `global using`; individual files declare none.
- Public API members are XML-documented (`GenerateDocumentationFile`), including `<typeparam>`, `<remarks>` on
  throwing accessors and `<exception>`. The docs pages are written from those comments.
- The core assembly is AOT-compatible (`IsAotCompatible`, `VerifyReferenceAotCompatibility`); `ValueResult` uses
  `Unsafe.SkipInit` and `[StructLayout(LayoutKind.Auto)]`.
- Test conventions in `libs/core/tests/unit`: one file per type, methods named
  `Member_Scenario_ExpectedOutcome`, each tagged `[Trait(@base, memberX)]` where the constants sit at the top of the
  class, and grouped in `#region`s matching the member. Data comes from `Fixtures/` (constants), `Mothers/`
  (pre-built results), `Fakers/` (test doubles), and assertions go through `Asserters/` rather than raw `Assert`
  chains.
- Biome sorts object keys and properties (`useSortedKeys`, `useSortedProperties`) — keep JSON/TS literals
  alphabetical. YAML forbids flow braces/brackets and requires double-quoted strings, except
  `.github/workflows/*.yaml`.
- Commits follow Conventional Commits validated by `commitlint.config.ts`: lower-case type/scope/subject, no trailing
  full stop in the subject, body **must** end with a full stop, and a `Signed-off-by:` trailer is expected. Types:
  `feat|fix|docs|style|refactor|test|build|ci|chore`.
- CI (`.github/workflows/`) lints only changed files via `tj-actions/changed-files`. `library.yaml` also packs and
  publishes to NuGet + GitHub Packages on a `v*.*.*` tag pushed by the repository owner. `nodejs.yaml`, `pnpm.yaml`
  and Dependabot open automated version-bump PRs, so `.nvmrc`, `engines.node` and `packageManager` are
  machine-maintained.
