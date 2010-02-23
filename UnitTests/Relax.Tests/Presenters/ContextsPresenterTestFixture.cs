﻿using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ContextsPresenterTestFixture : TestDataBuilder
    {
        private readonly Mock<IGtdContextPresenter> _stubContextPresenter = new Mock<IGtdContextPresenter>();
        private readonly Mock<IGtdContext> _stubNewContext = new Mock<IGtdContext>();
        private readonly IWorkspace _stubWorkspace = AWorkspace.Build();

        private ContextsPresenter BuildDefaultContextsPresenter()
        {
            return new ContextsPresenter(_stubWorkspace,
                                         x => _stubContextPresenter.Object,
                                         () => _stubNewContext.Object);
        }

        [Fact]
        public void AddContext__AddsAContextToTheWorkspace()
        {
            BuildDefaultContextsPresenter().AddContext();

            Assert.Contains(_stubNewContext.Object, _stubWorkspace.Contexts);
        }
    }
}