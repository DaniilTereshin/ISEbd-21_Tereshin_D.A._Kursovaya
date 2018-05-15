using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractShopService.ImplementationsBD
{
    public class StudentServiceBD : IStudentService
    {
        private AbstractDbContext context;

        public StudentServiceBD(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<StudentViewModel> GetList()
        {
            List<StudentViewModel> result = context.Students
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
            Student element = context.Students.FirstOrDefault(rec => rec.Id == id);
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
            Student element = context.Students.FirstOrDefault(rec => rec.StudentFIO == model.StudentFIO);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            context.Students.Add(new Student
            {
                StudentFIO = model.StudentFIO
            });
            context.SaveChanges();
        }

        public void UpdElement(StudentBindingModel model)
        {
            Student element = context.Students.FirstOrDefault(rec =>
                                        rec.StudentFIO == model.StudentFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            element = context.Students.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StudentFIO = model.StudentFIO;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Student element = context.Students.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Students.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
