using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using System;
using System.Web.Http;

namespace AbstractShopRestApi.Controllers
{
    public class BonusFineController : ApiController
    {
        private readonly IBonusFineService _service;

        public BonusFineController(IBonusFineService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(BonusFineBindingModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(BonusFineBindingModel model)
        {
            _service.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(BonusFineBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}