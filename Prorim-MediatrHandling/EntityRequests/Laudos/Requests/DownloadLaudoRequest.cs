using MediatR;
using Prorim_MediatrHandling.EntityRequests.Laudos.Results;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Requests;

public class DownloadLaudoRequest : IRequest<DownloadLaudoResult>
{
    public int id { get; set; }
}