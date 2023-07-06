using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokedexApi.Context;

namespace PokedexApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class PokController : Controller
    {
        private readonly PokemonDbContext _context;
        public PokController(PokemonDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetPokemonList()
        {
            var pokemonList = _context.Pokemons
                .Include(type => type.PokemonTypes)
                .Include(weak => weak.pokemonWeaknesses)
                .Include(stat => stat.PokemonStats)
                .Select(select => new
                {
                    select.id,
                    select.Name,
                    select.Description,
                    select.Category,
                    Type = _context.PokemonTypes.Select(type => type.Name).ToList(),
                    Weakness = _context.PokemonWeaknesses.Select(weak => weak.Name).ToList(),
                    Stats = _context.PokemonStats.Select(stat => new
                    {
                        stat.Hp,
                        stat.Attack,
                        stat.Defense,
                        stat.SpecialAttack,
                        stat.SpecialDefense,
                        stat.Speed
                    })
                })
                .ToList();
            return Ok(pokemonList);
        }
        
        
    }
}
