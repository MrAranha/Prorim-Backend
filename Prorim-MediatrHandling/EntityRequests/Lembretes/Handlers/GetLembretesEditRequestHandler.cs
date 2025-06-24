using Prorim_MediatrHandling.EntityRequests.Lembretes.Requests;
using Prorim_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Lembretes.Handlers
{
    public class GetLembretesEditRequestHandler : IRequestHandler<GetLembretesEditRequest, bool>
    {
        private readonly ILembretesRepository _repository;
        public GetLembretesEditRequestHandler(ILembretesRepository repository) { _repository = repository; }
        public async Task<bool> Handle(GetLembretesEditRequest request, CancellationToken cancellationToken)
        {
            await _repository.Edit(new Prorim_Services.Entities.TB_Lembretes()
            {
                nomeLembrete = request.nomeLembrete,
                DataLembrete = request.DataLembrete,
                tipoTransplante = request.tipoTransplante,
                remedio = request.remedio
            });
            return true;
        }
    }
}
