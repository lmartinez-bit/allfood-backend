using AllfoodBackend.model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllfoodBackend.data.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private PostgreSQLConfiguration _connectionString;

        public ProductoRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public List<Producto> GetMenu()
        {
            var sql = @"
        select 
	        p.pro_id as proId,
	        p.pro_cant proCant,
	        p.pro_precio as proPrecio,
	        p.pro_nombre as proNombre,
	        p.categoria_producto_cat_id as categoriaProductoCatId,
	        p.pro_es_nuevo as proEsNuevo,
	        p.pro_en_descuento as proEnDescuento,
	        p.pro_img_url as proImgUrl,
	        p.pro_estado as proEstado,
	        p.pro_desc as proDesc,
	        a.adi_id as adiId,
	        a.adi_nombre as adiNombre,
	        a.adi_img_url as adiImgUrl,
	        a.adi_categoria as adiCategoria,
	        a.adi_cant_adicional as adiCantAdicional,
	        a.adi_precio as adiPrecio
        from allfood.producto p 
        left join allfood.producto_adicional pa on p.pro_id = pa.producto_pro_id 
        left join allfood.adicionales a on pa.adicionales_adi_id = a.adi_id";

            var productoDictionary = new Dictionary<int, Producto>();

            using (var connection = dbConnection()) // Suponiendo que usas PostgreSQL
            {
                connection.Open();

                var productos = connection.Query<Producto, Adicional, Producto>(sql,
                    (producto, adicional) =>
                    {
                        if (!productoDictionary.TryGetValue(producto.proId, out var productoEntry))
                        {
                            productoEntry = producto;
                            productoDictionary.Add(producto.proId, productoEntry);
                        }

                        if (adicional != null)
                        {
                            productoEntry.adicionales.Add(adicional);
                        }

                        return productoEntry;
                    },
                    splitOn: "adiId" // La primera columna del segundo objeto (Adicional)
                );

                return productoDictionary.Values.ToList();
            }
        }
    }
}
