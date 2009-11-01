using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Autofac;
using Autofac.Builder;
using Relax.FileBackingStore.Models;
using Relax.Infrastructure.Interfaces;

namespace Relax.FileBackingStore.Services
{
    public class FileBackingStoreService : IBackingStore
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

        public FileBackingStoreService(IFactory factory)
        {
            Factory = factory;
        }

        public string Path { get; set; }

        #region IBackingStore Members

        public IFactory Factory{ get; private set;}

        /// <summary>
        /// Saves the data to the file using it's path.
        /// </summary>
        public void Save()
        {
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Path));
            using (var saveStream = new FileStream(Path, FileMode.Create))
                Save(saveStream);
        }

        #endregion

        /// <summary>
        /// Loads a file from the given path.
        /// </summary>
        /// <param name="path">Path to load from.</param>
        /// <param name="container"></param>
        /// <returns>Backing store loaded from the file.</returns>
        public static FileBackingStoreService Load(string path, IContainer container)
        {
            using (var stream = new FileStream(path, FileMode.Open))
            {
                FileBackingStoreService fileBackingStore = Load(stream, container);
                fileBackingStore.Path = path;
                return fileBackingStore;
            }
        }

        /// <summary>
        /// Loads a FileBackingStore from the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="container"></param>
        /// <returns></returns>
        public static FileBackingStoreService Load(Stream stream, IContainer container)
        {
            using (XmlReader reader = XmlReader.Create(stream))
                return Load(reader, container);
        }

        /// <summary>
        /// Loads a FileBackingStore from the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        public static FileBackingStoreService Load(XmlReader reader, IContainer container)
        {
            using (XmlDictionaryReader dictionaryReader = XmlDictionaryReader.CreateDictionaryReader(reader))
            {
                DataContractSerializer dcs = GetSerializer();
                var backingStore = (FileBackingStoreService) dcs.ReadObject(dictionaryReader);

                return backingStore;
            }
        }

        /// <summary>
        /// Changes the path of the file and saves it.
        /// </summary>
        /// <param name="path">New path to be used.</param>
        public void Save(string path)
        {
            Path = path;
            Save();
        }

        public void RegisterTypes(ContainerBuilder builder)
        {
            builder.Register<Factory>().As<IFactory>();

            builder.Register<Models.Action>().As<IAction>();
            builder.Register<Context>().As<Infrastructure.Interfaces.IContext>();
            builder.Register<ReviewChecklistItem>().As<IReviewChecklistItem>();

            builder.Register<Completion>().As<ICompletion>();
            builder.Register<Deadline>().As<IDeadline>();
            builder.Register<Deferral>().As<IDeferral>();
            builder.Register<Cost>().As<ICost>();
            builder.Register<Delegation>().As<IDelegation>();
            builder.Register<Review>().As<IReview>();
            builder.Register<ItemNotes>().As<INotes>();
        }

        /// <summary>
        /// Save the data to a stream.
        /// </summary>
        /// <param name="saveStream">Stream to save to.</param>
        public void Save(FileStream saveStream)
        {
            using (XmlWriter writer = XmlWriter.Create(saveStream, new XmlWriterSettings {Indent = true}))
                Save(writer);
        }

        /// <summary>
        /// Saves the data to the specified writer.
        /// </summary>
        /// <param name="writer">The writer to save to.</param>
        public void Save(XmlWriter writer)
        {
            using (XmlDictionaryWriter xdw = XmlDictionaryWriter.CreateDictionaryWriter(writer))
            {
                DataContractSerializer dcs = GetSerializer();
                dcs.WriteObject(xdw, this);
            }
        }

        /// <summary>
        /// Gets a serializer fot the FileBackingStore.
        /// </summary>
        /// <returns>Serializer.</returns>
        private static DataContractSerializer GetSerializer()
        {
            return new DataContractSerializer(typeof (FileBackingStoreService), KnownTypes);
        }
    }
}