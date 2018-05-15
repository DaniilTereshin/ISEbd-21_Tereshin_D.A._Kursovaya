using AbstractShopService.BindingModels;
using AbstractShopService.ViewModels;
using System.Collections.Generic;

namespace AbstractShopService.Interfaces
{
    public interface IStudentService
    {
        List<StudentViewModel> GetList();

        StudentViewModel GetElement(int id);

        void AddElement(StudentBindingModel model);

        void UpdElement(StudentBindingModel model);

        void DelElement(int id);
    }
}
