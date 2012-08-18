using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CumbriaMD.Domain;
using CumbriaMD.Infrastructure.ViewModels.BrandViewModels;
using CumbriaMD.Infrastructure.ViewModels.CategoryViewModels;

namespace CumbriaMD.Web.AutoMapper
{
    public class ViewModelProfile : Profile 
    {
        public override string ProfileName
        {
            get { return "ViewModel"; }
        }

        protected override void Configure()
        {
            #region Brand Maps

            CreateMap<CreateBrandViewModel, Brand>();
            CreateMap<Brand, ListBrandsViewModel>();
            CreateMap<Brand, DetailsBrandViewModel>();
            CreateMap<EditBrandViewModel, Brand>();
            CreateMap<Brand, EditBrandViewModel>();

            #endregion

            #region Category Maps

            CreateMap<CreateCategoryViewModel, Category>();
            CreateMap<Category, ListCategoriesViewModel>()
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.Parent.Id))
                .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent.Name));
            CreateMap<Category, DetailsCategoryViewModel>();
            CreateMap<EditCategoryViewModel, Category>();

            #endregion

        }
    }
}