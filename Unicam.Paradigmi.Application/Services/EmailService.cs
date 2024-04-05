using Microsoft.Extensions.Options;
using Microsoft.Graph.Models;
using Microsoft.Graph;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Options;
using Microsoft.Graph.Users.Item.SendMail;
using Azure.Identity;


namespace Unicam.Paradigmi.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailOption _emailOption;
        public EmailService(IOptions<EmailOption> emailOptions)
        {
            _emailOption = emailOptions.Value;
        }

        public async Task SendEmailAsync(string subject, string body, string email)
        {
            //Prende le credenziali del client da appsetting
            var clientCredential = new ClientSecretCredential(_emailOption.TenantId
                , _emailOption.ClientId
                , _emailOption.ClientSecret
                );
            var client = new GraphServiceClient(clientCredential);

            //Aggiungo l'indirizzo email del destinatario
            List<Recipient> recipients = new List<Recipient>();
                recipients.Add(new Recipient()
                {
                    EmailAddress = new EmailAddress()
                    {
                        Address = email
                    }
                });

            //Creazione del messaggio
            Message message = new()
            {
                Subject = subject,
                Body = new ItemBody
                {
                    ContentType = BodyType.Text,
                    Content = body
                },
                ToRecipients = recipients
            };

            var postRequestBody = new SendMailPostRequestBody();
            postRequestBody.Message = message;
            postRequestBody.SaveToSentItems = true;

            //Invia l'email
            await client.Users[_emailOption.From]
                .SendMail.PostAsync(postRequestBody);

        }
    }
}
