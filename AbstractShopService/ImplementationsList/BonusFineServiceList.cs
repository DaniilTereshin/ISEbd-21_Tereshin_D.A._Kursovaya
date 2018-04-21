using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;

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
            List<BonusFineViewModel> result = new List<BonusFineViewModel>();
            for (int i = 0; i < source.BonusFines.Count; ++i)
            {
                List<TeacherBonusFineViewModel> TeacherBonusFines = new List<TeacherBonusFineViewModel>();
                for (int j = 0; j < source.TeacherBonusFines.Count; ++j)
                {
                    if (source.TeacherBonusFines[j].BonusFineId == source.BonusFines[i].Id)
                    {
                        string TeacherFIO = string.Empty;
                        
                        TeacherBonusFines.Add(new TeacherBonusFineViewModel
                        {
                            Id = source.TeacherBonusFines[j].Id,
                            BonusFineId = source.TeacherBonusFines[j].BonusFineId,
                            TeacherId = source.TeacherBonusFines[j].TeacherId,
                            TeacherName = TeacherFIO
                        });
                    }
                }
                result.Add(new BonusFineViewModel
                {
                    Id = source.BonusFines[i].Id,
                    BonusFineName = source.BonusFines[i].BonusFineName,
                    TeacherBonusFines = TeacherBonusFines
                });
            }
            return result;
        }

        public BonusFineViewModel GetElement(int id)
        {
            for (int i = 0; i < source.BonusFines.Count; ++i)
            {
                List<TeacherBonusFineViewModel> TeacherBonusFines = new List<TeacherBonusFineViewModel>();
                for (int j = 0; j < source.TeacherBonusFines.Count; ++j)
                {
                    if (source.TeacherBonusFines[j].BonusFineId == source.BonusFines[i].Id)
                    {
                        string TeacherFIO = string.Empty;
                       
                        TeacherBonusFines.Add(new TeacherBonusFineViewModel
                        {
                            Id = source.TeacherBonusFines[j].Id,
                            BonusFineId = source.TeacherBonusFines[j].BonusFineId,
                            TeacherId = source.TeacherBonusFines[j].TeacherId,
                            TeacherName = TeacherFIO
                        });
                    }
                }
                if (source.BonusFines[i].Id == id)
                {
                    return new BonusFineViewModel
                    {
                        Id = source.BonusFines[i].Id,
                        BonusFineName = source.BonusFines[i].BonusFineName,
                        TeacherBonusFines = TeacherBonusFines
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(BonusFineBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.BonusFines.Count; ++i)
            {
                if (source.BonusFines[i].Id > maxId)
                {
                    maxId = source.BonusFines[i].Id;
                }
                if (source.BonusFines[i].BonusFineName == model.BonusFineName)
                {
                    throw new Exception("Уже есть бонус или штраф с таким названием");
                }
            }
            source.BonusFines.Add(new BonusFine
            {
                Id = maxId + 1,
                BonusFineName = model.BonusFineName
            });
        }

        public void UpdElement(BonusFineBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.BonusFines.Count; ++i)
            {
                if (source.BonusFines[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.BonusFines[i].BonusFineName == model.BonusFineName &&
                    source.BonusFines[i].Id != model.Id)
                {
                    throw new Exception("Уже есть бонус или штраф с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.BonusFines[index].BonusFineName = model.BonusFineName;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.TeacherBonusFines.Count; ++i)
            {
                if (source.TeacherBonusFines[i].BonusFineId == id)
                {
                    source.TeacherBonusFines.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.BonusFines.Count; ++i)
            {
                if (source.BonusFines[i].Id == id)
                {
                    source.BonusFines.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
