using MailKit.Net.Smtp;
using MimeKit;
using NETCore.MailKit.Core;
using SistemaDeLogin.ApplicationIdentity.Interfaces;
using SistemaDeLogin.Infra.CrossCutting.Identity.ConfigEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SistemaDeLogin.ApplicationIdentity.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly EmailConfig _emailConfig;

        public EmailServices(EmailConfig emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public void SendEmail(Message message) 
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message) 
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }

        private void Send(MimeMessage mailMessage) 
        {
            using var client = new SmtpClient();
            try 
            {
                client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.Username, _emailConfig.Password);

                client.Send(mailMessage);
            }
            catch
            (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally 
            {
                client.Disconnect(true);
                client.Dispose(); 
            }
        }
    }
}
