using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CumbriaMD.Domain;
using CumbriaMD.Infrastructure.DataServices;
using CumbriaMD.Infrastructure.ViewModels.CategoryViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CumbriaMD.Web.Controllers
{

    //TODO: Refactor ajax into CategoryController
    public class JsonController : SessionController
    {

        private readonly ICategoryDataService _dataService;

        public JsonController(ICategoryDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            var categories = Session.CreateCriteria<Category>().List<Category>();
            var model = new CreateCategoryViewModel();
            model.Categories = categories
                               .Select(x => new SelectListItem
                               {
                                   Value = x.Id.ToString(),
                                   Text = x.Name
                               });

            model.CategoryOrderListItems = categories
                .Where(x => x.Parent.Id == 5)
                .Select(x => new SelectListItem
                {
                    Value = x.OrderInList.ToString(),
                    Text = x.OrderInList.ToString()
                });
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateCategoryViewModel createCategoryViewModel)
        {


            var model = createCategoryViewModel;
            if (ModelState.IsValid)
            {
                var domainModel = new Category();

                Mapper.Map<CreateCategoryViewModel, Category>(model, domainModel);
                domainModel.Parent = Session.Get<Category>(model.ParentCategoryId);

                _dataService.ArrangeCategoriesOrderOnCreate(domainModel);

                Session.SaveOrUpdate(domainModel);

                return RedirectToAction("Index");

            }
            return View();
        }

        public ActionResult GetTestOrderData(int parentCategoryId)
        {
            var result = Session
                 .QueryOver<Category>()
                 .Where(x => x.Parent.Id == parentCategoryId)
                 .OrderBy(x => x.OrderInList)
                 .Asc
                 .List();


            var jsonObject = result
                .Select(item => new SortableCategoryOrderPartialViewModel
                {
                    Id = item.Id.ToString(),
                    Name = item.Name.ToString(),
                    OrderNumber = item.OrderInList.ToString()
                }).ToList();

            return Json(jsonObject, JsonRequestBehavior.AllowGet);

        }

 
        public ActionResult SetCategoryNameGetDefaultValues(string categoryName)
        {
            var domainModel = new Category();

            var lastOrderInList = Session.CreateCriteria<Category>()
                .List<Category>()
                .Where(x => x.Parent.Id == 1)
                .OrderBy(x => x.OrderInList)
                .Select(x => x.OrderInList)
                .Last();
            lastOrderInList++;
            var category = new CreateCategoryViewModel()
                               {
                                   Name = categoryName,
                                   ParentCategoryId = 1,
                                   IsActive = true,
                                   OrderInList = lastOrderInList
                               };
            Mapper.Map<CreateCategoryViewModel, Category>(category, domainModel);
            Session.SaveOrUpdate(domainModel);

            var result = Session.QueryOver<Category>()
                     .Where(x => x.Name == categoryName)
                     .List();


            var jsonObject = result
                .Select(item => new SortableCategoryOrderPartialViewModel
                {
                    Id = item.Id.ToString(),
                    Name = item.Name.ToString(),
                    OrderNumber = item.OrderInList.ToString()
                }).ToList();

            return Json(jsonObject, JsonRequestBehavior.AllowGet);
            
        }

    }


}
