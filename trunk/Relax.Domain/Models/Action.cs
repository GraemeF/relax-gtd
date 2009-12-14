using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract(IsReference = true)]
    [PerRequest(typeof (IAction))]
    public class Action : IAction
    {
        public Action()
        {
            BlockingActions = new ObservableCollection<IAction>();
            Created = DateTime.UtcNow;
        }

        #region Implementation of IItem

        private string _title;

        [DataMember]
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    PropertyChanged.Raise(x => Title);
                }
            }
        }

        [DataMember]
        public DateTime Created { get; private set; }

        #endregion

        #region Implementation of IAction

        private State _actionState;
        private ICompletion _completion;
        private IGtdContext _context;
        private ICost _cost;
        private IDeadline _deadline;
        private IDeferral _deferral;
        private IDelegation _delegation;
        private INotes _notes;
        private IPriority _priority;
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
                    PropertyChanged.Raise(x => ActionState);
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
                    PropertyChanged.Raise(x => Deadline);
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
                    PropertyChanged.Raise(x => Delegation);
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
                    PropertyChanged.Raise(x => Deferral);
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
                    PropertyChanged.Raise(x => Completion);
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
                    PropertyChanged.Raise(x => Review);
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public INotes Notes
        {
            get { return _notes; }
            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    PropertyChanged.Raise(x => Notes);
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public IPriority Priority
        {
            get { return _priority; }
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    PropertyChanged.Raise(x => Priority);
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
                    PropertyChanged.Raise(x => Repetition);
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
                    PropertyChanged.Raise(x => Cost);
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
                    PropertyChanged.Raise(x => Context);
                }
            }
        }

        #endregion

        #region IAction Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}