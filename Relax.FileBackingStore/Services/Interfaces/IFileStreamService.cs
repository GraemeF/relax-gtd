using System.IO;

namespace Relax.FileBackingStore.Services.Interfaces
{
    /// <summary>
    /// Provides access to streams in the file system.
    /// </summary>
    public interface IFileStreamService
    {
        Stream GetReadStream(string path);
        Stream GetWriteStream(string path);
    }
}