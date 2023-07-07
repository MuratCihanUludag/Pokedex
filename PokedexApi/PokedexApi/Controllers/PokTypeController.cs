using Microsoft.AspNetCore.Mvc;
using PokedexApi.Context;
using PokedexApi.ViewModel;

namespace PokedexApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class PokTypeController : Controller
    {
        private readonly PokemonDbContext _context;
        public PokTypeController(PokemonDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetPokTypeList()
        {
            var pokTypeList = _context.PokemonTypes.OrderBy(type => type.id)
                .Select(type => new
                {
                    type.id,
                    type.Name
                })
                .ToList();
            return Ok(pokTypeList);
        }
        [HttpPost]
        public IActionResult CreatePokType([FromBody] PokemonTypeDTO model)
        {
            var createPokType = _context.PokemonTypes.SingleOrDefault(type => type.Name == model.Name);
            if (createPokType is not null)
            {
                throw new InvalidOperationException("There is a Pokemen type with this name");
            }
            createPokType = new Model.PokemonType
            {
                Name = model.Name,
            };
            _context.PokemonTypes.Add(createPokType);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("id")]
        public IActionResult UpdatePokType([FromBody] PokemonTypeDTO model, int id)
        {
            var updatePokType = _context.PokemonTypes.SingleOrDefault(type => type.id == id);
            if (updatePokType is null)
            {
                throw new InvalidOperationException("Pokemon type not found");
            }
            updatePokType.Name = model.Name;
            _context.PokemonTypes.Update(updatePokType);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult DeletePokType(int id)
        {
            var deletePokType = _context.PokemonTypes.Single(type => type.id == id);
            if (deletePokType is null)
            {
                throw new InvalidOperationException("Pokemon type not found");
            }
            _context.PokemonTypes.Remove(deletePokType);
            _context.SaveChanges();
            return Ok();
        }
    }
}
