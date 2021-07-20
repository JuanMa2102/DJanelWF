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
    public class UsuarioRepository : Repository, IUsuarioRepository
    {
        async public Task<Usuario> AddAsync(Usuario element, object IdUsuario)
        {
            using (IDbConnection conexion = new SqlConnection(WebConnectionString))
            {
                conexion.Open();
                using (var tran = conexion.BeginTransaction())
                {
                    try
                    {
                        var dynamicParameters = new DynamicParameters();
                        dynamicParameters.Add("@Username", element.Username);
                        dynamicParameters.Add("@Password", element.Password);
                        dynamicParameters.Add("@IdRol", element.DatosRol.IdRol);
                        dynamicParameters.Add("@Usuario", IdUsuario);
                        var Id = await conexion.ExecuteScalarAsync<int>("[Usuario].[DJanel_Create_Usuario]", param: dynamicParameters, commandType: CommandType.StoredProcedure, transaction: tran);

                        var dynamicParametersDetail= new DynamicParameters();
                        dynamicParametersDetail.Add("@IdUsuario", Id);
                        dynamicParametersDetail.Add("@Nombre", element.Nombre);
                        dynamicParametersDetail.Add("@Apellido_Pat", element.Apellido_Pat);
                        dynamicParametersDetail.Add("@Apellido_Mat", element.Apellido_Mat);
                        dynamicParametersDetail.Add("@Domicilio", element.Domicilio);
                        dynamicParametersDetail.Add("@Telefono", element.Telefono);
                        var result = await conexion.ExecuteScalarAsync<int>("[Usuario].[DJanel_Create_UsuarioDetalle]", param: dynamicParametersDetail, commandType: CommandType.StoredProcedure, transaction: tran);
                        element.Resultado = result;

                        tran.Commit();
                        return element;
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
            
        }
        public async Task<Usuario> UpdateAsync(Usuario element, object IdUsuario)
        {
            using (IDbConnection conexion = new SqlConnection(WebConnectionString))
            {
                conexion.Open();
                using (var tran = conexion.BeginTransaction())
                {
                    try
                    {
                        var dynamicParameters = new DynamicParameters();
                        dynamicParameters.Add("@IdUsuario", element.IdUsuario);
                        dynamicParameters.Add("@Username", element.Username);
                        dynamicParameters.Add("@IdRol", element.DatosRol.IdRol);
                        dynamicParameters.Add("@Usuario", IdUsuario);
                        await conexion.ExecuteScalarAsync<int>("[Usuario].[DJanel_Update_Usuario]", param: dynamicParameters, commandType: CommandType.StoredProcedure, transaction: tran);

                        if(element.Password != string.Empty)
                        {
                            var dynamicParametersPass = new DynamicParameters();
                            dynamicParametersPass.Add("@IdUsuario", element.IdUsuario);
                            dynamicParametersPass.Add("@Password", element.Password);
                            dynamicParametersPass.Add("@Usuario", IdUsuario);
                            await conexion.ExecuteScalarAsync<int>("[Usuario].[DJanel_Update_Password]", param: dynamicParametersPass, commandType: CommandType.StoredProcedure, transaction: tran);

                        }

                        var dynamicParametersDetail = new DynamicParameters();
                        dynamicParametersDetail.Add("@IdUsuario", element.IdUsuario);
                        dynamicParametersDetail.Add("@Nombre", element.Nombre);
                        dynamicParametersDetail.Add("@Apellido_Pat", element.Apellido_Pat);
                        dynamicParametersDetail.Add("@Apellido_Mat", element.Apellido_Mat);
                        dynamicParametersDetail.Add("@Domicilio", element.Domicilio);
                        dynamicParametersDetail.Add("@Telefono", element.Telefono);
                        var result = await conexion.ExecuteScalarAsync<int>("[Usuario].[DJanel_Update_UsuarioDetalle]", param: dynamicParametersDetail, commandType: CommandType.StoredProcedure, transaction: tran);
                        element.Resultado = result;

                        tran.Commit();
                        return element;
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
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
                    dynamicParameters.Add("@IdUsuario", id);
                    dynamicParameters.Add("@Usuario", IdUsuario);
                    var result = await conexion.ExecuteScalarAsync<int>("[Usuario].[DJanel_Delete_Usuario]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                    return result;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> ExistAsync(object id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    List<Usuario> ListaUsuario = new List<Usuario>();
                    Usuario item;
                    
                    var dr = await conexion.ExecuteReaderAsync("[Usuario].[DJanel_GetAll_Usuarios]", commandType: CommandType.StoredProcedure);
                    while (dr.Read())
                    {
                        item = new Usuario();
                        item.IdUsuario = dr.GetInt32(dr.GetOrdinal("IdUsuario"));
                        item.Username = dr.GetString(dr.GetOrdinal("Username"));
                        item.Nombre = dr.GetString(dr.GetOrdinal("Nombre"));
                        item.Apellido_Pat = dr.GetString(dr.GetOrdinal("Apellido_Pat"));
                        item.Apellido_Mat = dr.GetString(dr.GetOrdinal("Apellido_Mat"));
                        item.Domicilio = dr.GetString(dr.GetOrdinal("Domicilio"));
                        item.Telefono = dr.GetString(dr.GetOrdinal("Telefono"));

                        item.DatosRol.IdRol = dr.GetInt32(dr.GetOrdinal("IdRol"));
                        item.DatosRol.Nombre = dr.GetString(dr.GetOrdinal("NombreRol"));

                        ListaUsuario.Add(item);
                    }

                    return ListaUsuario;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Usuario> GetAsync(object id)
        {
            try
            {
                Usuario item = new Usuario(); ;
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@IdUsuario", id);

                    var dr = await conexion.ExecuteReaderAsync("[Usuario].[DJanel_Get_Usuario]", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                    while (dr.Read())
                    {
                        item.IdUsuario = dr.GetInt32(dr.GetOrdinal("IdUsuario"));
                        item.Username = dr.GetString(dr.GetOrdinal("Username"));
                        item.Nombre = dr.GetString(dr.GetOrdinal("Nombre"));
                        item.Apellido_Pat = dr.GetString(dr.GetOrdinal("Apellido_Pat"));
                        item.Apellido_Mat = dr.GetString(dr.GetOrdinal("Apellido_Mat"));
                        item.Domicilio = dr.GetString(dr.GetOrdinal("Domicilio"));
                        item.Telefono = dr.GetString(dr.GetOrdinal("Telefono"));

                        item.DatosRol.IdRol = dr.GetInt32(dr.GetOrdinal("IdRol"));
                        item.DatosRol.Nombre = dr.GetString(dr.GetOrdinal("NombreRol"));
                    }dr.Close();
                }

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> EsCuentaUnica(string Username)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Username", Username);
                    var dr = await conexion.ExecuteScalarAsync<int>("[Usuario].[DJanel_ValidarNombre_Usuario]", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                    return dr;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Usuario> Login(string Account, string Password)
        {
            try
            {
                Usuario loginRequests = new Usuario();
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Username", Account);
                    dynamicParameters.Add("@Password", Password);
                    var dr = await conexion.ExecuteReaderAsync("[Usuario].[DJanel_Login]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                    while (dr.Read())
                    {
                        loginRequests.Resultado = !dr.IsDBNull(dr.GetOrdinal("IsValid")) ? dr.GetInt32(dr.GetOrdinal("IsValid")) : 0;
                        if (loginRequests.Resultado > 0)
                        {
                            loginRequests = await GetAsync(loginRequests.Resultado);
                            loginRequests.Resultado = 1;
                        }
                    }
                    dr.Close();
                }
                return loginRequests;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
