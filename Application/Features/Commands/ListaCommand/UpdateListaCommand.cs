using Application.Features.DTOs;
using Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.ListaCommand
{
    public class UpdateListaCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public List<ItemDto> Items { get; set; }
    }
}
