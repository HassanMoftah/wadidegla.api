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
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ProductController(IUnitOfWork _unitofwork, IMapper _mapper)
        {
            unitOfWork = _unitofwork;
            mapper = _mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<TbProduct> products = unitOfWork.Products.GetAll().ToList();
            List<VMProduct> vmproducts = mapper.Map<List<TbProduct>, List<VMProduct>>(products);
            return Ok(vmproducts);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            TbProduct product = unitOfWork.Products.Get(id);
            VMProduct vmProduct = mapper.Map<TbProduct, VMProduct>(product);
            return Ok(vmProduct);
        }

        [ValidModel]
        [HttpPost]
        public IActionResult Add(VMProduct vmproduct)
        {
            TbProduct product = mapper.Map<VMProduct, TbProduct>(vmproduct);
            unitOfWork.Products.Add(product);
            unitOfWork.Complete();
            vmproduct.Id = product.Id;
            return Ok(vmproduct);

        }
        [ValidModel]
        [HttpPost]
        public IActionResult Edit(VMProduct vmproduct)
        {
            TbProduct product = unitOfWork.Products.Get(vmproduct.Id);
            if (product == null) { return NotFound(); }
            product = mapper.Map<VMProduct, TbProduct>(vmproduct);
            unitOfWork.Complete();
            return Ok(vmproduct);

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            TbProduct product = unitOfWork.Products.Get(id);
            if (product == null) { return NotFound(); }
            unitOfWork.Products.Remove(product);
            unitOfWork.Complete();
            return Ok();


        }
    }
}