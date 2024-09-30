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
    public class CategoriaRepository : ICategoriaRepository
    {
        private PostgreSQLConfiguration _connectionString;

        public CategoriaRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Categoria>> GetCategoria()
        {

            var db = dbConnection();
            const string sql = @"SELECT cat_id AS catId, cat_nombre AS catNombre, cat_desc AS catDesc, cat_img_url AS catImgUrl FROM allfood.categoria_producto";
            return await db.QueryAsync<Categoria>(sql, new { });
        }
    }
}
