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
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CategoryController (IUnitOfWork _unitofwork,IMapper _mapper)
        {
            unitOfWork = _unitofwork;
            mapper = _mapper;
        }
        [HttpGet]
        public IActionResult GetAllOfParent(int id)
        {
            var Categories = unitOfWork.Categories.GetAllOfParent(id).ToList();
            List<VMEditCategory> VMcategories = mapper.Map<List<TbCategory>, List<VMEditCategory>>(Categories);

            return Ok(VMcategories);
        }
        [HttpGet]
        public IActionResult GetAllFirstParents()
        {
            var Categories = unitOfWork.Categories.GetAllFirstParents().ToList();
            List<VMEditCategory> VMcategories = mapper.Map<List<TbCategory>, List<VMEditCategory>>(Categories);

            return Ok(VMcategories);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            TbCategory category= unitOfWork.Categories.Get(id);
            if (category == null) { return NotFound(); }
            VMEditCategory vmcategory = mapper.Map<TbCategory, VMEditCategory>(category);
            return Ok(vmcategory);
        }

        [ValidModel]
        [HttpPost]
        public IActionResult Add(VMAddCategory vmcategory)
        {
            TbCategory TobeaddedCategory = new TbCategory();
            VMEditCategory addedCategory = new VMEditCategory();
            mapper.Map(vmcategory, TobeaddedCategory);
            unitOfWork.Categories.Add(TobeaddedCategory);
            unitOfWork.Complete();
            mapper.Map(TobeaddedCategory, addedCategory);
            return Ok(addedCategory); 

        }
        [ValidModel]
        [HttpPost]
        public IActionResult Edit(VMEditCategory vmcategory)
        {

            TbCategory TobeUpdatedCategory = unitOfWork.Categories.Get(vmcategory.Id);
            if (TobeUpdatedCategory == null) { return NotFound(); }
            mapper.Map(vmcategory, TobeUpdatedCategory);
            unitOfWork.Complete();
            return Ok(vmcategory);

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            TbCategory category = unitOfWork.Categories.Get(id);
            if (category == null) { return NotFound(); }
            unitOfWork.Categories.Remove(category);
            unitOfWork.Complete();
            return Ok();
        }

    }
}