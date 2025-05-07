using DevExpress.Mvvm.POCO;
using FbSoft_MediatrHandling.EntityRequests.Users.Interfaces;
using FbSoft_MediatrHandling.EntityRequests.Users.Requests;
using FbSoft_MediatrHandling.EntityRequests.Users.Results;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Users.Handlers
{
    public class DeleteCarroRequestHandler : IRequestHandler<DeleteCarroRequest, bool>
    {
        private readonly IUserRepository _userRepository;
        public DeleteCarroRequestHandler(IUserRepository userRepository) { _userRepository = userRepository; }

        public async Task<bool> Handle(DeleteCarroRequest request, CancellationToken cancellationToken)
        {
            //TODO VALIDACAO DE ADMINISTRADOR, TANTO NO FRONT QUANTO NO BACK
            return await _userRepository.Delete(request.UserID);
        }
    }
}