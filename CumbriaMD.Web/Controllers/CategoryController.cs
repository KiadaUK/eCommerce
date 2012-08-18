using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CumbriaMD.Domain;
using CumbriaMD.Infrastructure.DataServices;
using CumbriaMD.Infrastructure.ViewModels.CategoryViewModels;
using NHibernate.Criterion;

namespace CumbriaMD.Web.Controllers
{
    //TODO: Create progressively enhanced category / subcategory module

    public class CategoryController : SessionController
    {
        private readonly ICategoryDataService _dataService;

        public CategoryController(ICategoryDataService dataService)
        {
            _dataService = dataService;
        }

        public ActionResult Index()
        {
            var listOfCategories = Session.CreateCriteria<Category>()
                .List<Category>();

            var orderedListOfCategories = listOfCategories
                .OrderBy(x => x.Parent.Id)
                .ThenBy(x => x.OrderInList)
                .ToList();

            var model = new List<ListCategoriesViewModel>();
            Mapper.Map<IList<Category>, IList<ListCategoriesViewModel>>(orderedListOfCategories, model);

        

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var category = Session.Get<Category>(id);
            var model = new DetailsCategoryViewModel();
           // var subcategories = _dataService.GetAllSubcategories(category.Id);

            Mapper.Map<Category, DetailsCategoryViewModel>(category, model);

            return View(model);
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
            if(ModelState.IsValid)
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

        public ActionResult CreateTest()
        {
            var testOne = new Category
                              {
                                  Name = "TOP LEVEL CATEGORY",
                                  IsActive = true,
                                  OrderInList = 1
                              };
            Session.SaveOrUpdate(testOne);

            var cat = Session.Get<Category>(1);
            cat.Parent = cat;
            Session.SaveOrUpdate(cat);
            Session.Flush();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            return View();
        }

        public ActionResult Delete(int id)
        {
            var category = Session.Get<Category>(id);
            _dataService.ArrangeCategoriesOrderOnDelete(category);
            Session.Delete(category);
            Session.Flush();
            return RedirectToAction("Index");
        }

        public ActionResult GetOrderSelectList(int parentCategoryId)
        {
            var result = Session
                .QueryOver<Category>()
                .Where(x => x.Parent.Id == parentCategoryId)
                .OrderBy(x => x.OrderInList)
                .Asc
                .List();

            var dict = result.ToDictionary(cats => cats.Id.ToString(), cats => cats.OrderInList.ToString());

            return Json(dict, JsonRequestBehavior.AllowGet);
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
    }
}
