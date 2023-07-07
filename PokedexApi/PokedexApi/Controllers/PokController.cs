using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokedexApi.Context;
using PokedexApi.ViewModel;

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
        [HttpPost]
        public IActionResult CreatePokemon([FromBody] PokemonViewModel model)
        {
            var createPokemon = _context.Pokemons.SingleOrDefault(pokemon => pokemon.Name == model.Name);
            if (createPokemon is not null)
            {
                throw new InvalidOperationException("There is a Pokemen with this name");
            }
            createPokemon = new Model.Pokemon
            {
                Name = model.Name,
                Description = model.Description,
                Category = model.Category,
                PokemonTypes = _context.PokemonTypes.Where(type => model.PokemonTypesId.Contains(type.id)).ToList(),
                pokemonWeaknesses = _context.PokemonWeaknesses.Where(type => model.pokemonWeaknessesId.Contains(type.id)).ToList(),
                PokemonStats =
                {
                    Hp = model.PokemonStats.Hp,
                    Attack = model.PokemonStats.Attack,
                    Defense = model.PokemonStats.Defense,
                    SpecialAttack = model.PokemonStats.SpecialAttack,
                    SpecialDefense = model.PokemonStats.SpecialDefense,
                    Speed = model.PokemonStats.Speed,
                }
            };
            _context.Pokemons.Add(createPokemon);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("id")]
        public IActionResult GetPokemon(int id)
        {
            var pok = _context.Pokemons
                .Include(type => type.PokemonTypes)
                .Include(weak => weak.pokemonWeaknesses)
                .Include(stat => stat.PokemonStats)
                .FirstOrDefault(pokemon => pokemon.id == id);
            if (pok == null)
            {
                throw new InvalidOperationException("Pokemon is not found");
            }
            return Ok(pok);
        }
        [HttpPut("id")]
        public IActionResult UpdatePokemon([FromBody] PokemonViewModel model, int id)
        {
            var updatePok = _context.Pokemons
                .Include(type => type.PokemonTypes)
                .Include(weak => weak.pokemonWeaknesses)
                .SingleOrDefault(pok => pok.id == id);
            if (updatePok is null)
            {
                throw new InvalidOperationException("Pokemon is not found");
            }
            updatePok.Name = model.Name;
            updatePok.Description = model.Description;
            updatePok.Category = model.Category;
            updatePok.PokemonTypes = _context.PokemonTypes.Where(type => model.PokemonTypesId.Contains(type.id)).ToList();
            updatePok.pokemonWeaknesses = _context.PokemonWeaknesses.Where(weak => model.pokemonWeaknessesId.Contains(weak.id)).ToList();
            updatePok.PokemonStats.Hp = model.PokemonStats.Hp;
            updatePok.PokemonStats.Attack = model.PokemonStats.Attack;
            updatePok.PokemonStats.Defense = model.PokemonStats.Defense;
            updatePok.PokemonStats.SpecialAttack = model.PokemonStats.SpecialAttack;
            updatePok.PokemonStats.SpecialDefense = model.PokemonStats.SpecialDefense;
            updatePok.PokemonStats.Speed = model.PokemonStats.Speed;
            _context.Pokemons.Update(updatePok);
            _context.SaveChanges();
            return Ok();
        }

    }
}
