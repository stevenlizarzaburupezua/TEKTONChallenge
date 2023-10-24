using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TekTon.ProductAPI.Domain.Seedwork.Data;

namespace TekTon.ProductAPI.Domain.Seedwork.Data
{
    public abstract class RawDTO : ISqlRaw
    {
        public static T FromRawData<T>(List<RawDTOField> data) where T : RawDTO
        {   
            var obj = Activator.CreateInstance<T>();
            obj.Populate(data);
            return obj;
        }

        public void Populate(List<RawDTOField> row)
        {
            if (row == null) throw new ArgumentNullException(nameof(row));
            var props = GetType().GetProperties().Where(f => f.GetCustomAttribute<DisplayAttribute>() != null).ToList();
            for (int i = 0; i < row.Count; i++)
            {
                var data = row[i].Value;
                var prop = props.FirstOrDefault(f => f.GetCustomAttribute<DisplayAttribute>().Name == row[i].Name);
                if (prop != null)
                {
                    if (data is DBNull)
                        prop.SetValue(this, null);
                    else
                        prop.SetValue(this, data);
                    continue;
                }

                prop = props.FirstOrDefault(f => f.GetCustomAttribute<DisplayAttribute>().Order == i);
                if (prop != null)
                {
                    if (data is DBNull)
                        prop.SetValue(this, null);
                    else
                        prop.SetValue(this, data);
                    continue;
                }


            }
        }
    }
}
