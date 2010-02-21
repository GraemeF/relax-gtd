using System;
using System.Windows;

namespace Relax.Infrastructure.Helpers
{
    /// <summary>
    /// A common weak event listener which can be used for different kinds of events.
    /// </summary>
    /// <typeparam name="TEventArgs">The <see cref="EventArgs"/> type for the event.</typeparam>
    [NoCoverage]
    public class WeakEventListener<TEventArgs> : IWeakEventListener where TEventArgs : EventArgs
    {
        private readonly EventHandler<TEventArgs> _realHander;

        /// <summary>
        /// Initializes a new instance of the WeakEventListener class.
        /// </summary>
        /// <param name="handler">The handler for the event.</param>
        public WeakEventListener(EventHandler<TEventArgs> handler)
        {
            if (handler == null)
                throw new ArgumentNullException("handler");

            _realHander = handler;
        }

        #region IWeakEventListener Members

        /// <summary>
        /// Receives events from the centralized event manager.
        /// </summary>
        /// <param name="managerType">The type of the <see cref="WeakEventManager"/> calling this method.</param>
        /// <param name="sender">Object that originated the event.</param>
        /// <param name="e">Event data.</param>
        /// <returns>
        /// <c>true</c> if the listener handled the event. It is considered an error by the <see cref="WeakEventManager"/> handling in WPF to register a listener for an event that the listener does not handle. Regardless, the method should return <c>false</c> if it receives an event that it does not recognize or handle.
        /// </returns>
        bool IWeakEventListener.ReceiveWeakEvent(Type managerType, Object sender, EventArgs e)
        {
            var realArgs = (TEventArgs) e;

            _realHander(sender, realArgs);

            return true;
        }

        #endregion
    }
}