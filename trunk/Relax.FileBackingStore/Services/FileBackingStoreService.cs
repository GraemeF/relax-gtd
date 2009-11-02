using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Caliburn.Core.Metadata;
using Relax.FileBackingStore.Models;
using Relax.FileBackingStore.Services.Interfaces;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Infrastructure.Services.Interfaces;

namespace Relax.FileBackingStore.Services
{
    [Singleton(typeof (IBackingStore))]
    public class FileBackingStoreService : IFileBackingStore
    {
        /// <summary>
        /// Gets a list of all of the types that may be required during serialization.
        /// </summary>
        /// <returns>List of types.</returns>
        private static readonly List<Type> KnownTypes = new List<Type>
                                                            {
                                                                typeof (Models.Action),
                                                                typeof (Completion),
                                                                typeof (Context),
                                                                typeof (Cost),
                                                                typeof (Deadline),
                                                                typeof (Deferral),
                                                                typeof (Delegation),
                                                                //typeof (ItemNotes),
                                                                typeof (Review),
                                                                typeof (ReviewChecklistItem)
                                                            };

        private readonly IStartupFileLocator _locator;
        private readonly ISerializer<Workspace> _serializer;
        private readonly IFileStreamService _streamService;
        private IWorkspace _model;

        public FileBackingStoreService(IFileStreamService streamService,
                                       IWorkspace initialModel,
                                       IStartupFileLocator locator,
                                       ISerializer<Workspace> serializer)
        {
            _streamService = streamService;
            _serializer = serializer;
            _locator = locator;
            Path = _locator.Path;
            Workspace = initialModel;
        }

        #region IFileBackingStore Members

        public IWorkspace Workspace
        {
            get { return _model; }
            private set
            {
                if (_model != value)
                {
                    _model = value;
                    PropertyChanged.Raise(x => Workspace);
                }
            }
        }

        public void Load()
        {
            ValidatePath();

            using (Stream stream = _streamService.GetReadStream(Path))
                Workspace = _serializer.Load(stream, KnownTypes);
        }

        public void Save()
        {
            ValidatePath();

            using (Stream stream = _streamService.GetWriteStream(Path))
                _serializer.Save(stream, (Workspace) Workspace, KnownTypes);
        }

        public string Path { get; set; }

        #endregion

        public void Initialize()
        {
            if (_locator.LoadOnStartup)
                Load();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void ValidatePath()
        {
            if (Path == null)
                throw new InvalidOperationException("A path is required.");
        }
    }
}