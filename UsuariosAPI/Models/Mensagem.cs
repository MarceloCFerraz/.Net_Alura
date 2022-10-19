using MimeKit;

namespace UsuariosAPI.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatarios { get; set; }
        public string assunto { get; set; }
        public string conteudo { get; set; }

        public Mensagem(string username, string destinatario, string assunto, int usuarioID, string conteudo)
        {
            this.Destinatarios = new List<MailboxAddress>();
            this.Destinatarios.Add(new MailboxAddress(username, destinatario));
            this.assunto = assunto;
            this.conteudo = $"https://localhost:7279/ativa?UsuarioID={usuarioID}&CodigoDeAtivacao={conteudo}";
        }
    }
}
