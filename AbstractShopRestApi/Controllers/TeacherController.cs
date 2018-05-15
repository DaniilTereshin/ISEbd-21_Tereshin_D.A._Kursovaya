using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using System;
using System.Web.Http;

namespace AbstractShopRestApi.Controllers
{
    public class TeacherController : ApiController
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
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
        public void AddElement(TeacherBindingModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(TeacherBindingModel model)
        {
            _service.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(TeacherBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}