using Relax.Infrastructure.Interfaces;

namespace Relax.FileBackingStore.Services
{
    public class Factory : IFactory
    {
        private readonly Autofac.IContext _container;

        public Factory(Autofac.IContext container)
        {
            _container = container;
        }

        #region IFactory Members

        public IAction CreateAction()
        {
            return _container.Resolve<IAction>();
        }

        public ICompletion CreateCompletion()
        {
            return _container.Resolve<ICompletion>();
        }

        public IDeadline CreateDeadline()
        {
            return _container.Resolve<IDeadline>();
        }

        public IDeferral CreateDeferral()
        {
            return _container.Resolve<IDeferral>();
        }

        public IDelegation CreateDelegation()
        {
            return _container.Resolve<IDelegation>();
        }

        public IReview CreateReview()
        {
            return _container.Resolve<IReview>();
        }

        public ICost CreateCost()
        {
            return _container.Resolve<ICost>();
        }

        public INotes CreateNotes()
        {
            return _container.Resolve<INotes>();
        }

        #endregion
    }
}