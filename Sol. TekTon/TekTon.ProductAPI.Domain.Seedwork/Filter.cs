using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekTon.ProductAPI.Domain.Seedwork
{
    public class Filter<T>
    {
        public Pager Pagination { get; set; }

        public List<Func<T, bool>> Conditions { get; set; }

        public List<Order<T>> OrderBy { get; set; }
    }

    public enum OrderMode
    {
        DESC = 0,
        ASC = 1
    }
    public class Order<T>
    {
        public OrderMode Mode { get; set; } = OrderMode.ASC;
        public Func<T, object> OrderProperty { get; set; }
    }
}
