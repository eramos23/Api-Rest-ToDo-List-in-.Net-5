using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Item : BaseEntity
    {
        public int IdLista { get; set; }
        public string Descripcion { get; set; }
        public bool Completado { get; set; }
        public bool Eliminado { get; set; }

        [ForeignKey("IdLista")]
        public Lista Lista { get; set; }

    }
}
