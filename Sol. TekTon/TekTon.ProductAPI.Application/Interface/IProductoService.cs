using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekTon.ProductAPI.DTO;

namespace TekTon.ProductAPI.Application.Interface
{
    public interface IProductoService 
    {
        Task<IList<ConsultaProductoDTO>> ConsultarProducto(int idProducto);

        Task<IList<ConsultaProductoDTO>> ConsultarProductos();

        Task<RegistrarProductoDTO> RegistrarProducto(RegistrarProductoRequest request);

        Task<ModificarProductoDTO> ModificarProducto(ModificarProductoRequest request);

        Task<EliminarProductoDTO> EliminarProducto(EliminarProductoRequest request);
    }
}
