# Contributing guidelines

[issue-templates]: https://github.com/daht-x/sagitta/issues/new/choose
[new-issue]: https://github.com/daht-x/sagitta/issues/new

***[home](./readme.md) /***

## Table of contents

1. [Code of conduct](#code-of-conduct)
2. [Prerequisites](#prerequisites)
3. [Development setup](#development-setup)
4. [Coding rules](#coding-rules)
5. [Bug report](#bug-report)
6. [Feature request](#feature-request)
7. [Security policy](#security-policy)
8. [Additional resources](#additional-resources)

### Code of conduct

Please read and follow our [code of conduct](./code-of-conduct.md).

***[Top](#contributing-guidelines)***

### Prerequisites

To contribute, you will need the following tools:

- [Git](https://git-scm.com)
- [TruffleHog](https://github.com/trufflesecurity/trufflehog)
- [yamllint](https://github.com/adrienverge/yamllint)
- [ShellCheck](https://github.com/koalaman/shellcheck)
- [shfmt](https://github.com/mvdan/sh)
- [FNM](https://github.com/Schniz/fnm)
- [Node.js](https://nodejs.org/en)
- [PNPM](https://pnpm.io)
- [lychee](https://github.com/lycheeverse/lychee)
- [.NET SDK](https://dotnet.microsoft.com/en-us/download)

***[Top](#contributing-guidelines)***

### Development setup

- Set up predefined Git hooks:

  ```bash
  pnpm run prepare
  ```

***[Top](#contributing-guidelines)***

### Coding rules

- All public API methods must be documented.
- All enhancements, features or bug fixes must be tested.

***[Top](#contributing-guidelines)***

### Bug report

To report a bug or unintended behavior, select a [predefined template][issue-templates] or create a [custom issue][new-issue].

***[Top](#contributing-guidelines)***

### Feature request

To request a feature or enhancement, select a [predefined template][issue-templates] or create a [custom issue][new-issue].

***[Top](#contributing-guidelines)***

### Security policy

Please read and keep in mind our [security policy](./security.md).

***[Top](#contributing-guidelines)***

### Additional resources

- [License](./license.txt)

***[Top](#contributing-guidelines)***
