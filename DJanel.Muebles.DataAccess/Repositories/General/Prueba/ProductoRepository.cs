using Dapper;
using DJanel.Muebles.DataAccess.Contracts.Entities.Prueba;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General.Prueba;
using DJanel.Muebles.DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Repositories.General.Prueba
{
    public class ProductoRepository : Repository, IProductoRepository
    {
        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            using (IDbConnection conexion = new SqlConnection(WebConnectionString))
            {
                conexion.Open();
                var dynamicParameters = new DynamicParameters();
                List<Producto> Lista = new List<Producto>();
                Producto Item;
                var dr = await conexion.ExecuteReaderAsync("[dbo].[MueblesDJ_Get_FormaPago]", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                while (dr.Read())
                {
                    Item = new Producto();
                    Item.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    Item.Nombre = dr.GetString(dr.GetOrdinal("Nombre"));
                    Item.Precio = dr.GetDecimal(dr.GetOrdinal("Precio"));
                    Lista.Add(Item);
                }
                dr.Close();
                return Lista;
            }
        }

        async public Task<Producto> AddAsync(Producto element, object IdUsuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Nombre", element.Nombre);
                    dynamicParameters.Add("@Precio", element.Precio);
                    var result = await conexion.ExecuteScalarAsync<int>("[dbo].[MueblesDJ_A_FormaPago]", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                    //element.Resultado = result;
                    return element;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<int> DeleteAsync(object id, object IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> GetAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> UpdateAsync(Producto element, object IdUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
