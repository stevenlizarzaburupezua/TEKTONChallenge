using System.ComponentModel.DataAnnotations;
using TekTon.ProductAPI.Domain.Seedwork;

namespace TekTon.ProductAPI.Domain.Entities
{
    public class Categoria : Entity
    {
        [Key]
        public int ID { get; set; }

        public string NOMBRE { get; set; }

        public string DESCRIPCION { get; set; }

        public bool FLG_ACTIVE { get; set; }

        public DateTime FEC_REGISTRO { get; set; }
    }
}
