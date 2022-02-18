using Application.Features.DTOs;
using Application.Wrapper;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Commands.ListaCommand
{
    public class CreateListaCommand : IRequest<Response<int>>
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public List<ItemDto> Items { get; set; }
    }

    
}
