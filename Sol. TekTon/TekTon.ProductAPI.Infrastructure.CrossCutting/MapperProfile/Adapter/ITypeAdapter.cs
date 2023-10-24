using System;
using System.Collections.Generic;
using System.Text;

namespace TekTon.ProductAPI.Infrastructure.CrossCutting.Adapter
{
    public interface ITypeAdapter
    {
        TTarget Adapt<TSource, TTarget>(TSource source)
            where TTarget : class, new()
            where TSource : class;

        TTarget Adapt<TTarget>(object source)
            where TTarget : class, new();
    }
}
