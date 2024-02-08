namespace BlogProject.Constants
{
    public static class EnumsB
    {
        public  enum ObjectStatus
        {
            Passive = 0,
            Active = 1,
            Deleted= 2
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
