﻿using API.Nft.Context;
using API.Nft.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Nft.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
    
        // GET: /<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                var products = _context.Products?.AsNoTracking().Take(10).ToList();
                if (products is null)
                {
                    return NotFound("Nenhum produto foi encontrado.");
                }
                return products;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }

        }

        // GET /<ProductController>/5
        [HttpGet("{id:int}", Name ="ObterProduto")]
        public ActionResult<Product> Get(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == id);
                if (product is null)
                {
                    return NotFound("Produto não encontrado...");
                }
                return product;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
            
        }

        // POST /<ProductController>
        [HttpPost]
        public ActionResult Post(Product product)
        {
            try
            {
                if (product is null)
                {
                    return BadRequest();
                }

                _context.Products.Add(product);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterProduto",
                    new { id = product.Id }, product);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
            
        }

        // PUT /<ProductController>/5
        [HttpPatch("{id}")]
        public ActionResult Patch(int id, Product product)
        {
            try
            {
                var productToChange = _context.Products.FirstOrDefault(p => p.Id == id);
                if (productToChange is null)
                {
                    return NotFound("Produto não encontrado...");
                }
                _context.Update(productToChange);
                _context.SaveChanges();

                return Ok(productToChange);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
        }

        // DELETE /<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var product = _context.Products?.Find(id);
                if (product is null)
                {
                    return NotFound("Produto não localizado...");
                }
                _context.Products?.Remove(product);
                _context.SaveChanges();

                return Ok(product);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
        }
    }
}
