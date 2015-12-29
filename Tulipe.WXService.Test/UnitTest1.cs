using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tulipe.WXService.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AzLog log = new AzLog();
            log.Log("a","b");
        }
    }
}
