using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Tulipe
{
    public class TulipeGame
    {
        public TulipeGame(int p1c,int p2c)
        {
            this.P1C = p1c;
            this.P2C = p2c;
            this.Users = new string[p1c + p2c];
        }

        public int Id { get; set; }
        public string Owner { get; set; }
        public string P1 { get; set; }
        public string P2 { get; set; }
        public int P1C { get; set; }
        public int P2C { get; set; }

        public IList<bool> Characters { get; set; }
        public IList<string> Words => Characters.Select(t => t ? P1 : P2).ToList();
        public IList<string> Users { get; set; }
        public int UserCount => cid + 1;


        private int cid = -1;

        public bool Join(string userName, out bool character, out string word)
        {
            character = false;
            word = null;
            var index = Users.IndexOf(userName);
            if (index == -1)
            {
                lock (Users)
                {
                    index = Users.IndexOf(userName);

                    if (index == -1)
                    {
                        index = Interlocked.Increment(ref this.cid);
                        if (index >= P1C + P2C)
                        {
                            return false;
                        }
                        Users[index] = userName;
                    }
                }
            }

            character = Characters[index];
            word = character ? P1 : P2;
            return true;
        }
    }
}
