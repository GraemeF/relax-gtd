using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract(IsReference = true)]
    [PerRequest(typeof (IAction))]
    public class Action : Item, IAction
    {
        public Action()
        {
            BlockingActions = new ObservableCollection<IAction>();
            Notes = new ObservableCollection<INote>();
        }

        #region Implementation of IAction

        private State _actionState;
        private ICompletion _completion;
        private IGtdContext _context;
        private ICost _cost;
        private IDeadline _deadline;
        private IDeferral _deferral;
        private IDelegation _delegation;
        private Priority _priority;
        private IRepetition _repetition;
        private IReview _review;

        [DataMember]
        public State ActionState
        {
            get { return _actionState; }
            set
            {
                if (_actionState != value)
                {
                    _actionState = value;
                    NotifyPropertyChanged(x => ActionState);
                }
            }
        }

        [DataMember]
        public ObservableCollection<IAction> BlockingActions { get; private set; }

        [DataMember(EmitDefaultValue = false)]
        public IDeadline Deadline
        {
            get { return _deadline; }
            set
            {
                if (_deadline != value)
                {
                    _deadline = value;
                    NotifyPropertyChanged(x => Deadline);
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public IDelegation Delegation
        {
            get { return _delegation; }
            set
            {
                if (_delegation != value)
                {
                    _delegation = value;
                    NotifyPropertyChanged(x => Delegation);
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public IDeferral Deferral
        {
            get { return _deferral; }
            set
            {
                if (_deferral != value)
                {
                    _deferral = value;
                    NotifyPropertyChanged(x => Deferral);
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public ICompletion Completion
        {
            get { return _completion; }
            set
            {
                if (_completion != value)
                {
                    _completion = value;
                    NotifyPropertyChanged(x => Completion);
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public IReview Review
        {
            get { return _review; }
            set
            {
                if (_review != value)
                {
                    _review = value;
                    NotifyPropertyChanged(x => Review);
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public ObservableCollection<INote> Notes { get; private set; }

        [DataMember(EmitDefaultValue = false)]
        public Priority Priority
        {
            get { return _priority; }
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    NotifyPropertyChanged(x => Priority);
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public IRepetition Repetition
        {
            get { return _repetition; }
            set
            {
                if (_repetition != value)
                {
                    _repetition = value;
                    NotifyPropertyChanged(x => Repetition);
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public ICost Cost
        {
            get { return _cost; }
            set
            {
                if (_cost != value)
                {
                    _cost = value;
                    NotifyPropertyChanged(x => Cost);
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public IGtdContext Context
        {
            get { return _context; }
            set
            {
                if (_context != value)
                {
                    _context = value;
                    NotifyPropertyChanged(x => Context);
                }
            }
        }

        #endregion
    }
}