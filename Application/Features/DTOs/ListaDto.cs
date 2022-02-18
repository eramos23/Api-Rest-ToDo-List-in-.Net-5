using System.Collections.Generic;

namespace Application.Features.DTOs
{
    public class ListaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool Eliminado { get; set; }
        public List<ItemDto> Items { get; set; }
    }
}
