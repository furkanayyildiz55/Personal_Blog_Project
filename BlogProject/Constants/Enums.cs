namespace BlogProject.Constants
{
    public static class Enums
    {
        public  enum ObjectStatus
        {
            Active = 1,
            Passive= 0
        }

        public enum Order
        {
            MostRead = 1,
            MostCommented = 2,
            NewestUploadDate = 3,
            OldestUploadDate = 4,
        }
    }
}
