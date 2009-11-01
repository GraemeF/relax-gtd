namespace Relax.Infrastructure.Interfaces
{
    public enum State
    {
        /// <summary>
        /// Item has not yet been processed.
        /// </summary>
        Inbox,
        /// <summary>
        /// Committed to complete the item.
        /// </summary>
        Committed,
        /// <summary>
        /// May complete the item at some future date, or might not.
        /// </summary>
        SomedayMaybe,
        /// <summary>
        /// Committed to complete the item but it cannot be completed at present.
        /// </summary>
        Hold
    }
}