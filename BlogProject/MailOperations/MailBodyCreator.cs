using BlogProject.Helper;

namespace BlogProject.MailOperations
{
    public static class MailBodyCreator
    {
        public static string Subsribe(string ReceiveEmail,string Guid, string BaseUrl)
        {
            string maiilBody = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>mail başık</title>\r\n</head>\r\n<body style=\"font-family: Arial, sans-serif; padding: 20px; background-color: #f4f4f4; text-align: center;\">\r\n\r\n    <div style=\"max-width: 600px; margin: 0 auto; background-color: #ffffff; padding: 20px; border-radius: 5px; box-shadow: 0 0 10px rgba(0,0,0,0.1);\">\r\n        <h1 style=\"color: #333;\">Merhaba,</h1>\r\n        <p style=\"color: #555;\">Blog bültenine abone oldunuz.</p>\r\n        <p style=\"color: #555;\">Her yeni blog yazısında size Email göndereceğiz</p>\r\n        <p style=\"color: #555;\">Aboneliğiniz için teşekkür ederiz.</p>\r\n       \r\n        <br/>\r\n        <br/>\r\n        \r\n        <p style=\"color: #555;\">Bu işlemi siz yapmadıysanız <a href=\"{BaseUrl}Subscribe/UnSubscribe?Email={ReceiveEmail}&Guid={Guid}\" style=\"color: #4CAF50; text-decoration: underline;\">buraya tıklayın</a> veya bizimle iletişime geçin.</p>\r\n        <a href=\"{BaseUrl}\" style=\"color: #4c66af; text-decoration: underline;\">furkanayyildiz.net</a>\r\n        <br/>\r\n\r\n    </div>\r\n\r\n</body>\r\n</html>";
            return maiilBody ;
        }



    }
}
