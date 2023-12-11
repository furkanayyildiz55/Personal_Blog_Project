namespace BlogApplication.DTO
{
    public class AjaxResultDTO
    {
        public AjaxResultDTO()
        {
            resultMessages = new List<ResultMessage>();
        }

        public bool status{ get; set; }
        public List<ResultMessage> resultMessages { get; set; }

    }

    public class ResultMessage
    {
        public ResultMessage(string propertyName, string message)
        {
            this.propertyName = propertyName;
            this.message = message;
        }

        public string propertyName { get; set; }
        public string message { get; set; }


    }


}
