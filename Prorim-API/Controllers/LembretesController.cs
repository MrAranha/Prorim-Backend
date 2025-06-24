using Prorim_MediatrHandling.EntityRequests.Lembretes.Requests;
using Prorim_MediatrHandling.EntityRequests.Lembretes.Results;
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
    public class LembretesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LembretesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<GetLembretesResult>> GetAllUsers([FromQuery] GetLembretesRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("search")]
        public async Task<IEnumerable<GetLembretesPagedResult>> Search([FromQuery] GetLembretesPagedRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("save")]
        public async Task<int> CreateUser([FromForm] GetLembretesCreateRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("delete")]
        public async Task<bool> DeleteUser([FromQuery] DeleteLembretesRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("getById")]
        public async Task<GetLembretesByIDResult> GetById([FromQuery] GetLembretesByIDRequest request)
        {
            return await _mediator.Send(request);
        }
        [HttpPut("edit")]
        public async Task<bool> EditUser([FromForm] GetLembretesEditRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
