using AbstractShopService.BindingModels;
using AbstractShopService.ViewModels;
using System.Collections.Generic;

namespace AbstractShopService.Interfaces
{
    public interface IMainService
    {
        List<ZakazViewModel> GetList();

        void CreateZakaz(ZakazBindingModel model);

        

        void FinishZakaz(int id);

        void PayZakaz(int id);

        void PutTeacherOnBonusFine(BonusFineTeacherBindingModel model);
    }
}
