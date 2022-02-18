using Application.Features.DTOs;
using Application.Wrapper;
using MediatR;

namespace Application.Features.Queries.Lista
{
    public class GetSigleListaQuery: IRequest<Response<ListaDto>>
    {
        public int Id { get; set; }
    }
}
