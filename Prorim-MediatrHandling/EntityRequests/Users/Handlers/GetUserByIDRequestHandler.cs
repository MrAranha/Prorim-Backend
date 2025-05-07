using FbSoft_MediatrHandling.EntityRequests.Users.Requests;
using FbSoft_MediatrHandling.EntityRequests.Users.Results;
using FbSoft_MediatrHandling.Interfaces;
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

namespace FbSoft_MediatrHandling.EntityRequests.Users.Handlers
{
    public class GetCarroByIDRequestHandler : IRequestHandler<GetUserByIDRequest, GetUserByIDResult>
    {
        private readonly IUserRepository _userRepository;
        public GetCarroByIDRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<GetUserByIDResult> Handle(GetUserByIDRequest request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetByID(request.UserID);
            return new GetUserByIDResult()
            {
                ID = result.id,
Name               = result.displayName,
Email              = result.email,
country            = result.country,
address            = result.address,
state              = result.state,
city               = result.city,
zipCode            = result.zipCode,
about              = result.about,
role               = result.role
            };
        }
    }
}
