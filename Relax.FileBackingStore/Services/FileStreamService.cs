using System.IO;
using Caliburn.Core.Metadata;
using Relax.FileBackingStore.Services.Interfaces;
using Relax.Infrastructure.Helpers;

namespace Relax.FileBackingStore.Services
{
    /// <summary>
    /// Gets file streams for reading and writing to a file.
    /// </summary>
    [PerRequest(typeof (IFileStreamService))]
    public class FileStreamService : IFileStreamService
    {
        #region IFileStreamService Members

        public Stream GetReadStream(string path)
        {
            return new FileStream(path, FileMode.Open);
        }

        [NoCoverage]
        public Stream GetWriteStream(string path)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            return new FileStream(path, FileMode.Create);
        }

        #endregion
    }
}