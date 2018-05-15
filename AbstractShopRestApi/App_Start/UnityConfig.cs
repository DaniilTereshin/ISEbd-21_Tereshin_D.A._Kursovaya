using AbstractShopService;
using AbstractShopService.ImplementationsBD;
using AbstractShopService.Interfaces;
using System;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;

namespace MotorZavodRestApi
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<ISectionRepository, SectionRepository>();
            container.RegisterType<DbContext, AbstractDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<ITeacherService, TeacherServiceBD>(new HierarchicalLifetimeManager());
            container.RegisterType<IPaymentService, PaymentServiceBD>(new HierarchicalLifetimeManager());
            container.RegisterType<IStudentService, StudentServiceBD>(new HierarchicalLifetimeManager());
            container.RegisterType<ISectionService, SectionServiceBD>(new HierarchicalLifetimeManager());
            container.RegisterType<IBonusFineService, BonusFineServiceBD>(new HierarchicalLifetimeManager());
            container.RegisterType<IMainService, MainServiceBD>(new HierarchicalLifetimeManager());
            container.RegisterType<IReportService, ReportServiceBD>(new HierarchicalLifetimeManager());
            container.RegisterType<IMessageInfoService, MessageInfoServiceBD>(new HierarchicalLifetimeManager());
        }
    }
}