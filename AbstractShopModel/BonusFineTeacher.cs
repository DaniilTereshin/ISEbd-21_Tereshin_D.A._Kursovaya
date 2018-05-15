using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopModel
{
    public class BonusFineTeacher
    {
        public int Id { get; set; }

        public int BonusFineId { get; set; }

        public int TeacherId { get; set; }

        public int Count { get; set; }
        public virtual BonusFine BonusFine { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
