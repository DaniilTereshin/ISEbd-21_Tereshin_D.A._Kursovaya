using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractShopService.ImplementationsBD
{
    public class TeacherServiceBD : ITeacherService
    {
        private AbstractDbContext context;

        public TeacherServiceBD(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<TeacherViewModel> GetList()
        {
            List<TeacherViewModel> result = context.Teachers
                .Select(rec => new TeacherViewModel
                {
                    Id = rec.Id,
                    TeacherFIO = rec.TeacherFIO,
                    Mail = rec.Mail
                })
                .ToList();
            return result;
        }

        public TeacherViewModel GetElement(int id)
        {
            Teacher element = context.Teachers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new TeacherViewModel
                {
                    Id = element.Id,
                    TeacherFIO = element.TeacherFIO,
                    Mail = element.Mail,
                    Messages = context.MessageInfos
                            .Where(recM => recM.TeacherId == element.Id)
                            .Select(recM => new MessageInfoViewModel
                            {
                                MessageId = recM.MessageId,
                                DateDelivery = recM.DateDelivery,
                                Subject = recM.Subject,
                                Body = recM.Body
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(TeacherBindingModel model)
        {
            Teacher element = context.Teachers.FirstOrDefault(rec => rec.TeacherFIO == model.TeacherFIO);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            context.Teachers.Add(new Teacher
            {
                TeacherFIO = model.TeacherFIO,
                Mail = model.Mail
            });
            context.SaveChanges();
        }

        public void UpdElement(TeacherBindingModel model)
        {
            Teacher element = context.Teachers.FirstOrDefault(rec =>
                                    rec.TeacherFIO == model.TeacherFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Teachers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.TeacherFIO = model.TeacherFIO;
            element.Mail = model.Mail;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Teacher element = context.Teachers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Teachers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}