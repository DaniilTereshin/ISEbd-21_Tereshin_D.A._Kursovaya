using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AbstractShopService.ViewModels
{
    [DataContract]
    public class StudentViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string StudentFIO { get; set; }
    }
}