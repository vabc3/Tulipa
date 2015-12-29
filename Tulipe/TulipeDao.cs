using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Tulipe
{
    public class DefaultTulipeDao : ITulipeDao
    {
        private int cid = -1;
        private IDictionary<int, TulipeGame> dic = new ConcurrentDictionary<int, TulipeGame>();

        public int Count => cid + 1;

        public int Save(TulipeGame game)
        {
            var id = Interlocked.Increment(ref this.cid);
            game.Id = id;
            dic[id] = game;

            return id;
        }

        public TulipeGame Get(int id)
        {
            TulipeGame game;
            this.dic.TryGetValue(id, out game);
            return game;
        }
    }
}
