using System.ComponentModel.DataAnnotations;

namespace Teste.Utils
{
    public record TimeRecord
    (
        [Required(ErrorMessage = "Para criar um time é obrigatório a existência de um proprietário!")] string ProprietarioR,
        [MinLength(1, ErrorMessage="A equipe de pokemons necessita de no mínimo 1 pokemon!")] List<string> ListaTimeR
    );

}
