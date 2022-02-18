using Application.Features.DTOs;
using Application.Wrapper;
using MediatR;

namespace Application.Features.Queries.Items
{
    public class GetSigleItemQuery: IRequest<Response<ItemDto>>
    {
        public int Id { get; set; }
    }
}
