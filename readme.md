# Sagitta - Core

***Functional paradigm abstractions for .NET***

[nuget-package-registry]: https://www.nuget.org/packages/Daht.Sagitta.Core

[![NuGet](https://img.shields.io/nuget/v/Daht.Sagitta.Core?style=for-the-badge&logo=nuget&logoColor=FFFFFF&label=NuGet&labelColor=000000&color=7950F2)][nuget-package-registry]
[![Downloads](https://img.shields.io/nuget/dt/Daht.Sagitta.Core?style=for-the-badge&logo=nuget&logoColor=FFFFFF&label=Downloads&labelColor=000000&color=7950F2)](https://www.nuget.org/stats/packages/Daht.Sagitta.Core?groupby=Version)
[![Coverage](https://img.shields.io/codecov/c/github/daht-x/sagitta-core?style=for-the-badge&logo=codecov&logoColor=FFFFFF&label=Coverage&labelColor=000000&color=7950F2)](https://app.codecov.io/gh/daht-x/sagitta-core)

[![CodeQL](https://img.shields.io/github/actions/workflow/status/daht-x/sagitta-core/codeql.yaml?style=for-the-badge&logo=github-actions&logoColor=FFFFFF&label=CodeQL&labelColor=000000)](https://github.com/daht-x/sagitta-core/actions/workflows/codeql.yaml)
[![.NET](https://img.shields.io/github/actions/workflow/status/daht-x/sagitta-core/dotnet.yaml?style=for-the-badge&logo=github-actions&logoColor=FFFFFF&label=.NET&labelColor=000000)](https://github.com/daht-x/sagitta-core/actions/workflows/dotnet.yaml)
[![Markdown](https://img.shields.io/github/actions/workflow/status/daht-x/sagitta-core/markdown.yaml?style=for-the-badge&logo=github-actions&logoColor=FFFFFF&label=Markdown&labelColor=000000)](https://github.com/daht-x/sagitta-core/actions/workflows/markdown.yaml)

[![LinkedIn](https://img.shields.io/badge/LinkedIn-000000?style=for-the-badge&logo=linkedin&logoColor=FFFFFF)](https://www.linkedin.com/in/daht-x)
[![X (Twitter)](https://img.shields.io/badge/X%20(Twitter)-000000?style=for-the-badge&logo=x&logoColor=FFFFFF)](https://twitter.com/_daht_x)

## Table of contents

1. [Installation](#installation)
2. [API](#api)
   - [Monads](#monads)
3. [License](#license)
4. [Security policy](#security-policy)
5. [Code of conduct](#code-of-conduct)
6. [Contributing guidelines](#contributing-guidelines)

### Installation

***For information on all available versions, please see the [NuGet][nuget-package-registry] or [GitHub](https://github.com/daht-x/sagitta-core/pkgs/nuget/Daht.Sagitta.Core) package registry***

Please select the installation method that best suits your workflow:

- [.NET command-line interface (CLI)](https://learn.microsoft.com/en-us/dotnet/core/tools):

  ```shell
  dotnet add package Daht.Sagitta.Core --version x.x.x
  ```

- [Default package reference](https://learn.microsoft.com/en-us/nuget/consume-packages/package-references-in-project-files):

  ```xml
  <!-- Project file (.*proj) -->
  <Project Sdk="Microsoft.NET.Sdk">
    <ItemGroup>
      <!-- ... -->
      <PackageReference Include="Daht.Sagitta.Core" Version="x.x.x" />
      <!-- ... -->
    </ItemGroup>
  </Project>
  ```

- [Central package management (CPM)](https://learn.microsoft.com/en-us/nuget/consume-packages/central-package-management):

  ```xml
  <!-- Directory.Packages.props -->
  <Project>
    <PropertyGroup>
      <!-- ... -->
      <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
      <!-- ... -->
    </PropertyGroup>
    <ItemGroup>
      <!-- ... -->
      <PackageVersion Include="Daht.Sagitta.Core" Version="x.x.x" />
      <!-- ... -->
    </ItemGroup>
  </Project>
  ```

  ```xml
  <!-- Project file (.*proj) -->
  <Project Sdk="Microsoft.NET.Sdk">
    <ItemGroup>
      <!-- ... -->
      <PackageReference Include="Daht.Sagitta.Core" />
      <!-- ... -->
    </ItemGroup>
  </Project>
  ```

***[Top](#sagitta---core)***

### API

#### Monads

The monads represent a set of structures that provide ways to manage the state of an element through the composition of sequential operations and the handling of side effects.

[result]: https://github.com/daht-x/sagitta-core/blob/main/documentation/monads/result.md
[result-factory]: https://github.com/daht-x/sagitta-core/blob/main/documentation/monads/result-factory.md

| Type                                   | Description                                                                                 |
|:---------------------------------------|:--------------------------------------------------------------------------------------------|
| [`Result<TSuccess, TFailure>`][result] | Type that encapsulates both the expected success and the possible failure of a given action |
| [`ResultFactory`][result-factory]      | Type that exposes a set of ways to initialize [`Result<TSuccess, TFailure>`][result]        |

***[Top](#sagitta---core)***

### License

Distributed under [MIT license](https://github.com/daht-x/sagitta-core/blob/main/license).

***[Top](#sagitta---core)***

### Security policy

Please read and keep in mind our [security policy](https://github.com/daht-x/sagitta-core/blob/main/security.md).

***[Top](#sagitta---core)***

### Code of conduct

Please read and follow our [code of conduct](https://github.com/daht-x/sagitta-core/blob/main/code-of-conduct.md).

***[Top](#sagitta---core)***

### Contributing guidelines

Please read and follow our [contributing guidelines](https://github.com/daht-x/sagitta-core/blob/main/contributing.md).

***[Top](#sagitta---core)***
