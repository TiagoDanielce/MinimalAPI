using Pokemon.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

//ConfigureServices
builder.Services.AddSingleton<PokemonRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/pokemons", (PokemonRepository repository) =>
{
    return Results.Ok(repository.GetAll());
});

app.MapGet("/pokemons/{id}", (PokemonRepository repository, int id) =>
{
    var pokemon = repository.GetById(id);

    return pokemon is not null ? Results.Ok(pokemon) : Results.NotFound();
});


app.Run();