[![](https://img.shields.io/nuget/v/soenneker.github.clientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.github.clientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.github.clientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.github.clientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.github.clientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.github.clientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.github.clientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.github.clientutil/actions/workflows/codeql.yml)

# Soenneker.GitHub.ClientUtil

Provides lazy, cached access to the generated GitHub REST API client over an authenticated shared transport.

## Installation

```bash
dotnet add package Soenneker.GitHub.ClientUtil
```

## Configure and register

```json
{
  "GH": {
    "Token": "your-github-token"
  }
}
```

```csharp
using Soenneker.GitHub.ClientUtil.Registrars;

services.AddGitHubOpenApiClientUtilAsScoped();
```

## Use the client

```csharp
using Soenneker.GitHub.ClientUtil.Abstract;

public sealed class GitHubUserReader(IGitHubOpenApiClientUtil clients)
{
    public async Task Read(CancellationToken cancellationToken)
    {
        var client = await clients.Get(cancellationToken);
        var user = await client.User.GetAsync(
            cancellationToken: cancellationToken);
    }
}
```

The HTTP provider supplies the bearer token and required GitHub headers. The generated client therefore uses anonymous Kiota authentication and does not add a duplicate `Authorization` value.

Use `AddGitHubOpenApiClientUtilAsSingleton()` when the application should share one generated client. A scoped utility borrows the singleton HTTP provider, so disposing the scope does not destroy the shared transport.
