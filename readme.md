# Sagitta - Core

***Functional paradigm abstractions for .NET***

[![Stars](https://img.shields.io/github/stars/daht-x/sagitta-core?style=for-the-badge&logo=starship&logoColor=cdd6f4&label=Stars&labelColor=313244&color=b4befe)](https://github.com/daht-x/sagitta-core)
[![Release](https://img.shields.io/github/v/release/daht-x/sagitta-core?style=for-the-badge&logo=github&logoColor=cdd6f4&label=Release&labelColor=313244&color=b4befe)](https://github.com/daht-x/sagitta-core/releases)
[![Downloads](https://img.shields.io/nuget/dt/Daht.Sagitta.Core?style=for-the-badge&logo=nuget&logoColor=cdd6f4&label=Downloads&labelColor=313244&color=b4befe)](https://www.nuget.org/stats/packages/Daht.Sagitta.Core?groupby=Version)
[![Coverage](https://img.shields.io/codecov/c/github/daht-x/sagitta-core?style=for-the-badge&logo=codecov&logoColor=cdd6f4&label=Coverage&labelColor=313244&color=b4befe)](https://app.codecov.io/gh/daht-x/sagitta-core)
[![Issues](https://img.shields.io/github/issues/daht-x/sagitta-core?style=for-the-badge&logo=gitbook&logoColor=cdd6f4&label=Issues&labelColor=313244&color=b4befe)](https://github.com/daht-x/sagitta-core/issues)

## Table of contents

1. [Installation](#installation)
   - [.NET command-line interface](#net-command-line-interface)
   - [Project file](#project-file)
   - [Central package management](#central-package-management)
2. [API](#api)
   - [Monads](#monads)
3. [License](#license)
4. [Security policy](#security-policy)
5. [Code of conduct](#code-of-conduct)
6. [Contributing guidelines](#contributing-guidelines)
7. [Contact](#contact)

### Installation

***For information on all available versions, please see the [NuGet](https://www.nuget.org/packages/Daht.Sagitta.Core) or [GitHub](https://github.com/daht-x/sagitta-core/pkgs/nuget/Daht.Sagitta.Core) package registry***

#### .NET command-line interface

```shell
dotnet add package Daht.Sagitta.Core --version x.x.x
```

For more information, please see [here](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package).

***[Top](#sagitta---core)***

#### Project file

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <PackageReference Include="Daht.Sagitta.Core" Version="x.x.x" />
  </ItemGroup>
</Project>
```

For more information, please see [here](https://learn.microsoft.com/en-us/nuget/consume-packages/package-references-in-project-files).

***[Top](#sagitta---core)***

#### Central package management

1. `Directory.Packages.props` file:

   ```xml
   <Project>
     <PropertyGroup>
       <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
     </PropertyGroup>
     <ItemGroup>
       <PackageVersion Include="Daht.Sagitta.Core" Version="x.x.x" />
     </ItemGroup>
   </Project>
   ```

2. Project file:

   ```xml
   <Project Sdk="Microsoft.NET.Sdk">
     <ItemGroup>
       <PackageReference Include="Daht.Sagitta.Core" />
     </ItemGroup>
   </Project>
   ```

For more information, please see [here](https://learn.microsoft.com/en-us/nuget/consume-packages/central-package-management).

***[Top](#sagitta---core)***

### API

#### Monads

The monads represent a set of structures that provide ways to manage the state of an element through the composition of sequential operations and the handling of side effects.

[result]: https://github.com/daht-x/sagitta-core/blob/main/documentation/monads/result.md
[result-factory]: https://github.com/daht-x/sagitta-core/blob/main/documentation/monads/result-factory.md

| Type                                   | Description                                                                                  |
|:---------------------------------------|:---------------------------------------------------------------------------------------------|
| [`Result<TFailure, TSuccess>`][result] | Type intended to manage both the possible failure and the expected success of a given action |
| [`ResultFactory`][result-factory]      | Type intended to expose a set of ways to initialize [`Result<TFailure, TSuccess>`][result]   |

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

### Contact

- [LinkedIn](https://www.linkedin.com/in/daht-x)
- [X](https://twitter.com/_daht_x)
