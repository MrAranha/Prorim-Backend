using MediatR;
using Prorim_MediatrHandling.Entities;
using Prorim_MediatrHandling.EntityRequests.Laudos.Requests;
using Prorim_MediatrHandling.EntityRequests.Laudos.Results;
using Prorim_MediatrHandling.Interfaces;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Handlers;

public class DownloadLaudoRequestHandler  : IRequestHandler<DownloadLaudoRequest, DownloadLaudoResult>
{
    private readonly ILaudosRepository _repository;
    public DownloadLaudoRequestHandler(ILaudosRepository repository) { _repository = repository; }
    public async Task<DownloadLaudoResult> Handle(DownloadLaudoRequest request, CancellationToken cancellationToken)
    {
        TB_Laudos result = await _repository.GetByID(request.id);
        return new DownloadLaudoResult()
        {
            nomeArquivo = result.nomeArquivo,
            pdf = result.pdf,
        };
    }
}