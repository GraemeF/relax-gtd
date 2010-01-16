using System;
using Caliburn.Testability.Extensions;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using Moq;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Action = Relax.Domain.Models.Action;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class ActionTestFixture
    {
        [VerifyContract]
        public readonly IContract ActionState__MeetsPropertyContract = new AccessorContract<Action, State>
                                                                           {
                                                                               PropertyName = "ActionState",
                                                                               AcceptNullValue = false,
                                                                               ValidValues =
                                                                                   {
                                                                                       State.Committed,
                                                                                       State.Hold,
                                                                                       State.Inbox,
                                                                                       State.SomedayMaybe
                                                                                   }
                                                                           };

        [VerifyContract]
        public readonly IContract CompletedDate__MeetsPropertyContract = new AccessorContract<Action, DateTime?>
                                                                             {
                                                                                 PropertyName = "CompletedDate",
                                                                                 AcceptNullValue = true,
                                                                                 ValidValues =
                                                                                     {
                                                                                         DateTime.UtcNow,
                                                                                         DateTime.Today
                                                                                     },
                                                                                 InvalidValues =
                                                                                     {
                                                                                         {
                                                                                             typeof (
                                                                                             ArgumentOutOfRangeException
                                                                                             ),
                                                                                             DateTime.MaxValue
                                                                                             }
                                                                                     }
                                                                             };

        [VerifyContract]
        public readonly IContract Context__MeetsPropertyContract = new AccessorContract<Action, IGtdContext>
                                                                       {
                                                                           PropertyName = "Context",
                                                                           AcceptNullValue = true,
                                                                           ValidValues =
                                                                               {
                                                                                   new Mock<IGtdContext>().Object
                                                                               }
                                                                       };

        [VerifyContract]
        public readonly IContract Deadline__MeetsPropertyContract = new AccessorContract<Action, DateTime?>
                                                                        {
                                                                            PropertyName = "Deadline",
                                                                            AcceptNullValue = true,
                                                                            ValidValues =
                                                                                {
                                                                                    DateTime.UtcNow,
                                                                                    DateTime.Today,
                                                                                    DateTime.MinValue,
                                                                                    DateTime.MaxValue
                                                                                }
                                                                        };

        [VerifyContract]
        public readonly IContract DeferUntil__MeetsPropertyContract = new AccessorContract<Action, DateTime?>
                                                                          {
                                                                              PropertyName = "DeferUntil",
                                                                              AcceptNullValue = true,
                                                                              ValidValues =
                                                                                  {
                                                                                      DateTime.UtcNow,
                                                                                      DateTime.Today,
                                                                                      DateTime.MinValue,
                                                                                      DateTime.MaxValue
                                                                                  }
                                                                          };

        [VerifyContract]
        public readonly IContract Delegation__MeetsPropertyContract = new AccessorContract<Action, IDelegation>
                                                                          {
                                                                              PropertyName = "Delegation",
                                                                              AcceptNullValue = true,
                                                                              ValidValues =
                                                                                  {
                                                                                      new Mock<IDelegation>().Object
                                                                                  }
                                                                          };

        [VerifyContract]
        public readonly IContract MentalEnergyRequired__MeetsPropertyContract = new AccessorContract
            <Action, EnergyLevel>
                                                                                    {
                                                                                        PropertyName =
                                                                                            "MentalEnergyRequired",
                                                                                        AcceptNullValue = true,
                                                                                        ValidValues =
                                                                                            {
                                                                                                EnergyLevel.None,
                                                                                                EnergyLevel.Low,
                                                                                                EnergyLevel.Medium,
                                                                                                EnergyLevel.High
                                                                                            }
                                                                                    };

        [VerifyContract]
        public readonly IContract PhysicalEnergyRequired__MeetsPropertyContract = new AccessorContract
            <Action, EnergyLevel>
                                                                                      {
                                                                                          PropertyName =
                                                                                              "PhysicalEnergyRequired",
                                                                                          AcceptNullValue = true,
                                                                                          ValidValues =
                                                                                              {
                                                                                                  EnergyLevel.None,
                                                                                                  EnergyLevel.Low,
                                                                                                  EnergyLevel.Medium,
                                                                                                  EnergyLevel.High
                                                                                              }
                                                                                      };

        [VerifyContract]
        public readonly IContract Priority__MeetsPropertyContract = new AccessorContract<Action, Priority>
                                                                        {
                                                                            PropertyName = "Priority",
                                                                            AcceptNullValue = false,
                                                                            ValidValues =
                                                                                {
                                                                                    Priority.None,
                                                                                    Priority.Could,
                                                                                    Priority.Should,
                                                                                    Priority.Would,
                                                                                    Priority.Must
                                                                                }
                                                                        };

        [VerifyContract]
        public readonly IContract Repetition__MeetsPropertyContract = new AccessorContract<Action, IRepetition>
                                                                          {
                                                                              PropertyName = "Repetition",
                                                                              AcceptNullValue = true,
                                                                              ValidValues =
                                                                                  {
                                                                                      new Mock<IRepetition>().Object
                                                                                  }
                                                                          };

        [VerifyContract]
        public readonly IContract Review__MeetsPropertyContract = new AccessorContract<Action, IReview>
                                                                      {
                                                                          PropertyName = "Review",
                                                                          AcceptNullValue = true,
                                                                          ValidValues =
                                                                              {
                                                                                  new Mock<IReview>().Object
                                                                              }
                                                                      };

        [VerifyContract]
        public readonly IContract TimeRequired__MeetsPropertyContract = new AccessorContract<Action, TimeSpan>
                                                                            {
                                                                                PropertyName = "TimeRequired",
                                                                                AcceptNullValue = false,
                                                                                ValidValues =
                                                                                    {
                                                                                        TimeSpan.FromHours(1),
                                                                                        TimeSpan.MinValue
                                                                                    }
                                                                            };

        [Test]
        public void TimeRequired_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.TimeRequired).When(
                () => test.TimeRequired = TimeSpan.FromMinutes(30));
        }

        [Test]
        public void MentalEnergyRequired_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.MentalEnergyRequired).When(
                () => test.MentalEnergyRequired = EnergyLevel.Medium);
        }

        [Test]
        public void PhysicalEnergyRequired_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.PhysicalEnergyRequired).When(
                () => test.PhysicalEnergyRequired = EnergyLevel.Medium);
        }

        [Test]
        public void ActionState_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.ActionState).When(
                () => test.ActionState = State.SomedayMaybe);
        }

        [Test]
        public void ActionState_Initially_IsInbox()
        {
            var test = new Action();

            Assert.AreEqual(State.Inbox, test.ActionState);
        }

        [Test]
        public void BlockingActions_Initially_IsEmpty()
        {
            Assert.IsEmpty(new Action().BlockingActions);
        }

        [Test]
        public void Notes_Initially_IsEmpty()
        {
            Assert.IsEmpty(new Action().Notes);
        }

        [Test]
        public void Deadline_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Deadline).When(() => test.Deadline = DateTime.UtcNow);
        }

        [Test]
        public void Delegation_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Delegation).When(
                () => test.Delegation = new Mock<IDelegation>().Object);
        }

        [Test]
        public void DeferUntil_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.DeferUntil).When(() => test.DeferUntil = DateTime.UtcNow);
        }

        [Test]
        public void CompletedDate_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.CompletedDate).When(
                () => test.CompletedDate = DateTime.UtcNow);
        }

        [Test]
        public void Review_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Review).When(
                () => test.Review = new Mock<IReview>().Object);
        }

        [Test]
        public void Priority_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Priority).When(() => test.Priority = Priority.Should);
        }

        [Test]
        public void Repetition_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Repetition).When(
                () => test.Repetition = new Mock<IRepetition>().Object);
        }

        [Test]
        public void Context_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Context).When(
                () => test.Context = new Mock<IGtdContext>().Object);
        }
    }
}