using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekTon.ProductAPI.Domain.Seedwork;

namespace TekTon.ProductAPI.Domain.Entities
{
    public class Producto : Entity
    {
        [Key]
        public int ID { get; set; }

        public string? NOMBRE { get; set; }

        public byte[]? FOTO { get; set; }

        public string? DESCRIPCION { get; set; }

        public int ID_CATEGORIA { get; set; }

        public int STOCK { get; set; }

        public decimal PRECIO { get; set; }

        public bool FLG_ACTIVE { get; set; }

        public int ID_ESTADO { get; set; }

        public DateTime FEC_REGISTRO { get; set; }

    }
}
