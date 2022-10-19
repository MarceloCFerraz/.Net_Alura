using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Requests
{
    public class ResetSenhaConfirmRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        public string ReSenha { get; set; }
        [Required]
        public string ResetToken { get; set; }
    }
}
