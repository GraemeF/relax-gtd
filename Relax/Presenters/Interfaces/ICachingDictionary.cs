namespace Relax.Presenters.Interfaces
{
    public interface ICachingDictionary<TParameter, TItem>
    {
        TItem GetOrCreate(TParameter parameter);
    }
}