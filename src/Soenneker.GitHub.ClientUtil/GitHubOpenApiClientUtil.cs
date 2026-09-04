using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.GitHub.Client.Http.Abstract;
using Soenneker.GitHub.ClientUtil.Abstract;
using Soenneker.GitHub.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.GitHub.ClientUtil;

/// <inheritdoc cref="IGitHubOpenApiClientUtil" />
public sealed class GitHubOpenApiClientUtil : IGitHubOpenApiClientUtil
{
    private readonly AsyncSingleton<GitHubOpenApiClient> _client;
    private readonly IGitHubHttpClient _httpClientUtil;

    public GitHubOpenApiClientUtil(IGitHubHttpClient httpClientUtil)
    {
        _httpClientUtil = httpClientUtil;
        _client = new AsyncSingleton<GitHubOpenApiClient>(CreateClient);
    }

    private async ValueTask<GitHubOpenApiClient> CreateClient(CancellationToken token)
    {
        HttpClient httpClient = await _httpClientUtil.Get(token).NoSync();

        var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

        return new GitHubOpenApiClient(requestAdapter);
    }

    public ValueTask<GitHubOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
