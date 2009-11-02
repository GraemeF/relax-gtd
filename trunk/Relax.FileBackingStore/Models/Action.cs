using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.FileBackingStore.Models
{
    [DataContract(IsReference = true)]
    public class Action : Model, IAction
    {
        private static int _NextId = 1;

        public Action()
        {
            Created = DateTime.UtcNow;
            Id = _NextId++;
        }

        #region Implementation of IItem

        private DateTime _Created;
        private int _Id;
        private string _Title;

        [DataMember]
        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        [DataMember]
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if (_Created != value)
                {
                    _Created = value;
                    RaisePropertyChanged("Created");
                }
            }
        }

        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        #endregion

        #region Implementation of IAction

        private State _actionState;
        private ObservableCollection<IAction> _BlockingActions = new ObservableCollection<IAction>();
        private ICompletion _Completion;
        private IContext _Context;
        private ICost _Cost;
        private IDeadline _Deadline;
        private IDeferral _Deferral;
        private IDelegation _Delegation;
        private INotes _Notes;
        private IPriority _Priority;
        private IRepetition _Repetition;
        private IReview _Review;

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
            get { return _BlockingActions; }
            set
            {
                if (_BlockingActions != value)
                {
                    _BlockingActions = value;
                    RaisePropertyChanged("BlockingActions");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public IDeadline Deadline
        {
            get { return _Deadline; }
            set
            {
                if (_Deadline != value)
                {
                    _Deadline = value;
                    RaisePropertyChanged("Deadline");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public IDelegation Delegation
        {
            get { return _Delegation; }
            set
            {
                if (_Delegation != value)
                {
                    _Delegation = value;
                    RaisePropertyChanged("Delegation");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public IDeferral Deferral
        {
            get { return _Deferral; }
            set
            {
                if (_Deferral != value)
                {
                    _Deferral = value;
                    RaisePropertyChanged("Deferral");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public ICompletion Completion
        {
            get { return _Completion; }
            set
            {
                if (_Completion != value)
                {
                    _Completion = value;
                    RaisePropertyChanged("Completion");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public IReview Review
        {
            get { return _Review; }
            set
            {
                if (_Review != value)
                {
                    _Review = value;
                    RaisePropertyChanged("Review");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public INotes Notes
        {
            get { return _Notes; }
            set
            {
                if (_Notes != value)
                {
                    _Notes = value;
                    RaisePropertyChanged("Notes");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public IPriority Priority
        {
            get { return _Priority; }
            set
            {
                if (_Priority != value)
                {
                    _Priority = value;
                    RaisePropertyChanged("Priority");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public IRepetition Repetition
        {
            get { return _Repetition; }
            set
            {
                if (_Repetition != value)
                {
                    _Repetition = value;
                    RaisePropertyChanged("Repetition");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public ICost Cost
        {
            get { return _Cost; }
            set
            {
                if (_Cost != value)
                {
                    _Cost = value;
                    RaisePropertyChanged("Cost");
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public IContext Context
        {
            get { return _Context; }
            set
            {
                if (_Context != value)
                {
                    _Context = value;
                    RaisePropertyChanged("Context");
                }
            }
        }

        #endregion
    }
}