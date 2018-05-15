using System.Runtime.Serialization;

namespace AbstractShopService.ViewModels
{
    [DataContract]
    public class TeacherZakazsModel
    {
        [DataMember]
        public string TeacherName { get; set; }
        [DataMember]
        public string DateCreate { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
