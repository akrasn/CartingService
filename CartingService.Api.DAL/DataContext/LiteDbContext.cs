using LiteDB;

namespace DAL.DataContext
{
    public class LiteDbContext : ILiteDbContext
    {
        public LiteDatabase Database { get; }

        public LiteDbContext()
        {
            Database = new LiteDatabase("LiteDb/LiteDb.db");
        }
    }
}
