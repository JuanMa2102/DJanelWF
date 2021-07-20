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
    public class ProductoCompraRepository : Repository, IProductoCompraRepository
    {
        public async Task<ProductoCompra> AddAsync(ProductoCompra element, object IdUsuario)
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
                            var dynamicParametersStock = new DynamicParameters();
                            dynamicParametersStock.Add("@IdProducto", element.DatosProducto.IdProducto);
                            dynamicParametersStock.Add("@Cantidad", element.Cantidad);
                            await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_Add_Stock]", param: dynamicParametersStock, commandType: CommandType.StoredProcedure, transaction: tran);

                            var dynamicParameters = new DynamicParameters();
                            dynamicParameters.Add("@IdProducto", element.DatosProducto.IdProducto);
                            dynamicParameters.Add("@IdProveedor", element.DatosProveedor.IdProveedor);
                            dynamicParameters.Add("@Costo", element.Costo);
                            dynamicParameters.Add("@Fecha", element.Fecha);
                            dynamicParameters.Add("@Cantidad", element.Cantidad);
                            dynamicParameters.Add("@Total", element.Total);
                            dynamicParameters.Add("@Usuario", IdUsuario);
                            var result = await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_Create_ProductoCompra]", param: dynamicParameters, commandType: CommandType.StoredProcedure, transaction: tran);
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
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ProductoCompra> UpdateAsync(ProductoCompra element, object IdUsuario)
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
                            var dynamicParametersStockXID = new DynamicParameters();
                            dynamicParametersStockXID.Add("@IdProducto", element.DatosProducto.IdProducto);
                            var stock = await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_Get_StockProductoXID]", param: dynamicParametersStockXID, commandType: CommandType.StoredProcedure, transaction: tran);

                            var dynamicParametersStockCompraXID = new DynamicParameters();
                            dynamicParametersStockCompraXID.Add("@IdProductoCompra", element.IdProductoCompra);
                            var stockCompra = await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_Get_StockCompraXID]", param: dynamicParametersStockCompraXID, commandType: CommandType.StoredProcedure, transaction: tran);

                            var x = stock - (stockCompra - element.Cantidad); //Al obtener la cantidad del anterios y de la nueva cantidad, estamos obteniendo la cantidad de producto que no existen en el stock fisico, por lan tanto no se debio vender
                            if (x >= 0)
                            {
                                var dynamicParametersStock = new DynamicParameters();
                                dynamicParametersStock.Add("@IdProducto", element.DatosProducto.IdProducto);
                                dynamicParametersStock.Add("@Cantidad", stockCompra - element.Cantidad);
                                await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_Sub_Stock]", param: dynamicParametersStock, commandType: CommandType.StoredProcedure, transaction: tran);


                                var dynamicParameters = new DynamicParameters();
                                dynamicParameters.Add("@IdProductoCompra", element.IdProductoCompra);
                                dynamicParameters.Add("@IdProducto", element.DatosProducto.IdProducto);
                                dynamicParameters.Add("@IdProveedor", element.DatosProveedor.IdProveedor);
                                dynamicParameters.Add("@Costo", element.Costo);
                                dynamicParameters.Add("@Fecha", element.Fecha);
                                dynamicParameters.Add("@Cantidad", element.Cantidad);
                                dynamicParameters.Add("@Total", element.Total);
                                dynamicParameters.Add("@Usuario", IdUsuario);
                                var result = await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_Update_ProductoCompra]", param: dynamicParameters, commandType: CommandType.StoredProcedure, transaction: tran);
                                element.Resultado = result;

                                tran.Commit();
                            }
                            else element.Resultado = -1;
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
        public async Task<int> DeleteCompraAsync(object IdProductoCompra, object IdProducto, object IdUsuario)
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
                            var dynamicParametersStockXID = new DynamicParameters();
                            dynamicParametersStockXID.Add("@IdProducto", IdProducto);
                            var stock = await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_Get_StockProductoXID]", param: dynamicParametersStockXID, commandType: CommandType.StoredProcedure, transaction: tran);

                            var dynamicParametersStockCompraXID = new DynamicParameters();
                            dynamicParametersStockCompraXID.Add("@IdProductoCompra", IdProductoCompra);
                            var stockCompra = await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_Get_StockCompraXID]", param: dynamicParametersStockCompraXID, commandType: CommandType.StoredProcedure, transaction: tran);

                            var x = stock - (stockCompra); //Al obtener la cantidad del anterios y de la nueva cantidad, estamos obteniendo la cantidad de producto que no existen en el stock fisico, por lan tanto no se debio vender
                            if (x >= 0)
                            {
                                var dynamicParametersStock = new DynamicParameters();
                                dynamicParametersStock.Add("@IdProducto", IdProducto);
                                dynamicParametersStock.Add("@Cantidad", stockCompra);
                                await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_Sub_Stock]", param: dynamicParametersStock, commandType: CommandType.StoredProcedure, transaction: tran);


                                var dynamicParameters = new DynamicParameters();
                                dynamicParameters.Add("@IdProductoCompra", IdProductoCompra);
                                dynamicParameters.Add("@Usuario", IdUsuario);
                                var result = await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_Delete_ProductoCompra]", param: dynamicParameters, commandType: CommandType.StoredProcedure, transaction: tran);
                                    
                                tran.Commit();
                                return result;
                            }
                            else return -1;
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

        public Task<bool> ExistAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductoCompra>> GetAllAsync()
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();

                   var productoCompras = (await conexion.QueryAsync<ProductoCompra, Producto, Proveedor, ProductoCompra>("[Producto].[DJanel_GetAll_ProductoCompra]",
                        (x, Producto, Proveedor) =>
                        {
                            x.DatosProducto = Producto;
                            x.DatosProveedor = Proveedor;
                            return x;
                        },
                        splitOn: "IdProducto,IdProveedor",
                        param: dynamicParameters, commandType: CommandType.StoredProcedure));
                    
                    return productoCompras;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<ProductoCompra> GetAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(object id, object IdUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReporteCompra>> GetReporteComprasAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@startDate", startDate);
                    dynamicParameters.Add("@endDate", endDate);
                    var result = await conexion.QueryAsync<ReporteCompra>("[Producto].[DJanel_Get_ReporteCompra]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

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
