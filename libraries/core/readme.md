# Daht.Sagitta.Core

[void]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/void
[unit]: https://github.com/daht-x/sagitta/blob/main/libraries/core/documentation/unit.md
[result]: https://github.com/daht-x/sagitta/blob/main/libraries/core/documentation/results/result.md
[result-factory]: https://github.com/daht-x/sagitta/blob/main/libraries/core/documentation/results/result-factory.md
[value-result]: https://github.com/daht-x/sagitta/blob/main/libraries/core/documentation/results/value-result.md
[value-result-factory]: https://github.com/daht-x/sagitta/blob/main/libraries/core/documentation/results/value-result-factory.md

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
   - [Results](#results)
   - [FAQ](#faq)
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

Structures intended to integrate with and extend existing modules.

| Type         | Description                                                                               |
|:-------------|:------------------------------------------------------------------------------------------|
| [Unit][unit] | Represents the absence of a specific value, explicitly simulating the [`void`][void] type |

***[Top](#dahtsagittacore)***

#### Results

Structures intended to encapsulate and manage both potential failure and expected success for a given action.

| Type                                            | Description                                                                                                      |
|:------------------------------------------------|:-----------------------------------------------------------------------------------------------------------------|
| [Result<TFailure, TSuccess>][result]            | Encapsulates both a possible failure and an expected success for a given action (both value and reference types) |
| [ResultFactory][result-factory]                 | Provide global factory methods to initialize [`Result<TFailure, TSuccess>`][result]                              |
| [ValueResult<TFailure, TSuccess>][value-result] | Encapsulates both a possible failure and an expected success for a given action (only value types)               |
| [ValueResultFactory][value-result-factory]      | Provide global factory methods to initialize [`ValueResult<TFailure, TSuccess>`][value-result]                   |

***[Top](#dahtsagittacore)***

#### FAQ

- When to use exceptions?
  - Exceptional, unpredictable, or non-deterministic situations
*(e.g., disk I/O failures, network timeouts, out-of-memory conditions)*.
  - When local recovery is not possible or would compromise system integrity
*(e.g., corrupted state, violated invariants, missing critical resources)*.
  - When an error must be propagated beyond the local scope to enable stack-unwinding or a global recovery strategy
*(e.g., transaction rollback, centralized cleanup, subsystem restart, escalation to another API/module)*.
- When not to use exceptions?
  - Predictable or expected scenarios
*(e.g., business-rule violations, parameter validation, boundary checks, foreseeable edge cases)*.
  - As a substitute for normal control flow *(e.g., loop termination, flag checking, selecting alternate code paths)*.
  - In high-performance and latency-sensitive scenarios *(e.g., tight loops, real-time processing, compute-intensive tasks)*.
- Why [`Result<TFailure, TSuccess>`][result] and [`ValueResult<TFailure, TSuccess>`][value-result]?
  - Exceptions are expensive, because throwing and catching requires constructing complex objects,
capturing a full stack trace, and unwinding the call stack.
  - Exceptions are intended for exceptional and unpredictable situations and should not be used for regular
control flow or business-rule enforcement.

***[Top](#dahtsagittacore)***

### License

Licensed under the [MIT License](https://github.com/daht-x/sagitta/blob/main/license.txt).

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
- Email (FOSS): [daht.x.foss@gmail.com](mailto:daht.x.foss@gmail.com)

***[Top](#dahtsagittacore)***
