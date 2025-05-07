using FbSoft_MediatrHandling.EntityRequests.Users.Requests;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Users.Handlers
{
    public class GetCarroCreateRequestHandler : IRequestHandler<GetCarroCreateRequest, string>
    {
        private readonly IUserRepository _repository;
        public GetCarroCreateRequestHandler(IUserRepository repository) { _repository = repository; }
        public async Task<string> Handle(GetCarroCreateRequest request, CancellationToken cancellationToken)
        {
            var doesExist = await _repository.GetByEmail(request.Email);
            if (doesExist != null)
            {
                //TODO CRIAR SERVICO DE NOTIFICACAO GLOBAL :D
                throw new Exception("Email já em uso!");
            }
            return await _repository.Add(new FbSoft_Services.Entities.TB_Users()
            {
                id = System.Guid.NewGuid().ToString(),
                role = "U",
                password = request.Password,
                email = request.Email,
                displayName = request.Nome
            });
        }
    }
}
