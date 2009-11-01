namespace Relax.Infrastructure.Interfaces
{
    public interface IBackingStore
    {
        IFactory Factory { get; }

        void Save();
    }
}