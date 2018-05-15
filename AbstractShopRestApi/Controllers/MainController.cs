﻿using AbstractShopService.BindingModels;
using AbstractShopService.Interfaces;
using System;
using System.Web.Http;

namespace AbstractShopRestApi.Controllers
{
    public class MainController : ApiController
    {
        private readonly IMainService _service;

        public MainController(IMainService service)
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

        [HttpPost]
        public void CreateZakaz(ZakazBindingModel model)
        {
            _service.CreateZakaz(model);
        }


        [HttpPost]
        public void FinishZakaz(ZakazBindingModel model)
        {
            _service.FinishZakaz(model.Id);
        }

        [HttpPost]
        public void PayZakaz(ZakazBindingModel model)
        {
            _service.PayZakaz(model.Id);
        }

        [HttpPost]
        public void PutTeacherOnBonusFine(BonusFineTeacherBindingModel model)
        {
            _service.PutTeacherOnBonusFine(model);
        }
    }
}