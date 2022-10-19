using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Gerente
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        public string Nome { get; set; }
        [JsonIgnore]
        public virtual List<Cinema> Cinemas { get; set; }

    }
}
