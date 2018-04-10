using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopService.ViewModels
{
    public class BonusFineViewModel
    {
        public int Id { get; set; }

        public string BonusFineName { get; set; }

        public List<TeacherBonusFineViewModel> TeacherBonusFines { get; set; }
    }
}
