﻿using Caliburn.PresentationFramework.ApplicationModel;

namespace Relax.Presenters.Interfaces
{
    public interface IActionProcessorPresenter : IPresenter
    {
        void Apply();
    }
}