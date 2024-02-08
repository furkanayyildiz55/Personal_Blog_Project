namespace BlogProject.MailOperations
{
    public interface IMailService
    {
        Task<KeyValuePair<bool,string>> SendMailAsync(MailData mailData);
        Task<KeyValuePair<bool,string>> SendMailAsync(MailData mailData , int errorCycle);
        Task<KeyValuePair<bool,string>> SenMailsAsync(List<MailData> mailDatas , int errorCycle);
    }
}
