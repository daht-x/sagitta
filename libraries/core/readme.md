# Daht.Sagitta.Core

***[home](https://github.com/daht-x/sagitta/blob/main/readme.md) / packages /***

***Functional paradigm abstractions for .NET - Core***

[![Stars](https://img.shields.io/github/stars/daht-x/sagitta?style=for-the-badge&logo=starship&logoColor=cdd6f4&label=Stars&labelColor=313244&color=b4befe)](https://github.com/daht-x/sagitta/stargazers)
[![Release](https://img.shields.io/github/v/release/daht-x/sagitta?style=for-the-badge&logo=github&logoColor=cdd6f4&label=Release&labelColor=313244&color=b4befe)](https://github.com/daht-x/sagitta/releases)
[![Downloads](https://img.shields.io/nuget/dt/Daht.Sagitta.Core?style=for-the-badge&logo=nuget&logoColor=cdd6f4&label=Downloads&labelColor=313244&color=b4befe)](https://www.nuget.org/stats/packages/Daht.Sagitta.Core?groupby=Version)
[![Coverage](https://img.shields.io/codecov/c/github/daht-x/sagitta?style=for-the-badge&logo=codecov&logoColor=cdd6f4&label=Coverage&labelColor=313244&color=b4befe)](https://app.codecov.io/gh/daht-x/sagitta)
[![Issues](https://img.shields.io/github/issues/daht-x/sagitta?style=for-the-badge&logo=gitbook&logoColor=cdd6f4&label=Issues&labelColor=313244&color=b4befe)](https://github.com/daht-x/sagitta/issues)

## Table of contents

1. [Installation](#installation)
   - [.NET command-line interface](#net-command-line-interface)
   - [Project file](#project-file)
   - [Central package management](#central-package-management)
2. [API](#api)
   - [Root](#root)
   - [Monads](#monads)
3. [License](#license)
4. [Security policy](#security-policy)
5. [Code of conduct](#code-of-conduct)
6. [Contributing guidelines](#contributing-guidelines)
7. [Contact](#contact)

### Installation

***For information on all available versions, please see the [NuGet](https://www.nuget.org/packages/Daht.Sagitta.Core) or
[GitHub](https://github.com/daht-x/sagitta/pkgs/nuget/Daht.Sagitta.Core) package registry***

#### .NET command-line interface

```shell
dotnet add package 'Daht.Sagitta.Core' --version 'x.x.x'
```

For more information, please see [here](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package).

***[Top](#dahtsagittacore)***

#### Project file

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <PackageReference Include="Daht.Sagitta.Core" Version="x.x.x" />
  </ItemGroup>
</Project>
```

For more information, please see [here](https://learn.microsoft.com/en-us/nuget/consume-packages/package-references-in-project-files).

***[Top](#dahtsagittacore)***

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

***[Top](#dahtsagittacore)***

### API

#### Root

Set of structures that act as integrations and complements for the pre-existing modules.

[unit]: https://github.com/daht-x/sagitta/blob/main/libraries/core/documentation/unit.md
[void]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/void

| Type           | Description                                                                                              |
|:---------------|:---------------------------------------------------------------------------------------------------------|
| [`Unit`][unit] | Type intended to handle the absence of a specific value (explicit simulation of the [`void`][void] type) |

***[Top](#dahtsagittacore)***

#### Monads

Set of structures that provide ways to handle the state of an element through the composition of
sequential operations and the handling of side effects.

[result]: https://github.com/daht-x/sagitta/blob/main/libraries/core/documentation/monads/result.md
[result-factory]: https://github.com/daht-x/sagitta/blob/main/libraries/core/documentation/monads/result-factory.md

| Type                                   | Description                                                                                  |
|:---------------------------------------|:---------------------------------------------------------------------------------------------|
| [`Result<TFailure, TSuccess>`][result] | Type intended to handle both the possible failure and the expected success of a given action |
| [`ResultFactory`][result-factory]      | Type intended to expose a set of ways to initialize [`Result<TFailure, TSuccess>`][result]   |

***[Top](#dahtsagittacore)***

### License

Distributed under [MIT license](https://github.com/daht-x/sagitta/blob/main/license).

***[Top](#dahtsagittacore)***

### Security policy

Please read and keep in mind our [security policy](https://github.com/daht-x/sagitta/blob/main/security.md).

***[Top](#dahtsagittacore)***

### Code of conduct

Please read and follow our [code of conduct](https://github.com/daht-x/sagitta/blob/main/code-of-conduct.md).

***[Top](#dahtsagittacore)***

### Contributing guidelines

Please read and follow our [contributing guidelines](https://github.com/daht-x/sagitta/blob/main/contributing.md).

***[Top](#dahtsagittacore)***

### Contact

- [LinkedIn](https://www.linkedin.com/in/daht-x)
- [X](https://x.com/_daht_x)
