using Prorim_MediatrHandling.EntityRequests.Receituario.Requests;
using Prorim_MediatrHandling.EntityRequests.Receituario.Results;
using Prorim_MediatrHandling.Interfaces;
using MediatR;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Handlers
{
    public class GetReceituarioByIDRequestHandler : IRequestHandler<GetReceituarioByIDRequest, GetReceituarioByIDResult>
    {
        private readonly IReceituarioRepository _receituarioRepository;

        public GetReceituarioByIDRequestHandler(IReceituarioRepository receituarioRepository)
        {
            _receituarioRepository = receituarioRepository;
        }

        public async Task<GetReceituarioByIDResult> Handle(GetReceituarioByIDRequest request, CancellationToken cancellationToken)
        {
            var result = await _receituarioRepository.GetByID(request.ID);

            return new GetReceituarioByIDResult
            {
                nomeMedico = result.nomeMedico,
                nomeReceita = result.nomeReceita,
                idPaciente = result.idPaciente,
            };
        }
    }
}