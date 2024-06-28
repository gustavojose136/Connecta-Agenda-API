using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Connect_agenda_models.Models.Utils;

namespace Connect_agenda_services.Services
{
    public class SendEmailService
    {
        private readonly IConfiguration _configuration;
        public SendEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> PostEmail(EmailModel email)
        {
            try
            {
                var emailConnection = _configuration.GetSection("EmailConnection");

                EmailConnectionModel emailConnectionModel = new EmailConnectionModel
                {
                    Host = emailConnection["Host"],
                    Port = int.Parse(emailConnection["Port"]),
                    User = emailConnection["User"],
                    Password = emailConnection["Password"]
                };

                // Configurações do servidor SMTP
                string host = emailConnectionModel.Host;
                int porta = emailConnectionModel.Port;
                string usuario = emailConnectionModel.User;
                string senha = emailConnectionModel.Password;

                // Criação do objeto SmtpClient
                using (SmtpClient clienteSmtp = new SmtpClient(host, porta))
                {
                    clienteSmtp.Credentials = new NetworkCredential(usuario, senha);
                    clienteSmtp.EnableSsl = true;

                    // Criação do objeto MailMessage
                    using (MailMessage mensagem = new MailMessage(usuario, email.Emails, email.Assunto, email.Body))
                    {
                        mensagem.IsBodyHtml = true;

                        // Envio do e-mail
                        await clienteSmtp.SendMailAsync(mensagem);
                    }
                }

                return "E-mail enviado com sucesso.";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao enviar o e-mail de confirmação.", ex);
            }
        }
    }
}
