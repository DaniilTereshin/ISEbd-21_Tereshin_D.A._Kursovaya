using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    namespace AbstractShopModel
{
    /// <summary>
    /// Клиент школы
    /// </summary>
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        public string TeacherFIO { get; set; }
        public string Mail { get; set; }
        [ForeignKey("TeacherId")]
       public virtual List<Zakaz> Zakazs { get; set; }
        [ForeignKey("TeacherId")]
        public virtual List<MessageInfo> MessageInfos { get; set; }

        [ForeignKey("TeacherId")]
        public virtual List<BonusFineTeacher> BonusFineTeachers { get; set; }
    }
}
