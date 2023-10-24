using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekTon.ProductAPI.Domain.Seedwork;

namespace TekTon.ProductAPI.Domain.Entities
{
    public class Estado : Entity
    {
        [Key]
        public int ID { get; set; }

        public string NOMBRE { get; set; }

        public string DESCRIPCION { get; set; }

        public DateTime FEC_REGISTRO { get; set; }
    }
}
