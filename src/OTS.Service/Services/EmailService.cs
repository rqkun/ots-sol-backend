
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using OTS.Data.Models;
using OTS.Service.Interfaces;

namespace OTS.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailModel _emailModel;

        public EmailService(EmailModel emailModel)
        {
            this._emailModel = emailModel;
        }

        public async Task <bool> SendEmail(MessageModel message)
        {
            var emailMessage = CreateEmailMessage(message);
            return await Send(emailMessage);

        }

        private MimeMessage CreateEmailMessage(MessageModel message)
        { 
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailModel.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }

        private Task<bool> Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailModel.SmtpServer, _emailModel.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailModel.UserName, _emailModel.Password);

                client.Send(mailMessage);
                return Task.FromResult(true);
            }
            catch(Exception e)
            {
                //log an error message or throw an exception or both.
                throw ;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
