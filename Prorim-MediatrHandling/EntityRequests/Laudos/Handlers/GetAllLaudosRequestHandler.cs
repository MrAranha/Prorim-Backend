using MediatR;
using Prorim_MediatrHandling.Entities;
using Prorim_MediatrHandling.EntityRequests.Laudos.Requests;
using Prorim_MediatrHandling.Interfaces;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Handlers;

public class GetAllLaudosRequestHandler : IRequestHandler<GetAllLaudosRequest, List<TB_Laudos>>
{
    private readonly ILaudosRepository _repository;
    public GetAllLaudosRequestHandler(ILaudosRepository repository) { _repository = repository; }
    public async Task<List<TB_Laudos>> Handle(GetAllLaudosRequest request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAll();
        return result.ToList();
    }
}