using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntity
{
    public class EntityProduct
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Nombre { get; set; }
        public string Categoria  { get; set;}
        public bool EsNuevo { get; set; }
        public bool EstaEnDescuento { get; set; }

    }
}
