using AutoMapper;
 
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekTon.ProductAPI.Domain.Entities;
using TekTon.ProductAPI.DTO;

namespace Prosegur.GAP.Infrastructure.CrossCutting.MapperProfile
{
    public class MapperExtensions : Profile
    {
        public MapperExtensions()
        {
            #region USUARIO

            #region DTO => ENT 

            CreateMap<RegistrarProductoRequest, Producto>().AfterMap((src, dst) =>
            {
                dst.NOMBRE = src.NombreProducto;
                dst.FOTO = src.FotoProducto;
                dst.DESCRIPCION = src.DescripcionProducto;
                dst.ID_CATEGORIA = src.IdCategoria;
                dst.STOCK = src.Stock;
                dst.PRECIO = src.PrecioProducto;
                dst.FLG_ACTIVE = src.FlgActive;
                dst.ID_ESTADO = src.IdEstadoProducto;
                dst.FEC_REGISTRO = src.FechaRegistro;
            });

            CreateMap<ModificarProductoRequest, Producto>().AfterMap((src, dst) =>
            {
                dst.ID = src.IdProducto;
                dst.NOMBRE = src.NombreProducto;
                dst.FOTO = src.FotoProducto;
                dst.DESCRIPCION = src.DescripcionProducto;
                dst.ID_CATEGORIA = src.IdCategoria;
                dst.STOCK = src.Stock;
                dst.PRECIO = src.PrecioProducto;
                dst.FLG_ACTIVE = src.FlgActive;
                dst.ID_ESTADO = src.IdEstadoProducto;
                dst.FEC_REGISTRO = src.FechaRegistro;
            });

            CreateMap<EliminarProductoRequest, Producto>().AfterMap((src, dst) =>
            {
                dst.ID = src.Id;
                dst.NOMBRE = src.NombreProducto;
            });

            #endregion

            #region ENT => DTO 

            CreateMap<Producto, RegistrarProductoDTO>().AfterMap((src, dst) =>
            {
                dst.TransactionSuccess = true;
                dst.IdProducto = src.ID;
                dst.NombreProducto = src.NOMBRE;
            });

            CreateMap<Producto, ModificarProductoDTO>().AfterMap((src, dst) =>
            {
                dst.TransactionSuccess = true;
                dst.IdProducto = src.ID;
                dst.NombreProducto = src.NOMBRE;
            });

            CreateMap<Producto, EliminarProductoDTO>().AfterMap((src, dst) =>
            {
                dst.TransactionSuccess = true;
                dst.Id = src.ID;
                dst.NombreProducto = src.NOMBRE;
            });

            #endregion

            #endregion





        }
    }
}
