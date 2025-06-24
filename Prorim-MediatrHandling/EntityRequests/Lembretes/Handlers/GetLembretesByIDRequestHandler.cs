using Prorim_MediatrHandling.EntityRequests.Lembretes.Requests;
using Prorim_MediatrHandling.EntityRequests.Lembretes.Results;
using Prorim_MediatrHandling.Interfaces;
using MediatR;

namespace Prorim_MediatrHandling.EntityRequests.Lembretes.Handlers
{
    public class GetLembretesByIDRequestHandler : IRequestHandler<GetLembretesByIDRequest, GetLembretesByIDResult>
    {
        private readonly ILembretesRepository _lembretesRepository;

        public GetLembretesByIDRequestHandler(ILembretesRepository lembretesRepository)
        {
            _lembretesRepository = lembretesRepository;
        }

        public async Task<GetLembretesByIDResult> Handle(GetLembretesByIDRequest request, CancellationToken cancellationToken)
        {
            var result = await _lembretesRepository.GetByID(request.ID);

            return new GetLembretesByIDResult
            {
                id = result.id,
                nomeLembrete = result.nomeLembrete,
                DataLembrete = result.DataLembrete,
                clienteID = result.clienteID,
                tipoTransplante = result.tipoTransplante,
                remedio = result.remedio
            };
        }
    }
}