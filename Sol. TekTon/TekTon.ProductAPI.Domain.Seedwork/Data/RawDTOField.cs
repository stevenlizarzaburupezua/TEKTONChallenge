using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekTon.ProductAPI.Domain.Seedwork.Data
{
    public class RawDTOField
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public RawDTOField(string Name, object Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

    }
}
