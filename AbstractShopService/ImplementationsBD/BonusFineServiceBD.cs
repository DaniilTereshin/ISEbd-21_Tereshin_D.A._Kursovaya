using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractShopService.ImplementationsBD
{
    public class BonusFineServiceBD : IBonusFineService
    {
        private AbstractDbContext context;

        public BonusFineServiceBD(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<BonusFineViewModel> GetList()
        {
            List<BonusFineViewModel> result = context.BonusFines
                .Select(rec => new BonusFineViewModel
                {
                    Id = rec.Id,
                    BonusFineName = rec.BonusFineName,
                    BonusFinePayments = context.BonusFinePayments
                            .Where(recPC => recPC.BonusFineId == rec.Id)
                            .Select(recPC => new BonusFineTeacherViewModel
                            {
                                Id = recPC.Id,
                                BonusFineId = recPC.BonusFineId,
                                TeacherId = recPC.TeacherId,
                                TeacherName = recPC.Teacher.TeacherFIO,
                                Count = recPC.Count
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public BonusFineViewModel GetElement(int id)
        {
            BonusFine element = context.BonusFines.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new BonusFineViewModel
                {
                    Id = element.Id,
                    BonusFineName = element.BonusFineName,
                    BonusFinePayments = context.BonusFinePayments
                            .Where(recPC => recPC.BonusFineId == element.Id)
                            .Select(recPC => new BonusFineTeacherViewModel
                            {
                                Id = recPC.Id,
                                BonusFineId = recPC.BonusFineId,
                                TeacherId = recPC.TeacherId,
                                TeacherName = recPC.Teacher.TeacherFIO,
                                Count = recPC.Count
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(BonusFineBindingModel model)
        {
            BonusFine element = context.BonusFines.FirstOrDefault(rec => rec.BonusFineName == model.BonusFineName);
            if (element != null)
            {
                throw new Exception("Уже есть Бонус, Штраф или Блокировка с таким названием");
            }
            context.BonusFines.Add(new BonusFine
            {
                BonusFineName = model.BonusFineName
            });
            context.SaveChanges();
        }

        public void UpdElement(BonusFineBindingModel model)
        {
            BonusFine element = context.BonusFines.FirstOrDefault(rec =>
                                        rec.BonusFineName == model.BonusFineName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть Бонус, Штраф или Блокировка с таким названием");
            }
            element = context.BonusFines.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.BonusFineName = model.BonusFineName;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    BonusFine element = context.BonusFines.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        // при удалении удаляем все записи о компонентах на удаляемом складе
                        context.BonusFinePayments.RemoveRange(
                                            context.BonusFinePayments.Where(rec => rec.BonusFineId == id));
                        context.BonusFines.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}