using DevExpress.Mvvm.POCO;
using Prorim_MediatrHandling.EntityRequests.Laudos.Interfaces;
using Prorim_MediatrHandling.EntityRequests.Laudos.Requests;
using Prorim_MediatrHandling.EntityRequests.Laudos.Results;
using Prorim_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Handlers
{
    public class DeleteLaudosRequestHandler : IRequestHandler<DeleteLaudosRequest, bool>
    {
        private readonly ILaudosRepository _laudosRepository;
        public DeleteLaudosRequestHandler(ILaudosRepository laudosRepository) { _laudosRepository = laudosRepository; }

        public async Task<bool> Handle(DeleteLaudosRequest request, CancellationToken cancellationToken)
        {
            return await _laudosRepository.Delete(request.ID);
        }
    }
}