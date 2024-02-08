using EntityLayer.Concrete;

namespace BlogProject.ViewModels
{
    public class BlogMailViewModel
    {
        public BlogMailViewModel()
        {
            
        }
        public BlogMailViewModel(Blog blog, int sucsflyMailCount, int errorMailCount, int subscribeCount)
        {
            Blog = blog;
            SucsflyMailCount = sucsflyMailCount;
            ErrorMailCount = errorMailCount;
            SubscribeCount = subscribeCount;
        }

        public Blog Blog { get; set; }
        public int SucsflyMailCount { get; set; }
        public int ErrorMailCount { get; set; }
        public int SubscribeCount { get; set; }

        public KeyValuePair<bool,string> SendStatus { get; set; }

    }
}
