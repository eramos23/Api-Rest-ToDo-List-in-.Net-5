using Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.ItemCommand
{
    public class CreateItemCommand : IRequest<Response<int>>
    {
        public string IdLista { get; set; }
        public string Descripcion { get; set; }
    }
}
