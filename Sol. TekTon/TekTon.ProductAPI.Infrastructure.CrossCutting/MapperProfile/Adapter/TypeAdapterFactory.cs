using System;
using System.Collections.Generic;
using System.Text;

namespace TekTon.ProductAPI.Infrastructure.CrossCutting.Adapter
{
    public static class TypeAdapterFactory
    {
        static ITypeAdapterFactory typeAdapterFactory;

        public static void SetCurrent(ITypeAdapterFactory typeAdapterFactory)
        {
            TypeAdapterFactory.typeAdapterFactory = typeAdapterFactory;
        }

        public static ITypeAdapter CreateAdapter()
        {
            return typeAdapterFactory.Create();
        }
    }
}
