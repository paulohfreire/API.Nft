using API.Nft.Context;
using API.Nft.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Nft.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /<CategoryController>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            try
            {
                var categories = _context.Categories?.AsNoTracking().ToList();
                if (categories is null)
                {
                    return NotFound("Não foi encontrada essa categoria.");
                }
                return categories;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
        }

        // GET /<CategoryController>/5
        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Category> Get(int id)
        {
            try
            {
                var category = _context.Categories?.FirstOrDefault(p => p.CategoryId == id);
                if (category is null)
                {
                    return NotFound("Categoria não encontrada...");
                }
                return category;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
        }

        // POST /<CategoryController>
        [HttpPost]
        public ActionResult Post(Category category)
        {
            try
            {
                if (category is null)
                {
                    return BadRequest();
                }

                _context.Categories?.Add(category);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterCategoria",
                    new { id = category.CategoryId }, category);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
        }

        // PUT /<CategoryController>/5
        [HttpPatch("{id}")]
        public ActionResult Patch(int id, Category category)
        {
            try
            {
                var categoryToChange = _context.Categories?.FirstOrDefault(p => p.CategoryId == id);
                if (categoryToChange is null)
                {
                    return NotFound("Categoria não encontrada...");
                }
                _context.Update(categoryToChange);
                _context.SaveChanges();

                return Ok(categoryToChange);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
        }

        // DELETE /<CategoryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var category = _context.Categories?.Find(id);
                if (category is null)
                {
                    return NotFound("Produto não localizado...");
                }
                _context.Categories?.Remove(category);
                _context.SaveChanges();

                return Ok(category);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
        }
    }
}
