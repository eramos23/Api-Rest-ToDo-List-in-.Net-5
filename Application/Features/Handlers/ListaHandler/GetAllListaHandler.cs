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
    public class GetAllItemHandler : IRequestHandler<GetAllListaQuery, Response<List<ListaDto>>>
    {
        private readonly ILista _repository;
        private readonly IMapper _mapper;

        public GetAllItemHandler(ILista repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<List<ListaDto>>> Handle(GetAllListaQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAll();
            var requestList = _mapper.Map<List<ListaDto>>(list);
            return new Response<List<ListaDto>>(requestList);
        }
    }
}
