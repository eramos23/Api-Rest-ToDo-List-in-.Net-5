using Application.Features.DTOs;
using Application.Features.Queries.Lista;
using Application.Interfaces;
using Application.Wrapper;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.ListaHandler
{
    public class GetSearchHandler : IRequestHandler<GetSearchQuery, Response<List<ListaDto>>>
    {
        private readonly ILista _repository;
        private readonly IMapper _mapper;

        public GetSearchHandler(ILista repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<List<ListaDto>>> Handle(GetSearchQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Search(request.Texto);
            var requestList = _mapper.Map<List<ListaDto>>(list);
            return new Response<List<ListaDto>>(requestList);
        }
    }
}
