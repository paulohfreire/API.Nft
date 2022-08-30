using API.Nft.Context;
using API.Nft.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Nft.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OwnerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /<OwnerController>
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            try
            {
                var owner = _context.Owner?.ToList();
                if (owner is null)
                {
                    return NotFound("Não foi encontrado esse usuário.");
                }
                return owner;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
        }

        // GET /<OwnerController>/5
        [HttpGet("{id:int}", Name = "ObterUsuario")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {
                var owner = _context.Owner?.FirstOrDefault(p => p.OwnerId == id);
                if (owner is null)
                {
                    return NotFound("Usuário não encontrado...");
                }
                return owner;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
        }

        // POST /<OwnerController>
        [HttpPost]
        public ActionResult Post(Owner owner)
        {
            try
            {
                if (owner is null)
                {
                    return BadRequest();
                }

                _context.Owner?.Add(owner);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterUsuario",
                    new { id = owner.OwnerId }, owner);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
        }

        // PUT /<OwnerController>/5
        [HttpPatch("{id}")]
        public ActionResult Patch(int id)
        {
            try
            {
                var ownerToChange = _context.Owner?.FirstOrDefault(p => p.OwnerId == id);
                if (ownerToChange is null)
                {
                    return NotFound("Usuário não encontrado...");
                }
                _context.Update(ownerToChange);
                _context.SaveChanges();

                return Ok(ownerToChange);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
        }

        // DELETE /<OwnerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var owner = _context.Owner?.Find(id);
                if (owner is null)
                {
                    return NotFound("Usuário não localizado...");
                }
                _context.Owner?.Remove(owner);
                _context.SaveChanges();

                return Ok(owner);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar sua solicitação.");
            }
        }
    }
}
