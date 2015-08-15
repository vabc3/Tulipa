using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Tulipe
{
    public class TulipeService : ITulipeService
    {
        private IWordGen wordGen;
        private Random rand = new Random();

        public TulipeService(IWordGen wordGen)
        {
            Debug.Assert(wordGen != null, "fai");
            this.wordGen = wordGen;
        }

        public IList<string> CreateGame(int p1c, int p2c)
        {
            Debug.Assert(p1c > 0 && p2c > 0);
            var len = p1c + p2c;

            var pair = wordGen.GetWord();
            Debug.Assert(pair != null);
            Debug.Assert(!string.IsNullOrEmpty(pair.P1));
            Debug.Assert(!string.IsNullOrEmpty(pair.P2));

            var s = new bool[len];
            for (int i = 0; i < p1c; i++) { s[i] = true; }
            for (int i = p1c; i < len; i++) { s[i] = false; }
            for(int i = 0; i< len; i++)
            {
                var j = rand.Next(i, len);
                if (s[j] != s[i])
                {
                    s[j] ^= s[i];
                    s[i] ^= s[j];
                    s[j] ^= s[i];
                }
            }

            return s.Select(t => t ? pair.P1 : pair.P2).ToList();
        }
    }
}
