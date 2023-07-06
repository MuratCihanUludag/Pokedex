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
        public IActionResult GetPokType()
        {
            var pokType = _context.PokemonTypes.OrderBy(type => type.id)
                .Select(type => new
                {
                    type.id,
                    type.Name
                })
                .ToList();
            return Ok(pokType);
        }
        [HttpPost]
        public IActionResult CreatePokType([FromBody] PokemonTypeViewModel model)
        {
            var createPokType = _context.PokemonTypes.SingleOrDefault(type => type.Name == model.Name);
            if (createPokType is not null)
            {
                throw new InvalidOperationException("Pokémon with the same name");
            }
            createPokType = new Model.PokemonType
            {
                Name = model.Name,
            };
            _context.PokemonTypes.Add(createPokType);
            _context.SaveChanges();
            return Ok();
        }

    }
}
