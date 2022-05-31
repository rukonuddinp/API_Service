using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Service.DAL;
using API_Service.Models;
using API_Service.Services;
using API_Service.Dtos;

namespace API_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationContext db;
       private readonly IProductService productService;

        public ProductsController(IProductService productService, ApplicationContext db)
        {

          this.db = db;
          this.productService = productService;

        }

        // GET: api/Products
        [HttpGet]
        public  ActionResult GetProducts()
        {
            var dataall = productService.GelAll();
            var allproduct = dataall.Select(s => new ProductDtos()
            {
                ProductId = s.ProductId,
                ProductName = s.ProductName,
                Brand = s.Brand,
                Address = s.Address
            });


            return  Ok(allproduct);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            var s = productService.GetById(id);

            ProductDtos pbt = new ProductDtos();


                pbt.ProductId = s.ProductId;
                pbt.ProductName = s.ProductName;
                pbt.Brand = s.Brand;
                pbt.Address = s.Address;

           
            return Ok(pbt);

        }


        // POST: api/Products

        [HttpPost]
        public ActionResult PostProduct([FromBody]Product product)
        {

           var s= productService.PostProduct(product);
            ProductDtos pbt = new ProductDtos();


            pbt.ProductId = s.ProductId;
            pbt.ProductName = s.ProductName;
            pbt.Brand = s.Brand;
            pbt.Address = s.Address;


            return  Ok(pbt);

            
        }

        
      
    }
}
