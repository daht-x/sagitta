# Sagitta - Core

***Functional paradigm abstractions for .NET***

[package]: https://www.nuget.org/packages/Daht.Sagitta.Core

[![NuGet](https://img.shields.io/nuget/v/Daht.Sagitta.Core?style=for-the-badge&logo=nuget&logoColor=FFFFFF&label=NUGET&labelColor=000000&color=7950F2)][package]
[![Downloads](https://img.shields.io/nuget/dt/Daht.Sagitta.Core?style=for-the-badge&logo=nuget&logoColor=FFFFFF&label=DOWNLOADS&labelColor=000000&color=7950F2)](https://www.nuget.org/stats/packages/Daht.Sagitta.Core?groupby=Version)
[![Coverage](https://img.shields.io/codecov/c/github/daht-x/sagitta-core?style=for-the-badge&logo=codecov&logoColor=FFFFFF&label=COVERAGE&labelColor=000000&color=7950F2)](https://app.codecov.io/gh/daht-x/sagitta-core)

[![CodeQL](https://img.shields.io/github/actions/workflow/status/daht-x/sagitta-core/codeql.yaml?style=for-the-badge&logo=github-actions&logoColor=FFFFFF&label=CODEQL&labelColor=000000)](https://github.com/daht-x/sagitta-core/actions/workflows/codeql.yaml)
[![.NET](https://img.shields.io/github/actions/workflow/status/daht-x/sagitta-core/dotnet.yaml?style=for-the-badge&logo=github-actions&logoColor=FFFFFF&label=.NET&labelColor=000000)](https://github.com/daht-x/sagitta-core/actions/workflows/dotnet.yaml)
[![Markdown](https://img.shields.io/github/actions/workflow/status/daht-x/sagitta-core/markdown.yaml?style=for-the-badge&logo=github-actions&logoColor=FFFFFF&label=MARKDOWN&labelColor=000000)](https://github.com/daht-x/sagitta-core/actions/workflows/markdown.yaml)

## Table of contents

1. [Installation](#installation)
2. [API](#api)
   - [Monads](#monads)
3. [License](#license)
4. [Security policy](#security-policy)
5. [Code of conduct](#code-of-conduct)
6. [Contributing guidelines](#contributing-guidelines)

### Installation

Please go to the [NuGet package manager][package] and select the most appropriate installation method for your workflow.

***[Top](#sagitta---core)***

---

### API

#### Monads

The term **monad** describes a set of abstractions that provide ways to manage the state of an element through the composition of sequential operations and the handling of side effects.

[result]: https://github.com/daht-x/sagitta-core/blob/main/documentation/monads/result.md
[result-factory]: https://github.com/daht-x/sagitta-core/blob/main/documentation/monads/result-factory.md

| Type                                   | Description                                                                                 |
|:---------------------------------------|:--------------------------------------------------------------------------------------------|
| [`Result<TSuccess, TFailure>`][result] | Type that encapsulates both the expected success and the possible failure of a given action |
| [`ResultFactory`][result-factory]      | Type that exposes a set of ways to initialize [`Result<TSuccess, TFailure>`][result]        |

***[Top](#sagitta---core)***

---

### License

Distributed under [MIT license](https://github.com/daht-x/sagitta-core/blob/main/license).

***[Top](#sagitta---core)***

---

### Security policy

Please read and follow our [security policy](https://github.com/daht-x/sagitta-core/blob/main/security.md).

***[Top](#sagitta---core)***

---

### Code of conduct

Please read and follow our [code of conduct](https://github.com/daht-x/sagitta-core/blob/main/code-of-conduct.md).

***[Top](#sagitta---core)***

---

### Contributing guidelines

Please read and follow our [contributing guidelines](https://github.com/daht-x/sagitta-core/blob/main/contributing.md).

***[Top](#sagitta---core)***
