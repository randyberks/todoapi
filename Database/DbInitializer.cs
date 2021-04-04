namespace TodoApi.Database
{
    public class DbInitializer
    {
        public static void Initialize(DBContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}