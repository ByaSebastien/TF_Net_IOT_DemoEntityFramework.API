using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF_Net_IOT_DemoEntityFramework.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Discount { get; set; }
        public User User { get; set; } = null!;
        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
