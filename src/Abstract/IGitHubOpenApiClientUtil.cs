using System;
using System.Threading.Tasks;
using System.Threading;
using Soenneker.GitHub.OpenApiClient;

namespace Soenneker.GitHub.ClientUtil.Abstract;

/// <summary>
/// A .NET thread-safe singleton HttpClient for 
/// </summary>
public interface IGitHubOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    ValueTask<GitHubOpenApiClient> Get(CancellationToken cancellationToken = default);
}