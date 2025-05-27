using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.GitHub.Client.Http.Abstract;
using Soenneker.GitHub.ClientUtil.Abstract;
using Soenneker.GitHub.OpenApiClient;
using Soenneker.Kiota.BearerAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.GitHub.ClientUtil;

///<inheritdoc cref="IGitHubOpenApiClientUtil"/>
public sealed class GitHubOpenApiClientUtil : IGitHubOpenApiClientUtil
{
    private readonly AsyncSingleton<GitHubOpenApiClient> _client;

    public GitHubOpenApiClientUtil(IGitHubHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<GitHubOpenApiClient>(async (token, _) =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var gitHubToken = configuration.GetValueStrict<string>("GH:Token");

            var requestAdapter = new HttpClientRequestAdapter(new BearerAuthenticationProvider(gitHubToken), httpClient: httpClient);

            return new GitHubOpenApiClient(requestAdapter);
        });
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