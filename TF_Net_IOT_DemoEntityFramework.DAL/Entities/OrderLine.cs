using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF_Net_IOT_DemoEntityFramework.DAL.Entities
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; } = null!;
        public Order Order { get; set; } = null!;
    }
}
