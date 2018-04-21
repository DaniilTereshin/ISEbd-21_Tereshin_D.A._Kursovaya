﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopModel
{
    public class Entry
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }

        public int SectionId { get; set; }

        public decimal Sum { get; set; }

        public SalaryStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }
    }
}
