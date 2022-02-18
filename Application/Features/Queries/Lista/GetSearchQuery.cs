using Application.Features.DTOs;
using Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Lista
{
    public class GetSearchQuery: IRequest<Response<List<ListaDto>>>
    {
        public string Texto { get; set; }
    }
}
