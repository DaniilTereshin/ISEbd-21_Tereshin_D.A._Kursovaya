using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using System;
using System.Web.Http;

namespace AbstractShopRestApi.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetBonusFinesLoad()
        {
            var list = _service.GetBonusFinesLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult GetTeacherZakazs(ReportBindingModel model)
        {
            var list = _service.GetTeacherZakazs(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public void SaveSectionPrice(ReportBindingModel model)
        {
            _service.SaveSectionPrice(model);
        }

        [HttpPost]
        public void SaveBonusFinesLoad(ReportBindingModel model)
        {
            _service.SaveBonusFinesLoad(model);
        }

        [HttpPost]
        public void SaveTeacherZakazs(ReportBindingModel model)
        {
            _service.SaveTeacherZakazs(model);
        }
    }
}