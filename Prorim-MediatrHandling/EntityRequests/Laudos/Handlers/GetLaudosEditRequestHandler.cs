using Prorim_MediatrHandling.EntityRequests.Laudos.Requests;
using Prorim_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prorim_MediatrHandling.Entities;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Handlers
{
    public class GetLaudosEditRequestHandler : IRequestHandler<GetLaudosEditRequest, bool>
    {
        private readonly ILaudosRepository _repository;
        public GetLaudosEditRequestHandler(ILaudosRepository repository) { _repository = repository; }
        public async Task<bool> Handle(GetLaudosEditRequest request, CancellationToken cancellationToken)
        {
            await _repository.Edit(new TB_Laudos()
            {
                id = request.ID,
                nomeMedico = request.nomeMedico,
                pdf = request.pdf,
                idPaciente = request.idPaciente,
            });
            return true;
        }
    }
}
