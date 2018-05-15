using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractShopModel
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string StudentFIO { get; set; }
        [ForeignKey("StudentId")]
        public virtual List<Zakaz> Zakazs { get; set; }
    }
}
