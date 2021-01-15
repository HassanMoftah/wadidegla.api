using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wadidegla.API.ActionFilters;
using Wadidegla.DataLayer.Models;
using Wadidegla.Repositories.Interfaces;
using Wadidegla.viewmodels.ViewModels;

namespace Wadidegla.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryAttributeOptionController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CategoryAttributeOptionController(IUnitOfWork _unitofwork, IMapper _mapper)
        {
            unitOfWork = _unitofwork;
            mapper = _mapper;
        }
        [HttpGet]
        public IActionResult GetAllOfCategoryAttribute(int id)
        {
            List<TbCategoryAttributeOption> options = unitOfWork.CategoryAttributeOptions.GetAllOfCategoryAttribute(id).ToList();
            List<VMCategoryAttributeOption> vmoptions = mapper.Map<List<TbCategoryAttributeOption>, List<VMCategoryAttributeOption>>(options);
            return Ok(vmoptions);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            TbCategoryAttributeOption option = unitOfWork.CategoryAttributeOptions.Get(id);
            if (option == null) { return NotFound(); }
            VMCategoryAttributeOption vmoption = mapper.Map<TbCategoryAttributeOption, VMCategoryAttributeOption>(option);
            return Ok(vmoption);
        }

        [ValidModel]
        [HttpPost]
        public IActionResult Add(VMCategoryAttributeOption vmoption)
        {
            TbCategoryAttributeOption option = mapper.Map<VMCategoryAttributeOption, TbCategoryAttributeOption>(vmoption);
            unitOfWork.CategoryAttributeOptions.Add(option);
            unitOfWork.Complete();
            vmoption.Id = option.Id;
            return Ok(vmoption);

        }
        [ValidModel]
        [HttpPost]
        public IActionResult Edit(VMCategoryAttributeOption vmoption)
        {
            TbCategoryAttributeOption option = unitOfWork.CategoryAttributeOptions.Get(vmoption.Id);
            if (option == null) { return NotFound(); }
            option = mapper.Map<VMCategoryAttributeOption, TbCategoryAttributeOption>(vmoption);
            unitOfWork.Complete();
            return Ok(vmoption);

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            TbCategoryAttributeOption option = unitOfWork.CategoryAttributeOptions.Get(id);
            if (option == null) { return NotFound(); }
            unitOfWork.CategoryAttributeOptions.Remove(option);
            unitOfWork.Complete();
            return Ok();


        }
    }
}