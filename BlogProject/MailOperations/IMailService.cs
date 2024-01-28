namespace BlogProject.MailOperations
{
    public interface IMailService
    {
        Task SendMailAsync(MailData mailData);
    }
}
