using Prorim_MediatrHandling.EntityRequests.Login.Requests;
using Prorim_MediatrHandling.EntityRequests.Login.Result;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Prorim_Backend.Controllers
{
    [ApiController]
    [Route("api/auth/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<GetLoginResult>> Login([FromBody] GetLoginRequest request)
        {
            var result = await _mediator.Send(request);
            if (result == null)
            {
                return NotFound("E-mail de usuário ou senha incorretos.");
            };
            return result;
        }

        //TODO AUTENTICAR BEARER TOKEN
        [HttpGet("me")] 
        public ActionResult CheckLoginToken()
        {
            return Ok("OK");
        }
    }
}
