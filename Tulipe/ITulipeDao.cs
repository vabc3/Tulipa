namespace Tulipe
{
    public interface ITulipeDao
    {
        int Save(TulipeGame game);
        TulipeGame Get(int id);
        int Count { get; }
    }
}
