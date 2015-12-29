using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Tulipe
{
    public class TulipeService : ITulipeService
    {
        private Random rand = new Random();
        private ITulipeDao dao = new DefaultTulipeDao();

        public TulipeService()
        {
        }

        public int CreateGame(string owner ,int p1c, int p2c, string p1, string p2)
        {
            var game = new TulipeGame(p1c,p2c)
            {
                Owner = owner,
                P1 = p1,
                P2 = p2,
                Characters = CreateList(p1c, p2c, p1, p2)
            };

            return dao.Save(game);
        }

        private IList<bool> CreateList(int p1c, int p2c, string p1, string p2)
        {
            Debug.Assert(p1c > 0 && p2c > 0);
            var len = p1c + p2c;

            Debug.Assert(!string.IsNullOrEmpty(p1));
            Debug.Assert(!string.IsNullOrEmpty(p2));

            var s = new bool[len];
            for (int i = 0; i < p1c; i++) { s[i] = true; }
            for (int i = p1c; i < len; i++) { s[i] = false; }
            for (int i = 0; i < len; i++)
            {
                var j = rand.Next(i, len);
                if (s[j] != s[i])
                {
                    s[j] ^= s[i];
                    s[i] ^= s[j];
                    s[j] ^= s[i];
                }
            }

            return s;
        }

        public TulipeGame GetGame(int gid)
        {
            return dao.Get(gid);
        }
    }
}
