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

namespace Wadidegla.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductAttributeController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ProductAttributeController(IUnitOfWork _unitofwork, IMapper _mapper)
        {
            unitOfWork = _unitofwork;
            mapper = _mapper;
        }
        [HttpGet]
        public IActionResult GetAllOfProduct(int id)
        {
            List<TbProductAttribute> productAttributes = unitOfWork.ProductAttributes.GetEagerLoadingOfProduct(id).ToList();
            return Ok(productAttributes);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {

            TbProductAttribute productAttribute = unitOfWork.ProductAttributes.GetEagerLoading(id);
            return Ok(productAttribute);
        }

        [ValidModel]
        [HttpPost]
        public IActionResult Add(TbProductAttribute attribute)
        {

            unitOfWork.ProductAttributes.Add(attribute);
            unitOfWork.Complete();
            return Ok(attribute);

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            TbProductAttribute attribute = unitOfWork.ProductAttributes.Get(id);
            if (attribute == null) { return NotFound(); }
            unitOfWork.ProductAttributes.Remove(attribute);
            unitOfWork.Complete();
            return Ok();


        }
    }
}