﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   // --> Attribute : .Net --> Annotation : Java
    public class ProductsController : ControllerBase
    {
        // Loosely Coupled -- Az bağımlı
        // IoC Container -- Inversion of control
        // => Objelerin instancelarının containerlar içerisinde tutularak dependency'nin azaltılmasını sağlar. 
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // routing ya da alliance şeklinde aynı http operasyonlar özelleştirilebilir.
        [HttpGet("getall")]
        public IActionResult Get()
        {
            // Dependency Chain
            // IProductService productService = new ProductManager(new EfProductDal());
            // Swagger -- API Documentation & Design Tools for Teams

            Thread.Sleep(500);

            var result = _productService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        // Update --> PUT ve Delete --> Delete kullanılabilir ama genelde iki işlem için de POST kullanılır.

        [HttpGet("getbycategoryid")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
