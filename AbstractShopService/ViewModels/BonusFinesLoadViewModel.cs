using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbstractShopService.ViewModels
{
    [DataContract]
    public class BonusFinesLoadViewModel
    {
        [DataMember]
        public string BonusFineName { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
        [DataMember]
        public List<BonusFinesPaymentLoadViewModel> Components { get; set; }
    }

    [DataContract]
    public class BonusFinesPaymentLoadViewModel
    {
        [DataMember]
        public string PaymentName { get; set; }

        [DataMember]
        public int Count { get; set; }
}
}
