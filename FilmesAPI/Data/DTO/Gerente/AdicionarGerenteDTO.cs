using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.Gerente
{
    public class AdicionarGerenteDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        public string Nome { get; set; }
    }
}
