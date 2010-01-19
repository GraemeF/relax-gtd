using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MbUnit.Framework;
using Relax.Infrastructure.Helpers;

namespace Relax.Infrastructure.Tests.Helpers
{
    [TestFixture]
    public class CollectionSyncTestFixture
    {
        private const string StringPrefix = "String representation of ";

        [Test]
        public void TestConstruct()
        {
            var ints = new ObservableCollection<int>();
            var strings = new ObservableCollection<string>();

            new CollectionSync<int, string>(ints,
                                            strings,
                                            x =>
                                            string.Concat(
                                                StringPrefix,
                                                x.ToString()),
                                            null);
        }

        [Test]
        [ExpectedArgumentNullException]
        public void CollectionSync_GivenNullSourceList_ThrowsArgumentNullException()
        {
            var strings = new ObservableCollection<string>();

            new CollectionSync<int, string>(null,
                                            strings,
                                            x =>
                                            string.Concat(
                                                StringPrefix,
                                                x.ToString()),
                                            null);
        }

        [Test]
        [ExpectedArgumentNullException]
        public void CollectionSync_GivenNullDestList_ThrowsArgumentNullException()
        {
            var ints = new ObservableCollection<int>();

            new CollectionSync<int, string>(ints,
                                            null,
                                            x =>
                                            string.Concat(
                                                StringPrefix,
                                                x.ToString()),
                                            null);
        }

        [Test]
        public void ListIsPopulatedDuringConstruction()
        {
            var ints = new ObservableCollection<int>(new List<int> {65, 43, 21});
            var strings = new ObservableCollection<string>();

            new CollectionSync<int, string>(ints,
                                            strings,
                                            x =>
                                            string.Concat(
                                                StringPrefix,
                                                x.ToString()),
                                            null);

            Assert.AreElementsEqual(new List<string>
                                        {
                                            StringPrefix + "65",
                                            StringPrefix + "43",
                                            StringPrefix + "21"
                                        },
                                    strings);
        }

        [Test]
        public void ItemsAreRemoved()
        {
            var ints = new ObservableCollection<int>(new List<int> {65, 43, 21});
            var strings = new ObservableCollection<string>();

            var sync
                = new CollectionSync<int, string>(ints,
                                                  strings,
                                                  x =>
                                                  string.Concat(
                                                      StringPrefix,
                                                      x.ToString()),
                                                  null);

            ints.Remove(43);
            GC.KeepAlive(sync);

            Assert.AreElementsEqual(new List<string>
                                        {
                                            StringPrefix + "65",
                                            StringPrefix + "21"
                                        },
                                    strings);
        }

        [Test]
        public void RemoveItem_WithItemRemover_CallsItemRemover()
        {
            var ints = new ObservableCollection<int>(new List<int> {65, 43, 21});
            var strings = new ObservableCollection<string>();
            bool itemRemoved = false;

            var sync
                = new CollectionSync<int, string>(ints,
                                                  strings,
                                                  insertedItem => string.Concat(StringPrefix, insertedItem.ToString()),
                                                  removedItem => itemRemoved = true);

            ints.Remove(43);
            GC.KeepAlive(sync);

            Assert.IsTrue(itemRemoved);
        }

        [Test]
        public void ItemsAreInserted()
        {
            var ints = new ObservableCollection<int>(new List<int> {65, 43, 21});
            var strings = new ObservableCollection<string>();

            var sync
                = new CollectionSync<int, string>(ints,
                                                  strings,
                                                  x =>
                                                  string.Concat(
                                                      StringPrefix,
                                                      x.ToString()),
                                                  null);

            ints.Insert(2, 666);
            GC.KeepAlive(sync);

            Assert.AreElementsEqual(new List<string>
                                        {
                                            StringPrefix + "65",
                                            StringPrefix + "43",
                                            StringPrefix + "666",
                                            StringPrefix + "21"
                                        },
                                    strings);
        }

        [Test]
        public void Move_OnSource_UpdatesDestination()
        {
            var ints = new ObservableCollection<int>(new List<int> {1, 2, 3, 4});
            var strings = new ObservableCollection<string>();

            var sync
                = new CollectionSync<int, string>(ints,
                                                  strings,
                                                  x =>
                                                  string.Concat(
                                                      StringPrefix,
                                                      x.ToString()),
                                                  null);

            ints.Move(2, 1);
            GC.KeepAlive(sync);

            Assert.AreElementsEqual(new List<string>
                                        {
                                            StringPrefix + "1",
                                            StringPrefix + "3",
                                            StringPrefix + "2",
                                            StringPrefix + "4"
                                        },
                                    strings);
        }

        [Test]
        public void Replace_OnSource_UpdatesDestination()
        {
            var ints = new ObservableCollection<int>(new List<int> {1, 2, 3, 4});
            var strings = new ObservableCollection<string>();

            var sync
                = new CollectionSync<int, string>(ints,
                                                  strings,
                                                  x =>
                                                  string.Concat(
                                                      StringPrefix,
                                                      x.ToString()),
                                                  null);

            ints[2] = 5;
            GC.KeepAlive(sync);

            Assert.AreElementsEqual(new List<string>
                                        {
                                            StringPrefix + "1",
                                            StringPrefix + "2",
                                            StringPrefix + "5",
                                            StringPrefix + "4"
                                        },
                                    strings);
        }

        [Test]
        public void CollectionSync_GivenItemsInDestination_EmptiesDestination()
        {
            var ints = new ObservableCollection<int>(new List<int> {1, 2, 3, 4});
            var strings = new ObservableCollection<string>(new[] {"hello", "world"});

            new CollectionSync<int, string>(ints,
                                            strings,
                                            x =>
                                            string.Concat(
                                                StringPrefix,
                                                x.ToString()),
                                            null);

            Assert.AreElementsEqual(new List<string>
                                        {
                                            StringPrefix + "1",
                                            StringPrefix + "2",
                                            StringPrefix + "3",
                                            StringPrefix + "4"
                                        },
                                    strings);
        }

        [Test]
        public void CollectionSync_GivenItemsInDestination_CallsRemoveOnOldItems()
        {
            var ints = new ObservableCollection<int>(new List<int> {1, 2, 3, 4});
            var strings = new ObservableCollection<string>(new[] {"hello"});

            bool removed = false;

            new CollectionSync<int, string>(ints,
                                            strings,
                                            x =>
                                            string.Concat(
                                                StringPrefix,
                                                x.ToString()),
                                            x => removed = true);

            Assert.IsTrue(removed);
        }

        [Test]
        public void Reset_ResetsDestination()
        {
            var ints = new ObservableCollection<int>(new List<int> {1, 2, 3, 4});
            var strings = new ObservableCollection<string>();

            var sync
                = new CollectionSync<int, string>(ints,
                                                  strings,
                                                  x =>
                                                  string.Concat(
                                                      StringPrefix,
                                                      x.ToString()),
                                                  null);

            ints.Clear();
            GC.KeepAlive(sync);

            Assert.IsEmpty(strings);
        }

        [Test]
        public void Dispose_Succeeds()
        {
            var ints = new ObservableCollection<int>(new List<int> {1, 2, 3, 4});
            var strings = new ObservableCollection<string>();

            var sync
                = new CollectionSync<int, string>(ints,
                                                  strings,
                                                  x =>
                                                  string.Concat(
                                                      StringPrefix,
                                                      x.ToString()),
                                                  null);

            sync.Dispose();
        }
    }
}