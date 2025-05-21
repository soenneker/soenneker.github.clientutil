using Soenneker.GitHub.ClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.GitHub.ClientUtil.Tests;

[Collection("Collection")]
public class GitHubOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IGitHubOpenApiClientUtil _kiotaclient;

    public GitHubOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _kiotaclient = Resolve<IGitHubOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
