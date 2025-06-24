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
    public class GetCarroEditRequestHandler : IRequestHandler<GetCarroEditRequest, bool>
    {
        private readonly IUserRepository _repository;
        public GetCarroEditRequestHandler(IUserRepository repository) { _repository = repository; }
        public async Task<bool> Handle(GetCarroEditRequest request, CancellationToken cancellationToken)
        {
            await _repository.Edit(new Prorim_Services.Entities.TB_Users()
            {
                id = request.id,
                displayName = request.name,
                email = request.email,
                country = request.country,
                address = request.address,
                state = request.state,
                city = request.city,
                zipCode = request.zipCode,
                about = request.about,
                role = request.role
            });
            return true;
        }
    }
}
