using System.Runtime.Serialization;

namespace AbstractShopService.ViewModels
{
    [DataContract]
    public class BonusFineTeacherViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int BonusFineId { get; set; }
        [DataMember]
        public int TeacherId { get; set; }
        [DataMember]
        public string TeacherName { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
