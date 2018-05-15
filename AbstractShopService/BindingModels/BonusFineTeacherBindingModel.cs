using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AbstractShopService.BindingModels
{
    [DataContract]
    public class BonusFineTeacherBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int BonusFineId { get; set; }
        [DataMember]
        public int TeacherId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
