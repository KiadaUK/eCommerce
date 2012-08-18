using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CumbriaMD.Domain;
using CumbriaMD.Infrastructure.AppServices;
using CumbriaMD.Infrastructure.ViewModels.BrandViewModels;
using CumbriaMD.Infrastructure.ViewModels.ImageViewModels;
using CumbriaMD.Web.Filters;
using NHibernate;
using AutoMapper;
using eDetectors.Domain;

namespace CumbriaMD.Web.Controllers
{
    public class BrandController : SessionController
    {
        private readonly IImageHandler _imageHandler;

        public BrandController(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
        }

        public ActionResult Index()
        {
            var listOfBrands = Session.CreateCriteria<Brand>().List<Brand>();
            var model = new List<ListBrandsViewModel>();

            Mapper.Map<IList<Brand>, IList<ListBrandsViewModel>>(listOfBrands, model);

            return View(model);
        }


        public ActionResult Details(int id)
        {
            
            var brand = Session.Get<Brand>(id);
            var model = new DetailsBrandViewModel();

            Mapper.Map<Brand, DetailsBrandViewModel>(brand, model);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateBrandViewModel();
            model.IsActive = true;
           
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateBrandViewModel createBrandViewModel)
        {
            if (ModelState.IsValid)
            {
                var rawFileUpload = createBrandViewModel.File.File;
                var uploadedImage = _imageHandler.BuildImage(rawFileUpload, createBrandViewModel.Name.ToLower());
                var domainModel = new Brand();
                Mapper.Map<CreateBrandViewModel, Brand>(createBrandViewModel, domainModel);

                uploadedImage.AddedAt = DateTime.Now;
                uploadedImage.UpdatedAt = DateTime.Now;

                var folderName = domainModel.Name.ToLower();

                if (!_imageHandler.SaveImageToDisk(rawFileUpload, folderName))
                {
                    return View(createBrandViewModel);
                }

                Session.SaveOrUpdate(uploadedImage);                
                
                domainModel.Image = uploadedImage;

                Session.SaveOrUpdate(domainModel);
                Session.Flush();
                return RedirectToAction("Index");
            }

            else
            {
                return View(createBrandViewModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var brand = Session.Load<Brand>(id);        
            var model = new EditBrandViewModel();
            
            Mapper.Map(brand, model);
            _imageHandler.ResizeImage(model.Image, 150, 150);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit (EditBrandViewModel editBrandViewModel)
        {
            if(ModelState.IsValid)
            {
                var model = editBrandViewModel;
                var brand = Session.Get<Brand>(model.Id);
                
                Mapper.Map(model, brand);
                Session.SaveOrUpdate(brand);
                Session.Flush();
                return RedirectToAction("Details/" + model.Id);
            }

            return View(editBrandViewModel);
        }
        
        public ActionResult Delete(int id)
        {
            var brand = Session.Get<Brand>(id);
            Session.Delete(brand);
            Session.Flush();
            return RedirectToAction("Index");
        }
        

    }
}
