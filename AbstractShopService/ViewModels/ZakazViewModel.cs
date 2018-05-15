﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AbstractShopService.ViewModels
{
    [DataContract]
    public class ZakazViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int TeacherId { get; set; }
        [DataMember]
        public string TeacherFIO { get; set; }
        [DataMember]
        public int SectionId { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int? StudentId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string DateCreate { get; set; }
        [DataMember]
        public string DateImplement { get; set; }
    }
}
