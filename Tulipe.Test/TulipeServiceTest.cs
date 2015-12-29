using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tulipe.Test
{
    [TestClass]
    public class TulipeServiceTest
    {
        ITulipeService service = new TulipeService();

        [TestMethod]
        public void TestCreateGame()
        {
            const int p1n = 2;
            const int p2n = 9;
            var l1 = TestRound(p1n, p2n);
            var l2 = TestRound(p1n, p2n);

            Assert.IsFalse(l1.SequenceEqual(l2));
        }

        [TestMethod]
        public void TestGame()
        {
            var id = service.CreateGame("o1", 2, 3, "p1", "p2");
            var game = service.GetGame(id);
            Assert.AreEqual("o1", game.Owner);

            Parallel.For(0, 10, (i) =>
            {
                bool b; string s;
                var j = game.Join("user" + i, out b, out s);
                System.Console.WriteLine("{0}:{1}  => {2}, {3}", i, j, b, s);
            });

        }

        private IList<string> TestRound(int p1n, int p2n)
        {
            var id = service.CreateGame("owner1", p1n, p2n, "p1", "p2");
            var list = service.GetGame(id).Words;
            int p1c = 0;
            int p2c = 0;
            foreach (var item in list)
            {
                if (item == "p1")
                {
                    p1c++;
                }
                else if (item == "p2")
                {
                    p2c++;
                }
                else
                {
                    Assert.Fail("Should not produce extra word:" + item);
                }
            }

            Assert.AreEqual(p1n, p1c);
            Assert.AreEqual(p2n, p2c);

            return list;
        }
    }
}
