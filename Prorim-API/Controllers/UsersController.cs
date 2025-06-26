using Prorim_MediatrHandling.EntityRequests.Users.Requests;
using Prorim_MediatrHandling.EntityRequests.Users.Results;
using Prorim_MediatrHandling.Interfaces;
using Prorim_Services.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using System.Security.Claims;

namespace Prorim_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //Admin check, test purposes may be deleted later
        [HttpGet]
        [Route("Admins")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi you are an {currentUser.role}");
        }
        private TB_Users GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new TB_Users
                {
                    id = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }

        [HttpGet]
        public async Task<IEnumerable<GetCarroResult>> GetAllUsers([FromQuery] GetCarroRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("search")]
        public async Task<IEnumerable<GetUserPagedResult>> Search([FromQuery] GetUserPagedRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("save")]
        public async Task<string> CreateUser([FromForm] GetCarroCreateRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("delete")]
        public async Task<bool> DeleteUser([FromQuery] DeleteCarroRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("getById")]
        public async Task<GetUserByIDResult> GetById([FromQuery] GetUserByIDRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut("edit")]
        public async Task<bool> EditUser([FromForm] GetCarroEditRequest request)
        {
            return await _mediator.Send(request);
        }
        [HttpPut("changePassword")]
        public async Task<bool> ChangePassword([FromForm] GetUserPasswordChangeRequest request)
        {
            return await _mediator.Send(request);
        }
        
        
        [HttpGet("getall")]
        public async Task<List<TB_Users>> Search([FromQuery] GetAllUserRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
