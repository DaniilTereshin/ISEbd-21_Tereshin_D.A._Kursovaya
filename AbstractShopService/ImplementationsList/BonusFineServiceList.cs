using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractShopService.ImplementationsList
{
    public class BonusFineServiceList : IBonusFineService
    {
        private DataListSingleton source;

        public BonusFineServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<BonusFineViewModel> GetList()
        {
            List<BonusFineViewModel> result = source.BonusFines
                .Select(rec => new BonusFineViewModel
                {
                    Id = rec.Id,
                    BonusFineName = rec.BonusFineName,
                    BonusFinePayments = source.BonusFinePayments
                            .Where(recPC => recPC.BonusFineId == rec.Id)
                            .Select(recPC => new BonusFineTeacherViewModel
                            {
                                Id = recPC.Id,
                                BonusFineId = recPC.BonusFineId,
                                TeacherId = recPC.TeacherId,
                                TeacherName = source.Payments
                                    .FirstOrDefault(recC => recC.Id == recPC.TeacherId)?.PaymentName,
                                Count = recPC.Count
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public BonusFineViewModel GetElement(int id)
        {
            BonusFine element = source.BonusFines.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new BonusFineViewModel
                {
                    Id = element.Id,
                    BonusFineName = element.BonusFineName,
                    BonusFinePayments = source.BonusFinePayments
                            .Where(recPC => recPC.BonusFineId == element.Id)
                            .Select(recPC => new BonusFineTeacherViewModel
                            {
                                Id = recPC.Id,
                                BonusFineId = recPC.BonusFineId,
                                TeacherId = recPC.TeacherId,
                                TeacherName = source.Payments
                                    .FirstOrDefault(recC => recC.Id == recPC.TeacherId)?.PaymentName,
                                Count = recPC.Count
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(BonusFineBindingModel model)
        {
            BonusFine element = source.BonusFines.FirstOrDefault(rec => rec.BonusFineName == model.BonusFineName);
            if (element != null)
            {
                throw new Exception("Уже есть Бонус, Штраф или Блокировка с таким названием");
            }
            int maxId = source.BonusFines.Count > 0 ? source.BonusFines.Max(rec => rec.Id) : 0;
            source.BonusFines.Add(new BonusFine
            {
                Id = maxId + 1,
                BonusFineName = model.BonusFineName
            });
        }

        public void UpdElement(BonusFineBindingModel model)
        {
            BonusFine element = source.BonusFines.FirstOrDefault(rec =>
                                        rec.BonusFineName == model.BonusFineName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть Бонус, Штраф или Блокировка с таким названием");
            }
            element = source.BonusFines.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.BonusFineName = model.BonusFineName;
        }

        public void DelElement(int id)
        {
            BonusFine element = source.BonusFines.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // при удалении удаляем все записи о компонентах на удаляемом складе
                source.BonusFinePayments.RemoveAll(rec => rec.BonusFineId == id);
                source.BonusFines.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}