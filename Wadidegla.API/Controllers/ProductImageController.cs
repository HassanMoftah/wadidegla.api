using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wadidegla.API.ActionFilters;
using Wadidegla.API.Storage;
using Wadidegla.DataLayer.Models;
using Wadidegla.Repositories.Interfaces;
using Wadidegla.viewmodels.ViewModels;

namespace Wadidegla.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IImageStorage imageStorage;
        public ProductImageController(IUnitOfWork _unitofwork, IMapper _mapper,IImageStorage _imagestorage)
        {
            unitOfWork = _unitofwork;
            mapper = _mapper;
            imageStorage = _imagestorage;
        }
        [HttpGet]
        public IActionResult GetAllOfProduct(int id)
        {
            List<TbProductImage> productImages = unitOfWork.ProductImages.GetAllOfProduct(id).ToList();
            List<VMProductImage> vmproductimages = mapper.Map<List<TbProductImage>, List<VMProductImage>>(productImages);
            return Ok(vmproductimages);
        }
        [ValidModel]
        [HttpPost]
        public IActionResult Add(VMProductImage vmproductimage)
        {
            TbProductImage productImage = mapper.Map<VMProductImage, TbProductImage>(vmproductimage);
            unitOfWork.ProductImages.Add(productImage);
            unitOfWork.Complete();
            vmproductimage.Id = productImage.Id;
            return Ok(vmproductimage);

        }
        [HttpPost]
        public IActionResult UploadImage(int id)
        {
           
           TbProductImage productImage = unitOfWork.ProductImages.Get(id);
            if (productImage == null) { return NotFound(); }
            if (imageStorage.AddImage(HttpContext.Request, id))
            {
                productImage.Extension = imageStorage.GetFileExtention(HttpContext.Request);
                unitOfWork.Complete();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            TbProductImage productimage = unitOfWork.ProductImages.Get(id);
            if (productimage == null) { return NotFound(); }
            unitOfWork.ProductImages.Remove(productimage);
            unitOfWork.Complete();
            return Ok();


        }
    }
}