using Prorim_MediatrHandling.EntityRequests.Lembretes.Requests;
using Prorim_MediatrHandling.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Lembretes.Handlers
{
    public class GetLembretesCreateRequestHandler : IRequestHandler<GetLembretesCreateRequest, int>
    {
        private readonly ILembretesRepository _repository;
        public GetLembretesCreateRequestHandler(ILembretesRepository repository) { _repository = repository; }
        public async Task<int> Handle(GetLembretesCreateRequest request, CancellationToken cancellationToken)
        {
            return await _repository.Add(new Prorim_Services.Entities.TB_Lembretes()
            {
                id = request.id,
                nomeLembrete = request.nomeLembrete,
                DataLembrete = request.DataLembrete,
                clienteID = request.clienteID,
                tipoTransplante = request.tipoTransplante,
                remedio = request.remedio
            });
        }
    }
}
