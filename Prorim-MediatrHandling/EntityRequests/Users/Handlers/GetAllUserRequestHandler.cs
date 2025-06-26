using Prorim_MediatrHandling.EntityRequests.Users.Requests;
using Prorim_MediatrHandling.EntityRequests.Users.Results;
using Prorim_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Prorim_Services.Entities;

namespace Prorim_MediatrHandling.EntityRequests.Users.Handlers
{
    public class GetAllUserRequestHandler : IRequestHandler<GetAllUserRequest, List<TB_Users>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<TB_Users>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAll();
            return result.ToList();
        }
    }
}
