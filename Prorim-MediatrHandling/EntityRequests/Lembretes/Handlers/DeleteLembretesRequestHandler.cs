using DevExpress.Mvvm.POCO;
using Prorim_MediatrHandling.EntityRequests.Lembretes.Interfaces;
using Prorim_MediatrHandling.EntityRequests.Lembretes.Requests;
using Prorim_MediatrHandling.EntityRequests.Lembretes.Results;
using Prorim_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Lembretes.Handlers
{
    public class DeleteLembretesRequestHandler : IRequestHandler<DeleteLembretesRequest, bool>
    {
        private readonly ILembretesRepository _lembretesRepository;
        public DeleteLembretesRequestHandler(ILembretesRepository lembretesRepository) { _lembretesRepository = lembretesRepository; }

        public async Task<bool> Handle(DeleteLembretesRequest request, CancellationToken cancellationToken)
        {
            return await _lembretesRepository.Delete(request.ID);
        }
    }
}