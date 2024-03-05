using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Dependencies.BringMethodUnderTest.ParameteriseMethod.Lab_Hard
{
    public class EmailService
    {

        public async Task<bool> Send(MailMessage email)
        {
            using var awsClient = new AmazonSimpleEmailServiceClient(RegionEndpoint.APSoutheast2);
            var request = BuildSendEmailRequest(email);
            await SendAwsEmail(awsClient, request);
            return true;
        }

        private static async Task SendAwsEmail(IAmazonSimpleEmailService client, SendEmailRequest request)
        {
            try
            {
                var _ = await client.SendEmailAsync(request);
            }
            catch (AmazonSimpleEmailServiceException ex)
            {
                throw new ApplicationException("Sending email via AWS SES failed.", ex);
            }
        }

        private static SendEmailRequest BuildSendEmailRequest(MailMessage email)
        {
            return new SendEmailRequest
            {
                Source = email.From?.Address,
                Destination = new Destination
                {
                    ToAddresses = new List<string> { email.To[0].Address }
                },
                Message = new Message
                {
                    Subject = new Content(email.Subject),
                    Body = new Body
                    {
                        Text = new Content
                        {
                            Charset = "UTF-8",
                            Data = email.Body
                        }
                    }
                }
            };
        }
    }

}
