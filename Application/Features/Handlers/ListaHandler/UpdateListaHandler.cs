using Application.Features.Commands.ListaCommand;
using Application.Interfaces;
using Application.Wrapper;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.ListasHandler
{
    public class UpdateListaHandler : IRequestHandler<UpdateListaCommand, Response<int>>
    {
        private readonly ILista _repository;
        private readonly IMapper _mapper;
        public UpdateListaHandler(ILista repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateListaCommand request, CancellationToken cancellationToken)
        {
            var newRegister = _mapper.Map<Lista>(request);
            var data = await _repository.Update(newRegister);
            return new Response<int>(data, ResponseMessages.UpdateSuccessfully);
        }
    }
}
