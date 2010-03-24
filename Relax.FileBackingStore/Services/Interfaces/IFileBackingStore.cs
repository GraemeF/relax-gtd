using Relax.Infrastructure.Services.Interfaces;

namespace Relax.FileBackingStore.Services.Interfaces
{
    public interface IFileBackingStore : IBackingStore
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        string Path { get; set; }
    }
}