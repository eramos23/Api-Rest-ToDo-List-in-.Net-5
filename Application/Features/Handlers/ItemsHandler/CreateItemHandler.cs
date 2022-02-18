﻿using Application.Features.Commands.ItemCommand;
using Application.Interfaces;
using Application.Wrapper;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.ItemCommand
{
    public class CreateItemHandler : IRequestHandler<CreateItemCommand, Response<int>>
    {
        private readonly IItem _repository;
        private readonly IMapper _mapper;
        public CreateItemHandler(IItem repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var newRegister = _mapper.Map<Item>(request);
            var data = await _repository.Create(newRegister);
            return new Response<int>(data, ResponseMessages.CreateSuccessfully);
        }
    }
}
