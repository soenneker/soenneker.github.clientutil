using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.GitHub.Client.Http.Registrars;
using Soenneker.GitHub.ClientUtil.Abstract;

namespace Soenneker.GitHub.ClientUtil.Registrars;

/// <summary>
/// A .NET thread-safe singleton HttpClient for GitHub
/// </summary>
public static class GitHubOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="GitHubOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddGitHubOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddGitHubHttpClientAsSingleton().TryAddSingleton<IGitHubOpenApiClientUtil, GitHubOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="GitHubOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddGitHubOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddGitHubHttpClientAsSingleton().TryAddScoped<IGitHubOpenApiClientUtil, GitHubOpenApiClientUtil>();

        return services;
    }
}