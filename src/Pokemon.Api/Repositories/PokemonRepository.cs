using Pokemon.Api.Database;
using Pokemon.Api.Models;

namespace Pokemon.Api.Repositories
{
    public class PokemonRepository
    {
        private readonly Dictionary<int, PokemonRecord> _pokemons = PokemonDatabase.Dictionary();

        public PokemonRecord GetById(int id)
        {
            return _pokemons[id];
        }

        public IEnumerable<PokemonRecord> GetAll()
        {
            return _pokemons.Values.ToList();
        }
    }
}
