using Application.Features.DTOs;
using Application.Wrapper;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Queries.Lista
{
    public class GetAllListaQuery : IRequest<Response<List<ListaDto>>>
    {
    }
}
