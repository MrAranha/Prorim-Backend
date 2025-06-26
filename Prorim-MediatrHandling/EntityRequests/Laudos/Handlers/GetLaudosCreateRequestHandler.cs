using Prorim_MediatrHandling.EntityRequests.Laudos.Requests;
using Prorim_MediatrHandling.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prorim_MediatrHandling.Entities;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Handlers
{
    public class GetLaudosCreateRequestHandler : IRequestHandler<GetLaudosCreateRequest, int>
    {
        private readonly ILaudosRepository _repository;
        public GetLaudosCreateRequestHandler(ILaudosRepository repository) { _repository = repository; }
        public async Task<int> Handle(GetLaudosCreateRequest request, CancellationToken cancellationToken)
        {
            using (var memoryStream = new MemoryStream())
            {
                await request.pdf.CopyToAsync(memoryStream);
                byte[] fileBytes = memoryStream.ToArray();

            return await _repository.Add(new TB_Laudos()
            {
                nomeMedico = request.nomeMedico,
                pdf = fileBytes,
                idPaciente = request.idPaciente,
                nomeArquivo = request.nomeArquivo,
            });
            }
        }
    }
}
