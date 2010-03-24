﻿using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class ContextViewTestFixture : ViewTestFixtureBase<ContextView, ContextPresenter>
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView().AssertNoErrors();
        }

        [Fact]
        public void IsReadOnly__IsBound()
        {
            Assert.True(BoundView().WasBoundTo(x => x.IsReadOnly));
        }

        [Fact]
        public void DisplayName__IsBound()
        {
            Assert.True(BoundView().WasBoundTo(x => x.DisplayName));
        }
    }
}