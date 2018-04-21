using AbstractShopService.BindingModels;
using AbstractShopService.ViewModels;
using System.Collections.Generic;

namespace AbstractShopService.Interfaces
{
    public interface IBonusFineService
    {
        List<BonusFineViewModel> GetList();

        BonusFineViewModel GetElement(int id);

        void AddElement(BonusFineBindingModel model);

        void UpdElement(BonusFineBindingModel model);

        void DelElement(int id);
    }
}
