using Prorim_MediatrHandling.EntityRequests.Laudos.Requests;
using Prorim_MediatrHandling.EntityRequests.Laudos.Results;
using Prorim_MediatrHandling.Interfaces;
using MediatR;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Handlers
{
    public class GetLaudosByIDRequestHandler : IRequestHandler<GetLaudosByIDRequest, GetLaudosByIDResult>
    {
        private readonly ILaudosRepository _laudosRepository;

        public GetLaudosByIDRequestHandler(ILaudosRepository laudosRepository)
        {
            _laudosRepository = laudosRepository;
        }

        public async Task<GetLaudosByIDResult> Handle(GetLaudosByIDRequest request, CancellationToken cancellationToken)
        {
            var result = await _laudosRepository.GetByID(request.ID);

            return new GetLaudosByIDResult
            {
                id = result.id,
                nomeMedico = result.nomeMedico,
                idPaciente = result.idPaciente,
            };
        }
    }
}