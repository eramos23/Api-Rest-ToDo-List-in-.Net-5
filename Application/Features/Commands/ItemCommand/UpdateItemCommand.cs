using Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.ItemCommand
{
    public class UpdateItemCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int IdLista { get; set; }
        public string Descripcion { get; set; }
        public bool Completado { get; set; }
    }
}
