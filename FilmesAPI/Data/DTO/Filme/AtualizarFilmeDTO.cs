using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.Filme
{
    public class AtualizarFilmeDTO
    {

        // Um DTO (Data Transfer Object) tem como objetivo ser um intermediário entre
        // o sistema e o banco de dados. Como normalmente transitam dados que não são
        // obrigatórios pelo sistema, o DTO entra para fazer essa abstração e mediar
        // esse trânsito de dados internos, sendo possível converter/mapear um objeto
        // da classe original PARA um DTO ou um objeto de uma classe DTO para um da
        // classe original. Adota-se o padrão de criar um DTO para cada necessidade
        // dos métodos da classe controladora para remover ou adicionar campos perti-
        // nentes para cada método sem mexer na nossa classe principal.
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        [Range(1, 600, ErrorMessage = "O filme só pode ter entre 1 e 600 minutos")]
        public int Duracao { get; set; }
        [Range(0, 18, ErrorMessage = "A classificação etária só pode ser de 0 a 18 anos")]
        public int ClassificacaoEtaria { get; set; }
    }
}
