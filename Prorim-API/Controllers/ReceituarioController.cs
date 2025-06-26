using Prorim_MediatrHandling.EntityRequests.Receituario.Requests;
using Prorim_MediatrHandling.EntityRequests.Receituario.Results;
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
    public class ReceituarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReceituarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<GetReceituarioResult>> GetAllUsers([FromQuery] GetReceituarioRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("search")]
        public async Task<IEnumerable<GetReceituarioPagedResult>> Search([FromQuery] GetReceituarioPagedRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("save")]
        public async Task<int> CreateUser([FromForm] GetReceituarioCreateRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("delete")]
        public async Task<bool> DeleteUser([FromQuery] DeleteReceituarioRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("getById")]
        public async Task<GetReceituarioByIDResult> GetById([FromQuery] GetReceituarioByIDRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut("download")]
        public async Task<DownloadReceitaResult> Download([FromForm] DownloadReceitaRequest request)
        {
            return await _mediator.Send(request);
        }
        [HttpPut("edit")]
        public async Task<bool> EditUser([FromForm] GetReceituarioEditRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
