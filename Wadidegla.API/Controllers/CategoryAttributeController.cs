using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
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
   

    public class CategoryAttributeController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CategoryAttributeController(IUnitOfWork _unitofwork, IMapper _mapper)
        {
            unitOfWork = _unitofwork;
            mapper = _mapper;
        }
        [HttpGet]
        public IActionResult GetAllOfCategory(int id)
        {
            List<TbCategoryAttribute> categoryAttributes = unitOfWork.CategoryAttributes.GetAllOfCategory(id).ToList();
            List<VMCategoryAttribute> vmcategoryAttributes = 
                mapper.Map<List<TbCategoryAttribute>, List<VMCategoryAttribute>>(categoryAttributes);
            return Ok(vmcategoryAttributes);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            TbCategoryAttribute categoryattribute = unitOfWork.CategoryAttributes.Get(id);
            if (categoryattribute == null) { return NotFound(); }
            VMCategoryAttribute vMCategory = mapper.Map<TbCategoryAttribute, VMCategoryAttribute>(categoryattribute);
            return Ok(vMCategory);
        }

        [ValidModel]
        [HttpPost]
        public IActionResult Add(VMCategoryAttribute vmCategoryAttribute)
        {
            TbCategoryAttribute tbCategoryattribute = mapper.Map<VMCategoryAttribute, TbCategoryAttribute>(vmCategoryAttribute);
            unitOfWork.CategoryAttributes.Add(tbCategoryattribute);
            unitOfWork.Complete();
            vmCategoryAttribute.Id = tbCategoryattribute.Id;
            return Ok(vmCategoryAttribute);

        }
        [ValidModel]
        [HttpPost]
        public IActionResult Edit(VMCategoryAttribute vmCategoryAttribute)
        {
            TbCategoryAttribute tbCategory = unitOfWork.CategoryAttributes.Get(vmCategoryAttribute.Id);
            if (tbCategory == null) { return NotFound(); }
            tbCategory = mapper.Map<VMCategoryAttribute, TbCategoryAttribute>(vmCategoryAttribute);
            unitOfWork.Complete();
            return Ok(vmCategoryAttribute);

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            TbCategoryAttribute categoryattribute = unitOfWork.CategoryAttributes.Get(id);
            if (categoryattribute == null) { return NotFound(); }
            unitOfWork.CategoryAttributes.Remove(categoryattribute);
            unitOfWork.Complete();
            return Ok();

           
        }
    }
}