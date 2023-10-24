using TekTon.ProductAPI.Infrastructure.CrossCutting.Adapter;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TekTon.ProductAPI.Infrastructure.CrossCutting.AutoMapper
{
    public class AutoMapperTypeAdapter : ITypeAdapter
    {
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
        {
            return Mapper.Map<TTarget>(source);
        }
    }
}
