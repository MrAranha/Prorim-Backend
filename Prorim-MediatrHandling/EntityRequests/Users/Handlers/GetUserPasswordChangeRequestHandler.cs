using Prorim_MediatrHandling.EntityRequests.Users.Interfaces;
using Prorim_MediatrHandling.EntityRequests.Users.Requests;
using Prorim_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Users.Handlers
{
    public class GetUserPasswordChangeRequestHandler : IRequestHandler<GetUserPasswordChangeRequest, bool>
    {
        private readonly IUserRepository _userRep;
        public GetUserPasswordChangeRequestHandler(IUserRepository userRep) { _userRep = userRep; }
        public async Task<bool> Handle(GetUserPasswordChangeRequest request,  CancellationToken cancellationToken)
        {
            return await _userRep.Edit(new Prorim_Services.Entities.TB_Users() { id = request.UserID, password = request.Password });
        }
    }
}
