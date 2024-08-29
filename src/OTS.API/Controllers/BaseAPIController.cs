using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OTS.API.Controllers
{
    [Route("api/[controller]")]
    //[Route("[controller]")]
    [ApiController]
    [Authorize]
    public class BaseAPIController : ControllerBase
    {
        public BaseAPIController() { }
    }
}
