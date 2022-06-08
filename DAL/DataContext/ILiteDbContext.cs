using LiteDB;

namespace DAL.DataContext
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}