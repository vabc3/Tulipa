using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulipe.Test
{
    [TestClass]
    public class WordGenTest
    {
        [TestMethod]
        public void TestWordTool()
        {
            var wt = new WordTool();
            wt.GetRelated();
        }
    }
}
