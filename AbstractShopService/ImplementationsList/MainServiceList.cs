using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractShopService.ImplementationsList
{
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;

        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<EntryViewModel> GetList()
        {
            List<EntryViewModel> result = new List<EntryViewModel>();
            for (int i = 0; i < source.Entrys.Count; ++i)
            {
                string TeacherFIO = string.Empty;
                for (int j = 0; j < source.Teachers.Count; ++j)
                {
                    if (source.Teachers[j].Id == source.Entrys[i].TeacherId)
                    {
                        TeacherFIO = source.Teachers[j].TeacherFIO;
                        break;
                    }
                }
                string SectionTip = string.Empty;
                string SectionPrepod = string.Empty;
                for (int j = 0; j < source.Sections.Count; ++j)
                {
                    if (source.Sections[j].Id == source.Entrys[i].SectionId)
                    {
                        SectionTip = source.Sections[j].SectionName;
                        break;
                    }
                }
               
                result.Add(new EntryViewModel
                {
                    Id = source.Entrys[i].Id,
                    TeacherId = source.Entrys[i].TeacherId,
                    TeacherFIO = TeacherFIO,
                    SectionId = source.Entrys[i].SectionId,
                    SectionName = SectionTip,
                    Sum = source.Entrys[i].Sum,
                    DateCreate = source.Entrys[i].DateCreate.ToLongDateString(),
                    DateImplement = source.Entrys[i].DateImplement?.ToLongDateString(),
                    Status = source.Entrys[i].Status.ToString()
                });
            }
            return result;
        }

        public void CreateEntry(EntryBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Entrys.Count; ++i)
            {
                if (source.Entrys[i].Id > maxId)
                {
                    maxId = source.Teachers[i].Id;
                }
            }
            source.Entrys.Add(new Entry
            {
                Id = maxId + 1,
                TeacherId = model.TeacherId,
                SectionId = model.SectionId,
                DateCreate = DateTime.Now,
               
                Sum = model.Sum,
                Status = SalaryStatus.Невыдана
            });
        }

       

        public void FinishEntry(int id)
        {
            int index = -1;
            for (int i = 0; i < source.Entrys.Count; ++i)
            {
                if (source.Teachers[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Entrys[index].Status = SalaryStatus.Выдана;
        }

        

        public void PutTeacherOnBonusFine(TeacherBonusFineBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.TeacherBonusFines.Count; ++i)
            {
                if (source.TeacherBonusFines[i].BonusFineId == model.BonusFineId &&
                    source.TeacherBonusFines[i].TeacherId == model.TeacherId)
                {
                    source.TeacherBonusFines[i].Sum += model.Sum;
                    return;
                }
                if (source.TeacherBonusFines[i].Id > maxId)
                {
                    maxId = source.TeacherBonusFines[i].Id;
                }
            }
            source.TeacherBonusFines.Add(new TeachertBonusFine
            {
                Id = ++maxId,
                BonusFineId = model.BonusFineId,
                TeacherId = model.TeacherId,
               Sum = model.Sum
            });
        }
    }
}
