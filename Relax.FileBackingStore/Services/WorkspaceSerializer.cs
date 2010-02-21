using Caliburn.Core.Metadata;
using Relax.Domain.Models;
using Relax.FileBackingStore.Services.Interfaces;

namespace Relax.FileBackingStore.Services
{
    [PerRequest(typeof (ISerializer<Workspace>))]
    public class WorkspaceSerializer : Serializer<Workspace>
    {
    }
}