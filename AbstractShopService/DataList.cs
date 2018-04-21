using AbstractShopModel;
using System.Collections.Generic;

namespace AbstractShopService
{
    class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Teacher> Teachers { get; set; }

        public List<Admin> Admins { get; set; }

        public List<Entry> Entrys { get; set; }

        public List<Section> Sections { get; set; }

        public List<BonusFine> BonusFines { get; set; }

        public List<TeachertBonusFine> TeacherBonusFines { get; set; }

        private DataListSingleton()
        {
            Teachers = new List<Teacher>();
            Admins = new List<Admin>();
            Entrys = new List<Entry>();
            Sections = new List<Section>();
            BonusFines = new List<BonusFine>();
            TeacherBonusFines = new List<TeachertBonusFine>();
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

