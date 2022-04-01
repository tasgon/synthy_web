using Microsoft.AspNetCore.Mvc;

namespace synthy.Api;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new[] { "sadlkh", "asdlih" };
    }
}