using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AbstractShopService.BindingModels
{
    [DataContract]
    public class StudentBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string StudentFIO { get; set; }
    }
}
