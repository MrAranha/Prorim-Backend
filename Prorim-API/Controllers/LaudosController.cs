using Prorim_MediatrHandling.EntityRequests.Laudos.Requests;
using Prorim_MediatrHandling.EntityRequests.Laudos.Results;
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
    public class LaudosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LaudosController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<GetLaudosResult>> GetAllLaudos([FromQuery] GetLaudosRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("search")]
        public async Task<IEnumerable<GetLaudosPagedResult>> Search([FromQuery] GetLaudosPagedRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("save")]
        public async Task<int> CreateLaudos([FromForm] GetLaudosCreateRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("delete")]
        public async Task<bool> DeleteLaudos([FromQuery] DeleteLaudosRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("getById")]
        public async Task<GetLaudosByIDResult> GetById([FromQuery] GetLaudosByIDRequest request)
        {
            return await _mediator.Send(request);
        }
        [HttpPut("download")]
        public async Task<DownloadLaudoResult> Download([FromForm] DownloadLaudoRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut("edit")]
        public async Task<bool> EditLaudos([FromForm] GetLaudosEditRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
