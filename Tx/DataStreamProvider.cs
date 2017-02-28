using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Tiny.EntityDb;

namespace Tx
{
    [TestClass]
    public class DataStreamProviderTester
    {
        
        [TestMethod]
        public void DataStreamProviderTest()
        {
            var stream = new MemoryStream();
            var dataStream = new DataStream(stream);
            var dataStreamProvider = new DataStreamProvider(dataStream);

            Assert.IsFalse(dataStream != dataStreamProvider.DataStream );
            Assert.IsFalse(dataStreamProvider.DataStream.GetStream != stream);
        }

    }
}