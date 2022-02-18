using Application.Features.DTOs;
using Application.Features.Queries.Items;
using Application.Interfaces;
using Application.Wrapper;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.ItemCommand
{
    public class GetSigleItemaHandler : IRequestHandler<GetSigleItemQuery, Response<ItemDto>>
    {
        private readonly IItem _repository;
        private readonly IMapper _mapper;
        public GetSigleItemaHandler(IItem repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<ItemDto>> Handle(GetSigleItemQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.GetSingle(request.Id);

            if (lista == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                var dto = _mapper.Map<ItemDto>(lista);
                return new Response<ItemDto>(dto);
            }  
        }
    }
}
