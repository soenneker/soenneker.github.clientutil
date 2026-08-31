using System;
using System.Threading.Tasks;
using System.Threading;
using Soenneker.GitHub.OpenApiClient;

namespace Soenneker.GitHub.ClientUtil.Abstract;

/// <summary>
/// Provides lazy access to a cached generated GitHub REST API client.
/// </summary>
public interface IGitHubOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached GitHub API client, creating it on first use.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel retrieval.</param>
    /// <returns>The generated GitHub API client.</returns>
    ValueTask<GitHubOpenApiClient> Get(CancellationToken cancellationToken = default);
}
