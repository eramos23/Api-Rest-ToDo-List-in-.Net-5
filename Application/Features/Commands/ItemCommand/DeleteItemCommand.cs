using Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.ItemCommand
{
    public class DeleteItemCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }
        public int Tipo { get; set; }
    }
}
