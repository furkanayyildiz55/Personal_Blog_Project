namespace BlogProject.MailOperations
{
    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        public bool ToSend { get; set; }
        public int AcceptableError { get; set; }
    }
}
