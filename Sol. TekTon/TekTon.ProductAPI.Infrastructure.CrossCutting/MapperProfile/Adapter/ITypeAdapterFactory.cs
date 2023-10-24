using System;
using System.Collections.Generic;
using System.Text;

namespace TekTon.ProductAPI.Infrastructure.CrossCutting.Adapter
{
    public interface ITypeAdapterFactory
    {
        ITypeAdapter Create();
    }
}
