using System.Collections.Generic;

namespace Tulipe
{
    public interface ITulipeService
    {
        int CreateGame(string owner, int p1c, int p2c, string p1, string p2);
        TulipeGame GetGame(int id);
    }
}
