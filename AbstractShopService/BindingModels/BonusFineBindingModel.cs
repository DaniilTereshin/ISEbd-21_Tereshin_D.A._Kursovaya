using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AbstractShopService.BindingModels
{
    [DataContract]
    public class BonusFineBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string BonusFineName { get; set; }
    }
}
