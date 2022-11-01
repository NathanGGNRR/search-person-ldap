using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diiage.Directory.Web.Controllers.Base
{
    /// <summary>
    /// API base controller.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AppControllerBase : ControllerBase
    { }
}
