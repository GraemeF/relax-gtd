using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Relax.Infrastructure.Helpers;
using Xunit;

namespace Relax.Infrastructure.Tests.Helpers
{
    public class ListSyncTestFixture
    {
        private const string StringPrefix = "String representation of ";

        [Fact]
        public void TestConstruct()
        {
            var ints = new ObservableCollection<int>();
            var strings = new ObservableCollection<string>();

            new ListSync<int, string>(ints,
                                      strings,
                                      x => string.Concat(StringPrefix, x.ToString()),
                                      null);
        }

        [Fact]
        public void CollectionSync_GivenNullSourceList_ThrowsArgumentNullException()
        {
            var strings = new ObservableCollection<string>();

            Assert.Throws(typeof (ArgumentNullException),
                          () => new ListSync<int, string>(null,
                                                          strings,
                                                          x => string.Concat(StringPrefix, x.ToString()),
                                                          null));
        }

        [Fact]
        public void CollectionSync_GivenNullDestList_ThrowsArgumentNullException()
        {
            var ints = new ObservableCollection<int>();

            Assert.Throws(typeof (ArgumentNullException),
                          () => new ListSync<int, string>(ints,
                                                          null,
                                                          x => string.Concat(StringPrefix, x.ToString()),
                                                          null));
        }

        [Fact]
        public void ListIsPopulatedDuringConstruction()
        {
            var ints = new ObservableCollection<int>(new List<int> {65, 43, 21});
            var strings = new ObservableCollection<string>();

            new ListSync<int, string>(ints,
                                      strings,
                                      x => string.Concat(StringPrefix, x.ToString()),
                                      null);

            Assert.Equal(StringPrefix + "65", strings[0]);
            Assert.Equal(StringPrefix + "43", strings[1]);
            Assert.Equal(StringPrefix + "21", strings[2]);
        }

        [Fact]
        public void ItemsAreRemoved()
        {
            var ints = new ObservableCollection<int>(new List<int> {65, 43, 21});
            var strings = new ObservableCollection<string>();

            var sync
                = new ListSync<int, string>(ints,
                                            strings,
                                            x => string.Concat(StringPrefix, x.ToString()),
                                            null);

            ints.Remove(43);
            GC.KeepAlive(sync);

            Assert.Equal(StringPrefix + "65", strings[0]);
            Assert.Equal(StringPrefix + "21", strings[1]);
        }

        [Fact]
        public void RemoveItem_WithItemRemover_CallsItemRemover()
        {
            var ints = new ObservableCollection<int>(new List<int> {65, 43, 21});
            var strings = new ObservableCollection<string>();
            bool itemRemoved = false;

            var sync
                = new ListSync<int, string>(ints,
                                            strings,
                                            insertedItem => string.Concat(StringPrefix, insertedItem.ToString()),
                                            removedItem => itemRemoved = true);

            ints.Remove(43);
            GC.KeepAlive(sync);

            Assert.True(itemRemoved);
        }

        [Fact]
        public void ItemsAreInserted()
        {
            var ints = new ObservableCollection<int>(new List<int> {65, 43, 21});
            var strings = new ObservableCollection<string>();

            var sync
                = new ListSync<int, string>(ints,
                                            strings,
                                            x => string.Concat(StringPrefix, x.ToString()),
                                            null);

            ints.Insert(2, 666);
            GC.KeepAlive(sync);

            Assert.Equal(StringPrefix + "65", strings[0]);
            Assert.Equal(StringPrefix + "43", strings[1]);
            Assert.Equal(StringPrefix + "666", strings[2]);
            Assert.Equal(StringPrefix + "21", strings[3]);
        }

        [Fact]
        public void Move_OnSource_UpdatesDestination()
        {
            var ints = new ObservableCollection<int>(new List<int> {1, 2, 3, 4});
            var strings = new ObservableCollection<string>();

            var sync
                = new ListSync<int, string>(ints,
                                            strings,
                                            x => string.Concat(StringPrefix, x.ToString()),
                                            null);

            ints.Move(2, 1);
            GC.KeepAlive(sync);

            Assert.Equal(StringPrefix + "1", strings[0]);
            Assert.Equal(StringPrefix + "3", strings[1]);
            Assert.Equal(StringPrefix + "2", strings[2]);
            Assert.Equal(StringPrefix + "4", strings[3]);
        }

        [Fact]
        public void Replace_OnSource_UpdatesDestination()
        {
            var ints = new ObservableCollection<int>(new List<int> {1, 2, 3, 4});
            var strings = new ObservableCollection<string>();

            var sync
                = new ListSync<int, string>(ints,
                                            strings,
                                            x => string.Concat(StringPrefix, x.ToString()),
                                            null);

            ints[2] = 5;
            GC.KeepAlive(sync);

            Assert.Equal(StringPrefix + "1", strings[0]);
            Assert.Equal(StringPrefix + "2", strings[1]);
            Assert.Equal(StringPrefix + "5", strings[2]);
            Assert.Equal(StringPrefix + "4", strings[3]);
        }

        [Fact]
        public void CollectionSync_GivenItemsInDestination_EmptiesDestination()
        {
            var ints = new ObservableCollection<int>(new List<int> {1, 2, 3, 4});
            var strings = new ObservableCollection<string>(new[] {"hello", "world"});

            new ListSync<int, string>(ints,
                                      strings,
                                      x => string.Concat(StringPrefix, x.ToString()),
                                      null);

            Assert.Equal(StringPrefix + "1", strings[0]);
            Assert.Equal(StringPrefix + "2", strings[1]);
            Assert.Equal(StringPrefix + "3", strings[2]);
            Assert.Equal(StringPrefix + "4", strings[3]);
        }

        [Fact]
        public void CollectionSync_GivenItemsInDestination_CallsRemoveOnOldItems()
        {
            var ints = new ObservableCollection<int>(new List<int> {1, 2, 3, 4});
            var strings = new ObservableCollection<string>(new[] {"hello"});

            bool removed = false;

            new ListSync<int, string>(ints,
                                      strings,
                                      x => string.Concat(StringPrefix, x.ToString()),
                                      x => removed = true);

            Assert.True(removed);
        }

        [Fact]
        public void Reset_ResetsDestination()
        {
            var ints = new ObservableCollection<int>(new List<int> {1, 2, 3, 4});
            var strings = new ObservableCollection<string>();

            var sync
                = new ListSync<int, string>(ints,
                                            strings,
                                            x => string.Concat(StringPrefix, x.ToString()),
                                            null);

            ints.Clear();
            GC.KeepAlive(sync);

            Assert.Empty(strings);
        }

        [Fact]
        public void Dispose_Succeeds()
        {
            var ints = new ObservableCollection<int>(new List<int> {1, 2, 3, 4});
            var strings = new ObservableCollection<string>();

            var sync
                = new ListSync<int, string>(ints,
                                            strings,
                                            x => string.Concat(StringPrefix, x.ToString()),
                                            null);

            sync.Dispose();
        }
    }
}