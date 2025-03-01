using Microsoft.AspNetCore.Mvc;

namespace MicroEngine.Framework.Commons
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase { }
}
