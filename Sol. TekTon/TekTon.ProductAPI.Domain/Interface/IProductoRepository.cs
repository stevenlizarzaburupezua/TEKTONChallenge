using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekTon.ProductAPI.Domain.Entities;
using TekTon.ProductAPI.Domain.Seedwork;
using TekTon.ProductAPI.Domain.Seedwork.Data;

namespace TekTon.ProductAPI.Domain.Interface
{
    public interface IProductoRepository
    {
        Task<IList<T>> ConsultarProducto<T>(int idProducto) where T : RawDTO;

        Task<IList<T>> ConsultarProductos<T>() where T : RawDTO;

        Task<Producto> InsertarProducto(Producto usuario);

        Task<Producto> ModificarProducto(Producto usuario);

        Task<Producto> EliminarProducto(Producto usuario);
    }
}
