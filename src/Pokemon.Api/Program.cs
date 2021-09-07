using Pokemon.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<PokemonRepository>();

var app = builder.Build();

app.MapGet("/pokemons", (PokemonRepository repository) =>
{
    return repository.GetAll();
});

app.MapGet("/pokemons/{id}", (PokemonRepository repository, int id) =>
{
    var pokemon = repository.GetById(id);

    return pokemon is not null ? Results.Ok(pokemon) : Results.NotFound();
});


app.Run();