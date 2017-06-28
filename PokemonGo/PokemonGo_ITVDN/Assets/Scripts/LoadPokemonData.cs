using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class LoadPokemonData : MonoBehaviour
{
    public GameObject[] PokemonPrefabs;
    public List<PokemonModel> PokemonModels { get; set; }
    public List<PokemonHelper> PokemonHelpers { get; set; }

    private GameHelper _gameHelper;
    private string _xml = "";
    private IEnumerator Start()
    {
        PokemonModels = new List<PokemonModel>();
        PokemonHelpers = new List<PokemonHelper>();
        _gameHelper = GetComponent<GameHelper>();

        while (!_gameHelper.GpsFix)
        {
            yield return null;
        }

        WWW www = new WWW("https://docs.google.com/uc?id=0B8_KhHuqPhc6YU05aHpFdnA2Wms");
        while (!www.isDone)
        {
            yield return null;
        }

        _xml = www.text;

        XDocument doc = XDocument.Parse(_xml);
        XElement element = doc.Element("pokemons");
        IEnumerable<XElement> elements = element.Elements();

        foreach (XElement item in elements)
        {
            PokemonModel pokemonModel = new PokemonModel();
            int pokemonTypeInt = System.Convert.ToInt32(item.Attribute("type").Value);
            pokemonModel.PokemonType = (ETypes)pokemonTypeInt;

            pokemonModel.Id = System.Convert.ToInt32(item.Attribute("id").Value);

            pokemonModel.Lat = System.Convert.ToSingle(item.Attribute("lat").Value);
            pokemonModel.Lon = System.Convert.ToSingle(item.Attribute("lon").Value);
            pokemonModel.Orint = System.Convert.ToSingle(item.Attribute("orint").Value);

            pokemonModel.Exp = System.Convert.ToInt32(item.Attribute("exp").Value);
            pokemonModel.Damage = System.Convert.ToInt32(item.Attribute("damage").Value);
            pokemonModel.Health = System.Convert.ToInt32(item.Attribute("health").Value);

            PokemonModels.Add(pokemonModel);
        }

        for (int i = 0; i < PokemonModels.Count; i++)
        {
            var item = PokemonModels[i];

            GameObject pokemon = Instantiate(PokemonPrefabs[(int)item.PokemonType]);
            SetGeolocation setGeolocation = pokemon.GetComponent<SetGeolocation>();
            setGeolocation.SetLoacation(item.Lat, item.Lon, item.Orint);

            PokemonHelper pokemonHelper = pokemon.GetComponent<PokemonHelper>();
            pokemonHelper.LoadPokemon(item);

            PokemonHelpers.Add(pokemonHelper);
        }


    }
}
