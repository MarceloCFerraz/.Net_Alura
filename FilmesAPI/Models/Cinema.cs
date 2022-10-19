﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório!")]
        public string Nome { get; set; }
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public virtual Gerente Gerente { get; set; }
        public int GerenteID { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}