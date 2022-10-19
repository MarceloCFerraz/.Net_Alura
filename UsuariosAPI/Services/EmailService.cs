using MailKit.Net.Smtp;
using MimeKit;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public  void EnviarEmailConfirmacao(string userName, string destinatarios, string assunto, int usuarioID, string conteudo)
        {
            Mensagem mensagem = new Mensagem(userName, destinatarios, assunto, usuarioID, conteudo.ToString());
            MimeMessage mensagemEmail = CriaCorpoDoEmail(mensagem);
            EnviarEmail(mensagemEmail);
        }

        private void EnviarEmail(MimeMessage mensagemEmail)
        {
            using(var client = new SmtpClient())
            {
                try
                {
                    client.Connect(
                        _configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"),
                        true
                    );
                    // Linha abaixo desatualizada. O Google exige autenticação com mais do que login e senha.
                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    client.Authenticate(
                        _configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password")
                    );
                    client.Send(mensagemEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }

            };
        }

        private MimeMessage CriaCorpoDoEmail(Mensagem mensagem)
        {
            var mensagemEmail = new MimeMessage();
            mensagemEmail.From.Add(
                new MailboxAddress(
                    "host", 
                    _configuration.GetValue<string>("EmailSettings:From")
                )
            );
            mensagemEmail.To.AddRange(mensagem.Destinatarios);
            mensagemEmail.Subject = mensagem.assunto;
            mensagemEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.conteudo
            };

            return mensagemEmail;
        }
    }
}
