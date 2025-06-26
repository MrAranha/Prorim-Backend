using AutoMapper;
using Prorim_MediatrHandling.EntityRequests.Laudos.Requests;
using Prorim_MediatrHandling.EntityRequests.Laudos.Results;
using Prorim_MediatrHandling.Interfaces;
using Prorim_Services.Entities;
using MediatR;
using System.Collections.Generic;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Handlers
{
    public class GetLaudosRequestHandler : IRequestHandler<GetLaudosRequest, IEnumerable<GetLaudosResult>>
    {
        private readonly ILaudosRepository _userRepository;
        private readonly IMapper _mapper;
        public GetLaudosRequestHandler(ILaudosRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetLaudosResult>> Handle(GetLaudosRequest request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<GetLaudosResult>>(result);
        }
    }
}
