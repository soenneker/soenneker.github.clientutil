using Soenneker.GitHub.ClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.GitHub.ClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class GitHubOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IGitHubOpenApiClientUtil _kiotaclient;

    public GitHubOpenApiClientUtilTests(Host host) : base(host)
    {
        _kiotaclient = Resolve<IGitHubOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
