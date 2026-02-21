using System.Text.Json.Serialization;

namespace Teste.Models
{
    public class Pokemon
    {
        [JsonPropertyName("id")]
        public int IdPokemon{ get; set; }


        [JsonPropertyName("name")]
        public string? NomePokemon{ get; set; }


        [JsonPropertyName("weight")]
        public double PesoPokemon { get; set; }


        [JsonPropertyName("height")]
        public double Altura{ get; set; }
    }
}
