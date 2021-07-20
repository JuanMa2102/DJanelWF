using Dapper;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using DJanel.Muebles.DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Repositories.General
{
    public class ClienteRepository : Repository, IClienteRepository
    {
        public async Task<Cliente> AddAsync(Cliente element, object IdUsuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Nombre", element.Nombre);
                    dynamicParameters.Add("@Apellido_Pat", element.Apellido_Pat);
                    dynamicParameters.Add("@Apellido_Mat", element.Apellido_Mat);
                    dynamicParameters.Add("@Telefono", element.Telefono);
                    dynamicParameters.Add("@Domicilio", element.Domicilio);
                    dynamicParameters.Add("@Fecha_Nac", element.Fecha_Nac);
                    dynamicParameters.Add("@Usuario", IdUsuario);
                    var result = await conexion.ExecuteScalarAsync<int>("[Cliente].[DJanel_Create_Cliente]", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                    element.Resultado = result;

                    return element;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteAsync(object id, object IdUsuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {

                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@IdCliente", id);
                    dynamicParameters.Add("@Usuario", IdUsuario);
                    var result = await conexion.ExecuteScalarAsync<int>("[Cliente].[DJanel_Delete_Cliente]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                    return result;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    var result = await conexion.QueryAsync<Cliente>("[Cliente].[DJanel_GetAll_Clientes]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Cliente> UpdateAsync(Cliente element, object IdUsuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@IdCliente", element.IdCliente);
                    dynamicParameters.Add("@Nombre", element.Nombre);
                    dynamicParameters.Add("@Apellido_Pat", element.Apellido_Pat);
                    dynamicParameters.Add("@Apellido_Mat", element.Apellido_Mat);
                    dynamicParameters.Add("@Telefono", element.Telefono);
                    dynamicParameters.Add("@Domicilio", element.Domicilio);
                    dynamicParameters.Add("@Fecha_Nac", element.Fecha_Nac);
                    dynamicParameters.Add("@Usuario", IdUsuario);
                    var result = await conexion.ExecuteScalarAsync<int>("[Cliente].[DJanel_Update_Cliente]", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                    element.Resultado = result;

                    return element;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Cliente> GetAsync(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExistAsync(object id)
        {
            throw new System.NotImplementedException();
        }

        public async  Task<IEnumerable<Cliente>> Busqueda(string Busqueda)
        {
            using (IDbConnection conexion = new SqlConnection(WebConnectionString))
            {
                conexion.Open();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Busqueda", Busqueda);
                var result = await conexion.QueryAsync<Cliente>("[Cliente].[DJanel_Busqueda_Cliente]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
