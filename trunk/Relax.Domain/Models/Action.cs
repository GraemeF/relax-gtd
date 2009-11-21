using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract(IsReference = true)]
    [PerRequest(typeof (IAction))]
    public class Action : Model, IAction
    {
        private static int _nextId = 1;

        public Action()
        {
            Created = DateTime.UtcNow;
            Id = _nextId++;
        }

        #region Implementation of IItem

        private DateTime _created;
        private int _id;
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
                    RaisePropertyChanged("Title");
                }
            }
        }

        [DataMember]
        public DateTime Created
        {
            get { return _created; }
            set
            {
                if (_created != value)
                {
                    _created = value;
                    RaisePropertyChanged("Created");
                }
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        #endregion

        #region Implementation of IAction

        private State _actionState;
        private ObservableCollection<IAction> _blockingActions = new ObservableCollection<IAction>();
        private ICompletion _completion;
        private IContext _context;
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
                    RaisePropertyChanged("ActionState");
                }
            }
        }

        [DataMember]
        public ObservableCollection<IAction> BlockingActions
        {
            get { return _blockingActions; }
            set
            {
                if (_blockingActions != value)
                {
                    _blockingActions = value;
                    RaisePropertyChanged("BlockingActions");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public IDeadline Deadline
        {
            get { return _deadline; }
            set
            {
                if (_deadline != value)
                {
                    _deadline = value;
                    RaisePropertyChanged("Deadline");
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
                    RaisePropertyChanged("Delegation");
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
                    RaisePropertyChanged("Deferral");
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
                    RaisePropertyChanged("Completion");
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
                    RaisePropertyChanged("Review");
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
                    RaisePropertyChanged("Notes");
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
                    RaisePropertyChanged("Priority");
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
                    RaisePropertyChanged("Repetition");
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
                    RaisePropertyChanged("Cost");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public IContext Context
        {
            get { return _context; }
            set
            {
                if (_context != value)
                {
                    _context = value;
                    RaisePropertyChanged("Context");
                }
            }
        }

        #endregion
    }
}