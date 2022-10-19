using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Requests
{
    public class ResetSenhaRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
