using AutoMapper;
using Prorim_MediatrHandling.EntityRequests.Lembretes.Requests;
using Prorim_MediatrHandling.EntityRequests.Lembretes.Results;
using Prorim_MediatrHandling.Interfaces;
using Prorim_Services.Entities;
using MediatR;
using System.Collections.Generic;

namespace Prorim_MediatrHandling.EntityRequests.Lembretes.Handlers
{
    public class GetLembretesRequestHandler : IRequestHandler<GetLembretesRequest, IEnumerable<GetLembretesResult>>
    {
        private readonly ILembretesRepository _userRepository;
        private readonly IMapper _mapper;
        public GetLembretesRequestHandler(ILembretesRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetLembretesResult>> Handle(GetLembretesRequest request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<GetLembretesResult>>(result);
        }
    }
}
