using System.Collections.Generic;

namespace Tulipe
{
    public interface ITulipeService
    {
        IList<string> CreateGame(int p1c, int p2c);
    }
}
