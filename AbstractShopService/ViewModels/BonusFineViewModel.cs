using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AbstractShopService.ViewModels
{
    [DataContract]
    public class BonusFineViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string BonusFineName { get; set; }
        [DataMember]
        public List<BonusFineTeacherViewModel> BonusFinePayments { get; set; }
    }
}
