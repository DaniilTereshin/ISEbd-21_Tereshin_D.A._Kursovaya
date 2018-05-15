using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopModel
{
    public class Zakaz
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }

        public int SectionId { get; set; }

        public int? StudentId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public PaymentStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }
        public virtual Teacher Teacher { get; set; }

        public virtual Section Section { get; set; }

        public virtual Student Student { get; set; }
    }
}
