using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using System.Diagnostics;

namespace Relax.Domain.Models
{
    [DataContract(IsReference = true)]
    [PerRequest(typeof (IAction))]
    [DebuggerDisplay("Title = {Title}")]
    public class Action : Item, IAction
    {
        public Action()
        {
            BlockingActions = new ObservableCollection<IAction>();
            Notes = new ObservableCollection<INote>();
        }

        #region Implementation of IAction

        private State _actionState;
        private DateTime? _completed;

        private IGtdContext _context;
        private DateTime? _deadlineDate;
        private DateTime? _deferUntil;
        private IDelegation _delegation;
        private EnergyLevel? _mentalEnergyRequired;
        private EnergyLevel? _physicalEnergyRequired;
        private Priority _priority;
        private IRepetition _repetition;
        private IReview _review;
        private TimeSpan? _timeRequired;

        [DataMember]
        public DateTime? DeferUntil
        {
            get { return _deferUntil; }
            set
            {
                if (value != _deferUntil)
                {
                    _deferUntil = value;
                    NotifyPropertyChanged(x => DeferUntil);
                }
            }
        }

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
        public DateTime? Deadline
        {
            get { return _deadlineDate; }
            set
            {
                if (value != _deadlineDate)
                {
                    _deadlineDate = value;
                    NotifyPropertyChanged(x => Deadline);
                }
            }
        }

        [DataMember]
        public DateTime? CompletedDate
        {
            get { return _completed; }
            set
            {
                if (value > DateTime.UtcNow)
                    throw new ArgumentOutOfRangeException("value", value,
                                                          "The date and time of completion must not be in the future.");

                if (value != _completed)
                {
                    _completed = value;
                    NotifyPropertyChanged(x => CompletedDate);
                }
            }
        }

        [DataMember]
        public EnergyLevel? MentalEnergyRequired
        {
            get { return _mentalEnergyRequired; }
            set
            {
                if (value != _mentalEnergyRequired)
                {
                    _mentalEnergyRequired = value;
                    NotifyPropertyChanged(x => MentalEnergyRequired);
                }
            }
        }

        [DataMember]
        public TimeSpan? TimeRequired
        {
            get { return _timeRequired; }
            set
            {
                if (value != _timeRequired)
                {
                    _timeRequired = value;
                    NotifyPropertyChanged(x => TimeRequired);
                }
            }
        }

        [DataMember]
        public EnergyLevel? PhysicalEnergyRequired
        {
            get { return _physicalEnergyRequired; }
            set
            {
                if (value != _physicalEnergyRequired)
                {
                    _physicalEnergyRequired = value;
                    NotifyPropertyChanged(x => PhysicalEnergyRequired);
                }
            }
        }

        [DataMember]
        public ObservableCollection<IAction> BlockingActions { get; private set; }

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