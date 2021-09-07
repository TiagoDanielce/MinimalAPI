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

record Pokemon(int Id, string Name);

class PokemonRepository
{
    private readonly Dictionary<int, Pokemon> _pokemons = PokemonDataBase.Dictionary();

    public Pokemon GetById(int id)
    {
        return _pokemons[id];
    }

    public IEnumerable<Pokemon> GetAll()
    {
        return _pokemons.Values.ToList();
    }
}

class PokemonDataBase
{
    public static Dictionary<int, Pokemon> Dictionary()
    {
        return new Dictionary<int, Pokemon>() {
            { 1, new Pokemon(1, "bulbasaur") },
            { 2, new Pokemon(2, "ivysaur") },
            { 3, new Pokemon(3, "venusaur") },
            { 4, new Pokemon(4, "charmander") },
            { 5, new Pokemon(5, "charmeleon") },
            { 6, new Pokemon(6, "charizard") },
            { 7, new Pokemon(7, "squirtle") },
            { 8, new Pokemon(8, "wartortle") },
            { 9, new Pokemon(9, "blastoise") },
            { 10, new Pokemon(10, "caterpie") },
            { 11, new Pokemon(11, "metapod") },
            { 12, new Pokemon(12, "butterfree") },
            { 13, new Pokemon(13, "weedle") },
            { 14, new Pokemon(14, "kakuna") },
            { 15, new Pokemon(15, "beedrill") },
            { 16, new Pokemon(16, "pidgey") },
            { 17, new Pokemon(17, "pidgeotto") },
            { 18, new Pokemon(18, "pidgeot") },
            { 19, new Pokemon(19, "rattata") },
            { 20, new Pokemon(20, "raticate") },
            { 21, new Pokemon(21, "spearow") },
            { 22, new Pokemon(22, "fearow") },
            { 23, new Pokemon(23, "ekans") },
            { 24, new Pokemon(24, "arbok") },
            { 25, new Pokemon(25, "pikachu") },
            { 26, new Pokemon(26, "raichu") },
            { 27, new Pokemon(27, "sandshrew") },
            { 28, new Pokemon(28, "sandslash") },
            { 29, new Pokemon(29, "nidoran-f") },
            { 30, new Pokemon(30, "nidorina") },
            { 31, new Pokemon(31, "nidoqueen") },
            { 32, new Pokemon(32, "nidoran-m") },
            { 33, new Pokemon(33, "nidorino") },
            { 34, new Pokemon(34, "nidoking") },
            { 35, new Pokemon(35, "clefairy") },
            { 36, new Pokemon(36, "clefable") },
            { 37, new Pokemon(37, "vulpix") },
            { 38, new Pokemon(38, "ninetales") },
            { 39, new Pokemon(39, "jigglypuff") },
            { 40, new Pokemon(40, "wigglytuff") },
            { 41, new Pokemon(41, "zubat") },
            { 42, new Pokemon(42, "golbat") },
            { 43, new Pokemon(43, "oddish") },
            { 44, new Pokemon(44, "gloom") },
            { 45, new Pokemon(45, "vileplume") },
            { 46, new Pokemon(46, "paras") },
            { 47, new Pokemon(47, "parasect") },
            { 48, new Pokemon(48, "venonat") },
            { 49, new Pokemon(49, "venomoth") },
            { 50, new Pokemon(50, "diglett") },
            { 51, new Pokemon(51, "dugtrio") },
            { 52, new Pokemon(52, "meowth") },
            { 53, new Pokemon(53, "persian") },
            { 54, new Pokemon(54, "psyduck") },
            { 55, new Pokemon(55, "golduck") },
            { 56, new Pokemon(56, "mankey") },
            { 57, new Pokemon(57, "primeape") },
            { 58, new Pokemon(58, "growlithe") },
            { 59, new Pokemon(59, "arcanine") },
            { 60, new Pokemon(60, "poliwag") },
            { 61, new Pokemon(61, "poliwhirl") },
            { 62, new Pokemon(62, "poliwrath") },
            { 63, new Pokemon(63, "abra") },
            { 64, new Pokemon(64, "kadabra") },
            { 65, new Pokemon(65, "alakazam") },
            { 66, new Pokemon(66, "machop") },
            { 67, new Pokemon(67, "machoke") },
            { 68, new Pokemon(68, "machamp") },
            { 69, new Pokemon(69, "bellsprout") },
            { 70, new Pokemon(70, "weepinbell") },
            { 71, new Pokemon(71, "victreebel") },
            { 72, new Pokemon(72, "tentacool") },
            { 73, new Pokemon(73, "tentacruel") },
            { 74, new Pokemon(74, "geodude") },
            { 75, new Pokemon(75, "graveler") },
            { 76, new Pokemon(76, "golem") },
            { 77, new Pokemon(77, "ponyta") },
            { 78, new Pokemon(78, "rapidash") },
            { 79, new Pokemon(79, "slowpoke") },
            { 80, new Pokemon(80, "slowbro") },
            { 81, new Pokemon(81, "magnemite") },
            { 82, new Pokemon(82, "magneton") },
            { 83, new Pokemon(83, "farfetchd") },
            { 84, new Pokemon(84, "doduo") },
            { 85, new Pokemon(85, "dodrio") },
            { 86, new Pokemon(86, "seel") },
            { 87, new Pokemon(87, "dewgong") },
            { 88, new Pokemon(88, "grimer") },
            { 89, new Pokemon(89, "muk") },
            { 90, new Pokemon(90, "shellder") },
            { 91, new Pokemon(91, "cloyster") },
            { 92, new Pokemon(92, "gastly") },
            { 93, new Pokemon(93, "haunter") },
            { 94, new Pokemon(94, "gengar") },
            { 95, new Pokemon(95, "onix") },
            { 96, new Pokemon(96, "drowzee") },
            { 97, new Pokemon(97, "hypno") },
            { 98, new Pokemon(98, "krabby") },
            { 99, new Pokemon(99, "kingler") },
            { 100, new Pokemon(100, "voltorb") },
            { 101, new Pokemon(101, "electrode") },
            { 102, new Pokemon(102, "exeggcute") },
            { 103, new Pokemon(103, "exeggutor") },
            { 104, new Pokemon(104, "cubone") },
            { 105, new Pokemon(105, "marowak") },
            { 106, new Pokemon(106, "hitmonlee") },
            { 107, new Pokemon(107, "hitmonchan") },
            { 108, new Pokemon(108, "lickitung") },
            { 109, new Pokemon(109, "koffing") },
            { 110, new Pokemon(110, "weezing") },
            { 111, new Pokemon(111, "rhyhorn") },
            { 112, new Pokemon(112, "rhydon") },
            { 113, new Pokemon(113, "chansey") },
            { 114, new Pokemon(114, "tangela") },
            { 115, new Pokemon(115, "kangaskhan") },
            { 116, new Pokemon(116, "horsea") },
            { 117, new Pokemon(117, "seadra") },
            { 118, new Pokemon(118, "goldeen") },
            { 119, new Pokemon(119, "seaking") },
            { 120, new Pokemon(120, "staryu") },
            { 121, new Pokemon(121, "starmie") },
            { 122, new Pokemon(122, "mr-mime") },
            { 123, new Pokemon(123, "scyther") },
            { 124, new Pokemon(124, "jynx") },
            { 125, new Pokemon(125, "electabuzz") },
            { 126, new Pokemon(126, "magmar") },
            { 127, new Pokemon(127, "pinsir") },
            { 128, new Pokemon(128, "tauros") },
            { 129, new Pokemon(129, "magikarp") },
            { 130, new Pokemon(130, "gyarados") },
            { 131, new Pokemon(131, "lapras") },
            { 132, new Pokemon(132, "ditto") },
            { 133, new Pokemon(133, "eevee") },
            { 134, new Pokemon(134, "vaporeon") },
            { 135, new Pokemon(135, "jolteon") },
            { 136, new Pokemon(136, "flareon") },
            { 137, new Pokemon(137, "porygon") },
            { 138, new Pokemon(138, "omanyte") },
            { 139, new Pokemon(139, "omastar") },
            { 140, new Pokemon(140, "kabuto") },
            { 141, new Pokemon(141, "kabutops") },
            { 142, new Pokemon(142, "aerodactyl") },
            { 143, new Pokemon(143, "snorlax") },
            { 144, new Pokemon(144, "articuno") },
            { 145, new Pokemon(145, "zapdos") },
            { 146, new Pokemon(146, "moltres") },
            { 147, new Pokemon(147, "dratini") },
            { 148, new Pokemon(148, "dragonair") },
            { 149, new Pokemon(149, "dragonite") },
            { 150, new Pokemon(150, "mewtwo") },
            { 151, new Pokemon(151, "mew") }
        };
    }
}
