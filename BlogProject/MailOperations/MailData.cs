namespace BlogProject.MailOperations
{
    public class MailData
    {
        public string ToEmail { get; set; }
        public string ToName { get; set; }
        public string ToEmailSubject { get; set; }
        public string ToEmailBody { get; set; }

        //Blog bazında mail gönderiminde kullanılmaktadır.
        public int? BlogId { get; set; }
        public int? SubscribeId { get; set; }
    }
}
