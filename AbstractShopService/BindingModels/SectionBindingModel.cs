﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AbstractShopService.BindingModels
{
    [DataContract]
    public class SectionBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<SectionPaymentBindingModel> SectionPayments { get; set; }
    }
}
