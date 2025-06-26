using MediatR;
using Prorim_MediatrHandling.EntityRequests.Users.Results;
using Prorim_Services.Entities;

namespace Prorim_MediatrHandling.EntityRequests.Users.Requests;

public class GetAllUserRequest : IRequest<List<TB_Users>>
{
    
}