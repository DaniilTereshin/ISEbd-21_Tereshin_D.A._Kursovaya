using AbstractShopService.BindingModels;
using AbstractShopService.ViewModels;
using System.Collections.Generic;

namespace AbstractShopService.Interfaces
{
    public interface IReportService
    {
        void SaveSectionPrice(ReportBindingModel model);

        List<BonusFinesLoadViewModel> GetBonusFinesLoad();

        void SaveBonusFinesLoad(ReportBindingModel model);

        List<TeacherZakazsModel> GetTeacherZakazs(ReportBindingModel model);

        void SaveTeacherZakazs(ReportBindingModel model);
    }
}
