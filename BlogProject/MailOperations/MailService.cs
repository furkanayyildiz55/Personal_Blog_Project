using MimeKit;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using EntityLayer.Contrete;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
namespace BlogProject.MailOperations
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        MailLogManager MailLogManager = new MailLogManager(new EfMailLogRepository());
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task<KeyValuePair<bool,string>> SendMailAsync(MailData mailData)
        {
            string SendStatusMessage = "";
            if (mailData.ToEmail == null || mailData.ToEmail == "")
                return new KeyValuePair<bool, string>(false, "Recipient e-mail address is not defined");

            try
            {
                MimeMessage email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.To.Add(MailboxAddress.Parse(mailData.ToEmail));
                email.Subject = mailData.ToEmailSubject;

                BodyBuilder builder = new BodyBuilder();
                builder.HtmlBody = mailData.ToEmailBody;

                email.Body = builder.ToMessageBody();

                using SmtpClient smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.Auto);
                SendStatusMessage += "Code Message: Connect Successful -> ";
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                SendStatusMessage += "Authenticate Successful -> "; 

                await smtp.SendAsync(email);
                SendStatusMessage += "Send Mail Successful.";
                smtp.Disconnect(true);
                return new KeyValuePair<bool,string>(true, SendStatusMessage);
            }
            catch (Exception ex) 
            {
                SendStatusMessage += ex.Message;
                return new KeyValuePair<bool, string>(false, SendStatusMessage);
            }
        }

        public async Task<KeyValuePair<bool, string>> SendMailAsync(MailData mailData ,int errorCycle = 5)
        {
            for (int i = 1; i <= errorCycle; i++)
            {
                var result = await SendMailAsync(mailData);
                MailLog mailLog = new MailLog();
                mailLog.MailReceiver = mailData.ToEmail;
                mailLog.MailBody = mailData.ToEmailBody;
                mailLog.MailSubject = mailData.ToEmailSubject;
                mailLog.SendStatus = result.Key;
                mailLog.LogMessage= result.Value;
                mailLog.ErrorCycle = i;
                MailLogManager.Add(mailLog); 
                if (result.Key)
                {
                    return new KeyValuePair<bool, string>(true, "Mail gönderimi başarılı.");
                }
                Thread.Sleep(5000);
            }
            return new KeyValuePair<bool, string>(false, "Mail gönderimi başarısız");
        }
    }
}
