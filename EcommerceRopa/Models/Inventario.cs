using System;
using System.Collections.Generic;

namespace EcommerceRopa.Models
{
    public partial class Inventario
    {
        public int Id { get; set; }
        public int? PrendaId { get; set; }
        public int? Cantidad { get; set; }
        public int? Existencia { get; set; }
        public string? Departamento { get; set; }

        public virtual Prenda? Prenda { get; set; }
    }
}
