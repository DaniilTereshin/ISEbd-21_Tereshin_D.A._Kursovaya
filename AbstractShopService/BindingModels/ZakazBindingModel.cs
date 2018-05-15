using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AbstractShopService.BindingModels
{
    [DataContract]
    public class ZakazBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int TeacherId { get; set; }
        [DataMember]
        public int SectionId { get; set; }
        [DataMember]
        public int? StudentId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
    }
}
