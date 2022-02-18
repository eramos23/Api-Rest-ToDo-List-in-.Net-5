using Application.Features.DTOs;
using Application.Wrapper;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Queries.Items
{
    public class GetAllItemQuery : IRequest<Response<List<ItemDto>>>
    {
    }
}
