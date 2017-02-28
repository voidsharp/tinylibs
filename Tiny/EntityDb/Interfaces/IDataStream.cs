using System.IO;

namespace Tiny.EntityDb
{
    public interface IDataStream
    {
        Stream GetStream { get; }

    }
}