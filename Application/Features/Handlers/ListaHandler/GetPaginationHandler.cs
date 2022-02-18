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
    public class GetPaginationHandler : IRequestHandler<GetPaginationQuery, ResponsePagination<List<ListaDto>>>
    {
        private readonly ILista _repository;
        private readonly IMapper _mapper;

        public GetPaginationHandler(ILista repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponsePagination<List<ListaDto>>> Handle(GetPaginationQuery request, CancellationToken cancellationToken)
        {
            var total = _repository.Total();
            var list = await _repository.GetAllPaginated(request.Pagina, request.TamanioPagina);
            var requestList = _mapper.Map<List<ListaDto>>(list);
            return new ResponsePagination<List<ListaDto>>(requestList, total);
        }
    }
}
