using AutoMapper;
using MediatR;
using Prorim_MediatrHandling.Entities;
using Prorim_MediatrHandling.EntityRequests.Receituario.Requests;
using Prorim_MediatrHandling.Interfaces;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Handlers;

public class GetAllReceitasRequestHandler : IRequestHandler<GetAllReceitasRequest, List<TB_Receituario>>
{
    private readonly IReceituarioRepository _repository;
    public GetAllReceitasRequestHandler(IReceituarioRepository repository)
    {
        _repository = repository;
    }
    
    
    public async Task<List<TB_Receituario>> Handle(GetAllReceitasRequest request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAll();
        return result.ToList();
    }
}