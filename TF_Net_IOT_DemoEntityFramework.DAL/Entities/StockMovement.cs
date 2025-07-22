using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Net_IOT_DemoEntityFramework.DAL.Enums;

namespace TF_Net_IOT_DemoEntityFramework.DAL.Entities
{
    public class StockMovement
    {
        public int Id { get; set; }
        public MovementType MovementType { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; } = null!;
    }
}
