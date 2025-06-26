using Prorim_MediatrHandling.EntityRequests.Receituario.Requests;
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

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Handlers
{
    public class GetReceituarioCreateRequestHandler : IRequestHandler<GetReceituarioCreateRequest, int>
    {
        private readonly IReceituarioRepository _repository;
        public GetReceituarioCreateRequestHandler(IReceituarioRepository repository) { _repository = repository; }
        public async Task<int> Handle(GetReceituarioCreateRequest request, CancellationToken cancellationToken)
        {
            using (var memoryStream = new MemoryStream())
            {
                await request.pdf.CopyToAsync(memoryStream);
                byte[] fileBytes = memoryStream.ToArray();

                return await _repository.Add(new TB_Receituario()
                {
                    nomeMedico = request.nomeMedico,
                    pdf = fileBytes,
                    idPaciente = request.idPaciente,
                    nomeArquivo = request.nomeArquivo,
                    nomeReceita = request.nomeReceita,
                });
            }
        }
    }
}
