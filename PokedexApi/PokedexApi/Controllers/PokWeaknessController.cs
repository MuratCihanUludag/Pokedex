using Microsoft.AspNetCore.Mvc;
using PokedexApi.Context;
using PokedexApi.ViewModel;

namespace PokedexApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class PokWeaknessController : Controller
    {
        private readonly PokemonDbContext _context;
        public PokWeaknessController(PokemonDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetPokWeaknessList()
        {
            var pokWeaknessList = _context.PokemonWeaknesses.OrderBy(weak => weak.id)
                .Select(weak => new
                {
                    weak.id,
                    weak.Name
                })
                .ToList();
            return Ok(pokWeaknessList);
        }
        [HttpPost]
        public IActionResult CreatePokWeakness([FromBody] PokemonWeaknessViewModel model)
        {
            var createPokWeakness = _context.PokemonWeaknesses.SingleOrDefault(weak => weak.Name == model.Name);
            if (createPokWeakness is not null)
            {
                throw new InvalidOperationException("There is a Pokemen weakness with this name");
            }
            createPokWeakness = new Model.PokemonWeakness
            {
                Name = model.Name,
            };
            _context.PokemonWeaknesses.Add(createPokWeakness);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("id")]
        public IActionResult UpdatePokWeakness([FromBody] PokemonWeaknessViewModel model, int id)
        {
            var updatePokWeakness = _context.PokemonWeaknesses.SingleOrDefault(weak => weak.id == id);
            if (updatePokWeakness is null)
            {
                throw new InvalidOperationException("Pokemon weakness not found");
            }
            updatePokWeakness.Name = model.Name;
            _context.PokemonWeaknesses.Update(updatePokWeakness);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult DeletePokWeakness(int id)
        {
            var deletePokWeakness = _context.PokemonWeaknesses.SingleOrDefault(weak => weak.id == id);
            if (deletePokWeakness is null)
            {
                throw new InvalidOperationException("Pokemon weakness not found");
            }
            _context.PokemonWeaknesses.Remove(deletePokWeakness);
            _context.SaveChanges();
            return Ok();
        }
    }
}
