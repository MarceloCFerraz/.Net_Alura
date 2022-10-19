using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Endereco
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de logradouro é obrigatório!")]
        public string Logradouro { get; set; } // Rua
        [Required(ErrorMessage = "O campo de bairro é obrigatório!")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O campo de numero é obrigatório!")]
        public int Numero { get; set; }
        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}
