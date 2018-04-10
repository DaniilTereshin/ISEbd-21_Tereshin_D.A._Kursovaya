using AbstractShopService.BindingModels;
using AbstractShopService.ViewModels;
using System.Collections.Generic;

namespace AbstractShopService.Interfaces
{
    public interface ITeacherService
    {
        List<TeacherViewModel> GetList();

        TeacherViewModel GetElement(int id);

        void AddElement(TeacherBindingModel model);

        void UpdElement(TeacherBindingModel model);

        void DelElement(int id);
    }
}
