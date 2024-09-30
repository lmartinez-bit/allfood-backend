using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllfoodBackend.model
{
    public class Producto
    {

        public int proId { get; set; }
        public int proCant { get; set; }
        public double proPrecio { get; set; }
        public string proNombre { get; set; }
        public int categoriaProductoCatId { get; set; }
        public char proEsNuevo { get; set; }
        public char proEnDescuento { get; set; }
        public string proImgUrl { get; set; }
        public char proEstado { get; set; }
        public string proDesc { get; set; }
        public List<Adicional> adicionales { get; set; }

        public Producto()
        {
            adicionales = new List<Adicional>(); 
        }

    }
}
