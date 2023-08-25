using System;
using System.Collections.Generic;

namespace EcommerceRopa.Models
{
    public partial class Prenda
    {
        public Prenda()
        {
            Inventarios = new HashSet<Inventario>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Talla { get; set; }
        public decimal? Precio { get; set; }
        public string? Color { get; set; }
        public string? Marca { get; set; }
        public string? Estilo { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
