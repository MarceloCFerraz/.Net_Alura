using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.Endereco
{
    public class ReadEnderecoDTO
    {
        // Um DTO (Data Transfer Object) tem como objetivo ser um intermediário entre
        // o sistema e o banco de dados. Como normalmente transitam dados que não são
        // obrigatórios pelo sistema, o DTO entra para fazer essa abstração e mediar
        // esse trânsito de dados internos, sendo possível converter/mapear um objeto
        // da classe original PARA um DTO ou um objeto de uma classe DTO para um da
        // classe original. Adota-se o padrão de criar um DTO para cada necessidade
        // dos métodos da classe controladora para remover ou adicionar campos perti-
        // nentes para cada método sem mexer na nossa classe principal.
        public int Id { get; set; }
        public string Logradouro { get; set; } // Rua
        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}
