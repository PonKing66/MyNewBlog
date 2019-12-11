using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestXml;

namespace UnitTestMyNewBlog
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        [Obsolete]
        public void TestMethod()
        {
            MyXml mx = new MyXml();
            OperateDataBase op = new OperateDataBase();
            string path = "F:\\visual-stdio-2019\\asp_core_web_4\\练习\\TestXml\\TestXml\\ArticlesData\\world2.xml";
            mx.GetNewItems(path);
            //op.ExceRead(mx.GetNewItems(path));
        }
    }
}
