using AbstractShopService.ImplementationsList;
using AbstractShopService.Interfaces;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace AbstractShopView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
            //Application.Run(container.Resolve<FormAdmin>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ITeacherService, TeacherServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAdminService, AdminServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISectionService, SectionServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IBonusFineService, BonusFineServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceList>(new HierarchicalLifetimeManager());
            
            return currentContainer;
        }
    }
}
