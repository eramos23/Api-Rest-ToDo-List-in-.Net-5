using Application.Features.DTOs;
using Application.Features.Queries.Lista;
using Application.Interfaces;
using Application.Wrapper;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.ListasHandler
{
    public class GetSigleListaHandler : IRequestHandler<GetSigleListaQuery, Response<ListaDto>>
    {
        private readonly ILista _repository;
        private readonly IMapper _mapper;
        public GetSigleListaHandler(ILista repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<ListaDto>> Handle(GetSigleListaQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.GetSingle(request.Id);

            if (lista == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                var dto = _mapper.Map<ListaDto>(lista);
                return new Response<ListaDto>(dto);
            }  
        }
    }
}
