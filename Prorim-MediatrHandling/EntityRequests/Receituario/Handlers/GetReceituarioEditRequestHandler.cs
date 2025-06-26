using Prorim_MediatrHandling.EntityRequests.Receituario.Requests;
using Prorim_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prorim_MediatrHandling.Entities;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Handlers
{
    public class GetReceituarioEditRequestHandler : IRequestHandler<GetReceituarioEditRequest, bool>
    {
        private readonly IReceituarioRepository _repository;
        public GetReceituarioEditRequestHandler(IReceituarioRepository repository) { _repository = repository; }
        public async Task<bool> Handle(GetReceituarioEditRequest request, CancellationToken cancellationToken)
        {
            await _repository.Edit(new TB_Receituario()
            {
                nomeMedico = request.nomeMedico,
                pdf = request.pdf,
                nomeReceita = request.nomeReceita,
                idPaciente = request.idPaciente,
            });
            return true;
        }
    }
}
