using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wadidegla.DataLayer.Models;
using Wadidegla.viewmodels.ViewModels;

namespace Wadidegla.API.AutoMapperProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<VMProduct, TbProduct>();
            CreateMap<TbProduct, VMProduct>();
        }
    }
}
