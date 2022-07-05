using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace ASPtest
{
    public class SendingMail
    {
        public static async Task sendMailAsync()
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("CarmenatWork", "carmen.asptest@outlook.com"));
            message.To.Add(MailboxAddress.Parse("caramella.home@gmail.com"));
            message.Subject = "Testing";
            message.Body = new TextPart("plain")
            {
                Text = @"Yes,
                 Hello!
                 This is dog!"
            };

            SmtpClient client = new SmtpClient();
            try
            {
                await client.Connect("smtp-mail.outlook.com", 465, true);
                await client.Authenticate("carmen.asptest@outlook.com", "MyPassword123");
                await client.Send(message);
                System.Diagnostics.Debug.WriteLine("You did something!");
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
