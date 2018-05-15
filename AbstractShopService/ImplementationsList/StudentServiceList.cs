using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractShopService.ImplementationsList
{
    public class StudentServiceList : IStudentService
    {
        private DataListSingleton source;

        public StudentServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<StudentViewModel> GetList()
        {
            List<StudentViewModel> result = source.Students
                .Select(rec => new StudentViewModel
                {
                    Id = rec.Id,
                    StudentFIO = rec.StudentFIO
                })
                .ToList();
            return result;
        }

        public StudentViewModel GetElement(int id)
        {
            Student element = source.Students.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new StudentViewModel
                {
                    Id = element.Id,
                    StudentFIO = element.StudentFIO
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(StudentBindingModel model)
        {
            Student element = source.Students.FirstOrDefault(rec => rec.StudentFIO == model.StudentFIO);
            if (element != null)
            {
                throw new Exception("Уже есть преподаватель с таким ФИО");
            }
            int maxId = source.Students.Count > 0 ? source.Students.Max(rec => rec.Id) : 0;
            source.Students.Add(new Student
            {
                Id = maxId + 1,
                StudentFIO = model.StudentFIO
            });
        }

        public void UpdElement(StudentBindingModel model)
        {
            Student element = source.Students.FirstOrDefault(rec =>
                                        rec.StudentFIO == model.StudentFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть преподаватель с таким ФИО");
            }
            element = source.Students.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StudentFIO = model.StudentFIO;
        }

        public void DelElement(int id)
        {
            Student element = source.Students.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Students.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}