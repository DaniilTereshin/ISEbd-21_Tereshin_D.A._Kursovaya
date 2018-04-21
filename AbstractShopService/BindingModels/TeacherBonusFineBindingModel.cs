using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopService.BindingModels
{
    public class TeacherBonusFineBindingModel
    {
        public int Id { get; set; }

        public int BonusFineId { get; set; }

        public int TeacherId { get; set; }

        public int Sum { get; set; }
    }
}
