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
    /// <summary>
    /// бонусы, штрафы и блокировка
    /// </summary>
    public class BonusFine
    {
        public int Id { get; set; }

        [Required]
        public string BonusFineName { get; set; }
        [ForeignKey("BonusFineId")]
        public virtual List<BonusFineTeacher> BonusFinePayments { get; set; }
    }
}