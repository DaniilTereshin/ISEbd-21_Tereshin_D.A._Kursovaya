 using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractShopService.ImplementationsList
{
    public class TeacherServiceList : ITeacherService
    {
        private DataListSingleton source;

        public TeacherServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<TeacherViewModel> GetList()
        {
            List<TeacherViewModel> result = new List<TeacherViewModel>();
            for (int i = 0; i < source.Teachers.Count; ++i)
            {
                result.Add(new TeacherViewModel
                {
                    Id = source.Teachers[i].Id,
                    TeacherFIO = source.Teachers[i].TeacherFIO
                });
            }
            return result;
        }

        public TeacherViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Teachers.Count; ++i)
            {
                if (source.Teachers[i].Id == id)
                {
                    return new TeacherViewModel
                    {
                        Id = source.Teachers[i].Id,
                        TeacherFIO = source.Teachers[i].TeacherFIO
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(TeacherBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Teachers.Count; ++i)
            {
                if (source.Teachers[i].Id > maxId)
                {
                    maxId = source.Teachers[i].Id;
                }
                if (source.Teachers[i].TeacherFIO == model.TeacherFIO)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            source.Teachers.Add(new Teacher
            {
                Id = maxId + 1,
                TeacherFIO = model.TeacherFIO
            });
        }

        public void UpdElement(TeacherBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Teachers.Count; ++i)
            {
                if (source.Teachers[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Teachers[i].TeacherFIO == model.TeacherFIO &&
                    source.Teachers[i].Id != model.Id)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Teachers[index].TeacherFIO = model.TeacherFIO;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Teachers.Count; ++i)
            {
                if (source.Teachers[i].Id == id)
                {
                    source.Teachers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
