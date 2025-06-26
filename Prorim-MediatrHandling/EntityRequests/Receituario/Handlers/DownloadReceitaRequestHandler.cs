using Prorim_MediatrHandling.Entities;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Handlers;

using MediatR;
using Prorim_MediatrHandling.EntityRequests.Receituario.Requests;
using Prorim_MediatrHandling.EntityRequests.Receituario.Results;
using Prorim_MediatrHandling.Interfaces;


public class DownloadReceitaRequestHandler  : IRequestHandler<DownloadReceitaRequest, DownloadReceitaResult>
{
    private readonly IReceituarioRepository _repository;
    public DownloadReceitaRequestHandler(IReceituarioRepository repository) { _repository = repository; }
    public async Task<DownloadReceitaResult> Handle(DownloadReceitaRequest request, CancellationToken cancellationToken)
    {
        TB_Receituario result = await _repository.GetByID(request.id);
        return new DownloadReceitaResult()
        {
            nomeArquivo = result.nomeArquivo,
            pdf = result.pdf,
        };
    }
}