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
    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<GitHubOpenApiClient> Get(CancellationToken cancellationToken = default);
}