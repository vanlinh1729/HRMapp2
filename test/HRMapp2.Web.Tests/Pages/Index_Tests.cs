using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace HRMapp2.Pages;

public class Index_Tests : HRMapp2WebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
