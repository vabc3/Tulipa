using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Tulipe.Test
{
    [TestClass]
    public class TulipeDaoTest
    {
        [TestMethod]
        public void TestDefaultDao()
        {
            ITulipeDao dao = new DefaultTulipeDao();
            int rec = -1;
            Parallel.For(0, 1000, i =>
            {
                var id = dao.Save(new TulipeGame(1, i));
                if (i == 500) rec = id;
            });

            Assert.AreEqual(1000, dao.Count);
            Assert.AreNotEqual(-1, rec);
            Assert.AreEqual(500, dao.Get(rec).P2C);
        }
    }
}
