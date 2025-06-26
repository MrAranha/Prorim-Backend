using DevExpress.Mvvm.POCO;
using Prorim_MediatrHandling.EntityRequests.Receituario.Interfaces;
using Prorim_MediatrHandling.EntityRequests.Receituario.Requests;
using Prorim_MediatrHandling.EntityRequests.Receituario.Results;
using Prorim_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Handlers
{
    public class DeleteReceituarioRequestHandler : IRequestHandler<DeleteReceituarioRequest, bool>
    {
        private readonly IReceituarioRepository _receituarioRepository;
        public DeleteReceituarioRequestHandler(IReceituarioRepository receituarioRepository) { _receituarioRepository = receituarioRepository; }

        public async Task<bool> Handle(DeleteReceituarioRequest request, CancellationToken cancellationToken)
        {
            return await _receituarioRepository.Delete(request.ID);
        }
    }
}