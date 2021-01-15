using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wadidegla.DataLayer.Models;
using Wadidegla.viewmodels.ViewModels;

namespace Wadidegla.API.AutoMapperProfiles
{
    public class CategoryAttributeOptionProfile : Profile
    {
        public CategoryAttributeOptionProfile()
        {
            CreateMap<VMCategoryAttributeOption, TbCategoryAttributeOption>();
            CreateMap<TbCategoryAttributeOption, VMCategoryAttributeOption>();
        }
    }
}
