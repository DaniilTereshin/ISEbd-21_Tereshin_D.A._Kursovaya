using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopService.ViewModels
{
    public class EntryViewModel
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }

        public string TeacherFIO { get; set; }

        public int SectionId { get; set; }

        public string SectionName { get; set; }
        
        public decimal Sum { get; set; }

        public string Status { get; set; }

        public string DateCreate { get; set; }

        public string DateImplement { get; set; }
    }
}
