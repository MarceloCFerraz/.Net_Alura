using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Título é Obrigatório!")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é Obrigatório!")]
        public string Diretor { get; set; }
        [Required]
        [Range(1,600,ErrorMessage = "O filme só pode ter entre 1 e 600 minutos")]
        public int Duracao { get; set; }
        [Required]
        [Range(0,18,ErrorMessage = "A classificação etária deve ser de 0 a 18 anos")]
        public int ClassificacaoEtaria { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}
