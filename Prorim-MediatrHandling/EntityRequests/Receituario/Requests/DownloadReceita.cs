using MediatR;
using Prorim_MediatrHandling.EntityRequests.Receituario.Results;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Requests;

public class DownloadReceitaRequest : IRequest<DownloadReceitaResult>
{
    public int id { get; set; }
}