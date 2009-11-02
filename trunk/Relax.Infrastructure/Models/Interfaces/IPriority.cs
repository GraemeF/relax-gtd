namespace Relax.Infrastructure.Models.Interfaces
{
    /// <summary>
    /// Something that can be prioritised.
    /// </summary>
    public interface IPriority
    {
        Priority? Priority { get; set; }
    }
}