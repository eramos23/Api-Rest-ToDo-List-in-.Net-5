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
    public class GetAllItemHandler : IRequestHandler<GetAllItemQuery, Response<List<ItemDto>>>
    {
        private readonly IItem _repository;
        private readonly IMapper _mapper;

        public GetAllItemHandler(IItem repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<List<ItemDto>>> Handle(GetAllItemQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAll();
            var requestList = _mapper.Map<List<ItemDto>>(list);
            return new Response<List<ItemDto>>(requestList);
        }
    }
}
