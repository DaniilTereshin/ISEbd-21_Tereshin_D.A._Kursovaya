using AbstractShopModel;
using System.Collections.Generic;

namespace AbstractShopService
{
    class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Teacher> Teachers { get; set; }

        public List<Payment> Payments { get; set; }

        public List<Student> Students { get; set; }

        public List<Zakaz> Zakazs { get; set; }

        public List<Section> Sections { get; set; }

        public List<SectionPayment> SectionPayments { get; set; }

        public List<BonusFine> BonusFines { get; set; }

        public List<BonusFineTeacher> BonusFinePayments { get; set; }

        private DataListSingleton()
        {
            Teachers = new List<Teacher>();
            Payments = new List<Payment>();
            Students = new List<Student>();
            Zakazs = new List<Zakaz>();
            Sections = new List<Section>();
            SectionPayments = new List<SectionPayment>();
            BonusFines = new List<BonusFine>();
            BonusFinePayments = new List<BonusFineTeacher>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }

            return instance;
        }
    }
}

