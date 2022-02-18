using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Lista : BaseEntity
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool Eliminado { get; set; }
        public List<Item> Items { get; set; }
    }
}
