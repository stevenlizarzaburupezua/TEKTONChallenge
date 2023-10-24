using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekTon.ProductAPI.Application.Interface;
using TekTon.ProductAPI.Domain.Entities;
using TekTon.ProductAPI.Domain.Interface;
using TekTon.ProductAPI.Domain.Seedwork;
using TekTon.ProductAPI.DTO;
using TekTon.ProductAPI.Infrastructure.CrossCutting.Adapter;

namespace TekTon.ProductAPI.Application.Implementation
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductoService(IProductoRepository productoRepository,
                               IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<ConsultaProductoDTO>> ConsultarProducto(int idProducto)
        {
            return await _productoRepository.ConsultarProducto<ConsultaProductoDTO>(idProducto);
        }

        public async Task<IList<ConsultaProductoDTO>> ConsultarProductos()
        {
            return await _productoRepository.ConsultarProductos<ConsultaProductoDTO>();
        }

        public async Task<RegistrarProductoDTO> RegistrarProducto(RegistrarProductoRequest request)
        {
            return (await _productoRepository.InsertarProducto(request.ProjectedAs<Producto>())).ProjectedAs<RegistrarProductoDTO>();
        }

        public async Task<ModificarProductoDTO> ModificarProducto(ModificarProductoRequest request)
        {
            return (await _productoRepository.ModificarProducto(request.ProjectedAs<Producto>())).ProjectedAs<ModificarProductoDTO>();
        }

        public async Task<EliminarProductoDTO> EliminarProducto(EliminarProductoRequest request)
        {
            return (await _productoRepository.EliminarProducto(request.ProjectedAs<Producto>())).ProjectedAs<EliminarProductoDTO>();
        }

    }
}
