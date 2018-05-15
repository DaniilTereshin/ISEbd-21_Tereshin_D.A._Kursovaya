using AbstractShopModel;
using System;
using System.Data.Entity;

namespace AbstractShopService
{

    public class AbstractDbContext : DbContext
    {
        public AbstractDbContext() : base("AbstractDatabase26")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Zakaz> Zakazs { get; set; }

        public virtual DbSet<Section> Sections { get; set; }

        public virtual DbSet<SectionPayment> SectionPayments { get; set; }

        public virtual DbSet<BonusFine> BonusFines { get; set; }

        public virtual DbSet<BonusFineTeacher> BonusFinePayments { get; set; }

        public virtual DbSet<MessageInfo> MessageInfos { get; set; }
        /// <summary>
        /// Перегружаем метод созранения изменений. Если возникла ошибка - очищаем все изменения
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception)
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Deleted:
                            entry.Reload();
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                    }
                }
                throw;
            }
        }
    }
}