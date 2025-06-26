using AutoMapper;
using Prorim_MediatrHandling.EntityRequests.Receituario.Requests;
using Prorim_MediatrHandling.EntityRequests.Receituario.Results;
using Prorim_MediatrHandling.Interfaces;
using Prorim_Services.Entities;
using MediatR;
using System.Collections.Generic;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Handlers
{
    public class GetReceituarioRequestHandler : IRequestHandler<GetReceituarioRequest, IEnumerable<GetReceituarioResult>>
    {
        private readonly IReceituarioRepository _userRepository;
        private readonly IMapper _mapper;
        public GetReceituarioRequestHandler(IReceituarioRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetReceituarioResult>> Handle(GetReceituarioRequest request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<GetReceituarioResult>>(result);
        }
    }
}
