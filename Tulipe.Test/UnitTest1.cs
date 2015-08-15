using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tulipe.Test
{
    [TestClass]
    public class UnitTest1
    {
        ITulipeService service = new TulipeService(new FakeWordGen());

        [TestMethod]
        public void TestCreateGame()
        {
            const int p1n = 2;
            const int p2n = 9;
            var l1 = TestRound(p1n, p2n);
            var l2 = TestRound(p1n, p2n);

            Assert.IsFalse(l1.SequenceEqual(l2));
        }

        private IList<string> TestRound(int p1n, int p2n)
        {
            var list = service.CreateGame(p1n, p2n);
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

    class FakeWordGen : IWordGen
    {
        private static WordPair pair = new WordPair { P1 = "p1", P2 = "p2" };

        public WordPair GetWord() => pair;
    }

}
