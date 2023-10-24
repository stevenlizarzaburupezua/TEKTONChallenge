using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using TekTon.ProductAPI.Infrastructure.CrossCutting.Adapter;

namespace TekTon.ProductAPI.Infrastructure.CrossCutting.AutoMapper
{
    public class AutoMapperTypeAdapterFactory : ITypeAdapterFactory
    {
        public AutoMapperTypeAdapterFactory()
        {
            var tipos = new List<Type>();
            string[] assembliesAsArray = { "TekTon.ProductAPI.Application", "TekTon.ProductAPI.WebAPI", "TekTon.ProductAPI.Infrastructure.CrossCutting" };
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(p => assembliesAsArray.Contains(p.GetName().Name)).ToList();
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.BaseType == typeof(Profile)) tipos.Add(type);
                }
            }

            Mapper.Initialize(cfg =>
            {
                foreach (var tipo in tipos)
                {
                    cfg.AddProfile(Activator.CreateInstance(tipo) as Profile);
                }

            });
        }

        public ITypeAdapter Create()
        {
            return new AutoMapperTypeAdapter();
        }
    }
}
