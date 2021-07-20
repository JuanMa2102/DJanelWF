using Dapper;
using DJanel.Muebles.DataAccess.Contracts.DTOs;
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
    public class VentaRepository : Repository, IVentaRepository
    {
        public async Task<Venta> AddAsync(Venta element, object IdUsuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    using (var tran = conexion.BeginTransaction())
                    {
                        try
                        {
                            var dynamicParameters = new DynamicParameters();
                            dynamicParameters.Add("@IdUsuario", element.Usuario.IdUsuario);
                            dynamicParameters.Add("@IdCliente", element.Cliente.IdCliente);
                            dynamicParameters.Add("@Total", element.Total);
                            var id = await conexion.ExecuteScalarAsync<int>("[Venta].[DJanel_Create_Venta]", param: dynamicParameters, commandType: CommandType.StoredProcedure, transaction: tran);
                            element.IdVenta = id;
                            foreach (var item in element.ListaVentaDetalle)
                            {
                                var dynamicParametersStockXID = new DynamicParameters();
                                dynamicParametersStockXID.Add("@IdProducto", item.Producto.IdProducto);
                                var StockActual = await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_Get_StockProductoXID]", param: dynamicParametersStockXID, commandType: CommandType.StoredProcedure, transaction: tran);
                                if (StockActual >= item.Cantidad)
                                {
                                    var dynamicParametersSubStock = new DynamicParameters();
                                    dynamicParametersSubStock.Add("@IdProducto", item.Producto.IdProducto);
                                    dynamicParametersSubStock.Add("@Cantidad", item.Cantidad);
                                    await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_Sub_Stock]", param: dynamicParametersSubStock, commandType: CommandType.StoredProcedure, transaction: tran);

                                    var dynamicParametersDetail = new DynamicParameters();
                                    dynamicParametersDetail.Add("@IdVenta", id);
                                    dynamicParametersDetail.Add("@IdProducto", item.Producto.IdProducto);
                                    dynamicParametersDetail.Add("@Cantidad", item.Cantidad);
                                    dynamicParametersDetail.Add("@Precio", item.Precio);
                                    dynamicParametersDetail.Add("@Total", item.Total);
                                    element.Resultado = await conexion.ExecuteScalarAsync<int>("[Venta].[DJanel_Create_VentaDetalle]", param: dynamicParametersDetail, commandType: CommandType.StoredProcedure, transaction: tran);
                                }
                                else element.Resultado = -1;
                            }

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
            catch (Exception)
            {

                throw;
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

        public async Task<IEnumerable<Venta>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Venta> GetAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Venta> UpdateAsync(Venta element, object IdUsuario)
        {
            throw new NotImplementedException();
        }
        public async Task<string> GetFolioAsync()
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    var result = await conexion.QueryFirstAsync<string>("[Venta].[DJanel_Get_Folio]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Producto> GetProductoAsync(string clave)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@ClaveBusqueda", clave);
                    var result = await conexion.QuerySingleAsync<Producto>("[Producto].[DJanel_Get_ProductoXClave]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ReporteVenta>> GetReporteVentaAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@startDate", startDate);
                    dynamicParameters.Add("@endDate", endDate);
                    var result = await conexion.QueryAsync<ReporteVenta>("[Venta].[DJanel_Get_ReporteVenta]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ReporteVenta>> GetVentaAsync(int IdVenta)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@IdVenta", IdVenta);
                    var result = await conexion.QueryAsync<ReporteVenta>("[Venta].[DJanel_Get_ReporteVentaByIdCliente]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
