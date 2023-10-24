using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekTon.ProductAPI.Domain.Entities;
using TekTon.ProductAPI.Domain.Interface;
using TekTon.ProductAPI.Domain.Seedwork;
using TekTon.ProductAPI.Domain.Seedwork.Data;
using TekTon.ProductAPI.Repository.Context;
using TekTon.ProductAPI.Repository.Repositories.Helper;
using TekTon.ProductAPI.Repository.Seedwork;

namespace TekTon.ProductAPI.Repository.Repositories
{
    public class ProductoRepository : BaseRepository, IProductoRepository
    {
        private readonly IStoreProcedureManager _storeProcedureManager;
        private ProductAPIContext _context;

        public ProductoRepository(ProductAPIContext dbContext,
                                       IStoreProcedureManager storeProcedureManager) : base(dbContext)
        {
            _storeProcedureManager = storeProcedureManager;
            _context = dbContext;
        }

        public async Task<IList<T>> ConsultarProducto<T>(int idProducto) where T : RawDTO
        {
            var parameters = new Dictionary<string, object>
            {
                { "P_IDPRODUCTO", idProducto }
            };
            return await _storeProcedureManager.ExecAsync<T>(Procedimiento.Producto.USP_OBTENER_PRODUCTO, parameters);
        }

        public async Task<IList<T>> ConsultarProductos<T>() where T : RawDTO
        {
            return await _storeProcedureManager.ExecAsync<T>(Procedimiento.Producto.USP_OBTENER_PRODUCTOS, null);
        }

        public async Task<Producto> SelectProducto(int idProducto)
        {
            return await All<Producto>()
                .Where(u => u.ID == idProducto)
                .FirstOrDefaultAsync() ?? new Producto();
        }

        public async Task<Producto> InsertarProducto(Producto producto)
        {
            await InsertAsync(producto);
            await _context.SaveChangesAsync();
            return await SelectProducto(producto.ID);
        }


        public async Task<Producto> ModificarProducto(Producto producto)
        {
            await UpdateAsync(producto);
            await _context.SaveChangesAsync();
            return await SelectProducto(producto.ID);
        }

        public async Task<Producto> EliminarProducto(Producto producto)
        {
            await DeleteAsync(producto);
            await _context.SaveChangesAsync();
            return new Producto { ID = producto.ID, NOMBRE = producto.NOMBRE };
        }

    }
}
