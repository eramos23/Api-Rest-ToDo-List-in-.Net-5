using Application.Features.Commands.ListaCommand;
using Application.Interfaces;
using Application.Wrapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.ListasHandler
{
    public class DeleteItemHandler : IRequestHandler<DeleteListaCommand, Response<bool>>
    {
        private readonly ILista _repository;
        public DeleteItemHandler(ILista repository)
        {
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(DeleteListaCommand request, CancellationToken cancellationToken)
        {
            var exist = _repository.Exist(request.Id);
            if (exist == false)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                if (request.Tipo == 0)
                {
                    var response = await _repository.Delete(request.Id);
                    return new Response<bool>(response, ResponseMessages.DeleteSuccessfully);
                } else {
                    var response = await _repository.DeleteLogic(request.Id);
                    return new Response<bool>(response, ResponseMessages.DeleteLogincSuccessfully);
                }
                
            }
        }
    }
}
