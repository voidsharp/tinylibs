using System.IO;

namespace Tiny.EntityDb
{
    public class DataStreamProvider : IDataStreamProvider
    {
        private IDataStream dataStream;
        public DataStreamProvider(IDataStream ds)
        {
            dataStream = ds;
        }

        public IDataStream DataStream => dataStream;
    }

    public class DataStream : IDataStream
    {
        public DataStream(Stream st)
        {
            stream = st;
        }
        private Stream stream;
        public Stream GetStream => stream;
    }
}
