using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
            List<TeacherViewModel> result = source.Teachers
                .Select(rec => new TeacherViewModel
                {
                    Id = rec.Id,
                    TeacherFIO = rec.TeacherFIO
                })
                .ToList();
            return result;
        }

        public TeacherViewModel GetElement(int id)
        {
            Teacher element = source.Teachers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new TeacherViewModel
                {
                    Id = element.Id,
                    TeacherFIO = element.TeacherFIO
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(TeacherBindingModel model)
        {
            Teacher element = source.Teachers.FirstOrDefault(rec => rec.TeacherFIO == model.TeacherFIO);
            if (element != null)
            {
                throw new Exception("Уже есть заказчик с таким ФИО");
            }
            int maxId = source.Teachers.Count > 0 ? source.Teachers.Max(rec => rec.Id) : 0;
            source.Teachers.Add(new Teacher
            {
                Id = maxId + 1,
                TeacherFIO = model.TeacherFIO
            });
        }

        public void UpdElement(TeacherBindingModel model)
        {
            Teacher element = source.Teachers.FirstOrDefault(rec =>
                                    rec.TeacherFIO == model.TeacherFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть заказчик с таким ФИО");
            }
            element = source.Teachers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.TeacherFIO = model.TeacherFIO;
        }

        public void DelElement(int id)
        {
            Teacher element = source.Teachers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Teachers.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}