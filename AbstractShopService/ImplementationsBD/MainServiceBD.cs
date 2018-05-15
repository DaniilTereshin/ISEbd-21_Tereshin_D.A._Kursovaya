using AbstractShopModel;
using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using AbstractShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Data.Entity;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace AbstractShopService.ImplementationsBD
{
    public class MainServiceBD : IMainService
    {
        private AbstractDbContext context;

        public MainServiceBD(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<ZakazViewModel> GetList()
        {
            List<ZakazViewModel> result = context.Zakazs
                .Select(rec => new ZakazViewModel
                {
                    Id = rec.Id,
                    TeacherId = rec.TeacherId,
                    SectionId = rec.SectionId,
                    StudentId = rec.StudentId,
                    DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
                                SqlFunctions.DateName("mm", rec.DateCreate) + " " +
                                SqlFunctions.DateName("yyyy", rec.DateCreate),
                    DateImplement = rec.DateImplement == null ? "" :
                                        SqlFunctions.DateName("dd", rec.DateImplement.Value) + " " +
                                        SqlFunctions.DateName("mm", rec.DateImplement.Value) + " " +
                                        SqlFunctions.DateName("yyyy", rec.DateImplement.Value),
                    Status = rec.Status.ToString(),
                    Count = rec.Count,
                    Sum = rec.Sum,
                    TeacherFIO = rec.Teacher.TeacherFIO,
                    SectionName = rec.Section.SectionName
                })
                .ToList();
            return result;
        }

        public void CreateZakaz(ZakazBindingModel model)
        {
            var Zakaz = new Zakaz
            {
                TeacherId = model.TeacherId,
                SectionId = model.SectionId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = PaymentStatus.Назначен_кружок
            };
            context.Zakazs.Add(Zakaz);
            context.SaveChanges();

            var Teacher = context.Teachers.FirstOrDefault(x => x.Id == model.TeacherId);
            SendEmail(Teacher.Mail, "Оповещение по заявкам",
                string.Format("Заявка №{0} от {1} создана успешно", Zakaz.Id,
                Zakaz.DateCreate.ToShortDateString()));
        }

       

        public void FinishZakaz(int id)
        {
            Zakaz element = context.Zakazs.Include(rec => rec.Teacher).FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = PaymentStatus.Задолженность;
            context.SaveChanges();
            SendEmail(element.Teacher.Mail, "Оповещение по заявкам",
                string.Format("Заявка №{0} от {1} передана на оплату", element.Id,
                element.DateCreate.ToShortDateString()));
        }

        public void PayZakaz(int id)
        {
            Zakaz element = context.Zakazs.Include(rec => rec.Teacher).FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = PaymentStatus.Оплачен;
            context.SaveChanges();
            SendEmail(element.Teacher.Mail, "Оповещение по заявкам",
                string.Format("Заявка №{0} от {1} оплачена успешно", element.Id, element.DateCreate.ToShortDateString()));
        }

        public void PutTeacherOnBonusFine(BonusFineTeacherBindingModel model)
        {
            BonusFineTeacher element = context.BonusFinePayments
                                                .FirstOrDefault(rec => rec.BonusFineId == model.BonusFineId &&
                                                                    rec.TeacherId == model.TeacherId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.BonusFinePayments.Add(new BonusFineTeacher
                {
                    BonusFineId = model.BonusFineId,
                    TeacherId = model.TeacherId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }

        private void SendEmail(string mailAddress, string subject, string text)
        {
            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpTeacher = null;

            try
            {
                objMailMessage.From = new MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                objMailMessage.To.Add(new MailAddress(mailAddress));
                objMailMessage.Subject = subject;
                objMailMessage.Body = text;
                objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;

                objSmtpTeacher = new SmtpClient("smtp.gmail.com", 587);
                objSmtpTeacher.UseDefaultCredentials = false;
                objSmtpTeacher.EnableSsl = true;
                objSmtpTeacher.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpTeacher.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["MailLogin"],
                    ConfigurationManager.AppSettings["MailPassword"]);

                objSmtpTeacher.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMailMessage = null;
                objSmtpTeacher = null;
            }
        }
    }
}