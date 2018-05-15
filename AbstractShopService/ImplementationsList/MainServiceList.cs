using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractShopService.ImplementationsList
{
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;

        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<ZakazViewModel> GetList()
        {
            List<ZakazViewModel> result = source.Zakazs
                .Select(rec => new ZakazViewModel
                {
                    Id = rec.Id,
                    TeacherId = rec.TeacherId,
                    SectionId = rec.SectionId,
                    StudentId = rec.StudentId,
                    DateCreate = rec.DateCreate.ToLongDateString(),
                    DateImplement = rec.DateImplement?.ToLongDateString(),
                    Status = rec.Status.ToString(),
                    Count = rec.Count,
                    Sum = rec.Sum,
                    TeacherFIO = source.Teachers
                                    .FirstOrDefault(recC => recC.Id == rec.TeacherId)?.TeacherFIO,
                    SectionName = source.Sections
                                    .FirstOrDefault(recP => recP.Id == rec.SectionId)?.SectionName,
                })
                .ToList();
            return result;
        }

        public void CreateZakaz(ZakazBindingModel model)
        {
            int maxId = source.Zakazs.Count > 0 ? source.Zakazs.Max(rec => rec.Id) : 0;
            source.Zakazs.Add(new Zakaz
            {
                Id = maxId + 1,
                TeacherId = model.TeacherId,
                SectionId = model.SectionId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = PaymentStatus.Назначен_кружок
            });
        }

       
        public void FinishZakaz(int id)
        {
            Zakaz element = source.Zakazs.FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = PaymentStatus.Задолженность;
        }

        public void PayZakaz(int id)
        {
            Zakaz element = source.Zakazs.FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = PaymentStatus.Оплачен;
        }

        public void PutTeacherOnBonusFine(BonusFineTeacherBindingModel model)
        {
            BonusFineTeacher element = source.BonusFinePayments
                                                .FirstOrDefault(rec => rec.BonusFineId == model.BonusFineId &&
                                                                    rec.TeacherId == model.TeacherId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.BonusFinePayments.Count > 0 ? source.BonusFinePayments.Max(rec => rec.Id) : 0;
                source.BonusFinePayments.Add(new BonusFineTeacher
                {
                    Id = ++maxId,
                    BonusFineId = model.BonusFineId,
                    TeacherId = model.TeacherId,
                    Count = model.Count
                });
            }
        }
    }
}