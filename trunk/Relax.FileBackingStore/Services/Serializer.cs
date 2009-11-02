using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using Relax.FileBackingStore.Services.Interfaces;

namespace Relax.FileBackingStore.Services
{
    public class Serializer<T> : ISerializer<T>
    {
        #region ISerializer<T> Members

        /// <summary>
        /// Save the data to a stream.
        /// </summary>
        /// <param name="saveStream">Stream to save to.</param>
        public void Save(Stream saveStream, T model, IEnumerable<Type> knownTypes)
        {
            using (XmlWriter writer = XmlWriter.Create(saveStream, new XmlWriterSettings {Indent = true}))
                Save(writer, model, knownTypes);
        }

        /// <summary>
        /// Saves the data to the specified writer.
        /// </summary>
        /// <param name="writer">The writer to save to.</param>
        public void Save(XmlWriter writer, T model, IEnumerable<Type> knownTypes)
        {
            using (XmlDictionaryWriter xdw = XmlDictionaryWriter.CreateDictionaryWriter(writer))
            {
                DataContractSerializer dcs = GetSerializer(knownTypes);
                dcs.WriteObject(xdw, model);
            }
        }

        /// <summary>
        /// Save the data to a stringbuilder.
        /// </summary>
        /// <param name="strBuilder">String to save to.</param>
        public void Save(StringBuilder strBuilder, T model, IEnumerable<Type> knownTypes)
        {
            using (XmlWriter writer = XmlWriter.Create(strBuilder, new XmlWriterSettings { Indent = true }))
                Save(writer, model, knownTypes);
        }

        /// <summary>
        /// Loads a FileBackingStore from the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        public T Load(Stream stream, IEnumerable<Type> knownTypes)
        {
            using (XmlReader reader = XmlReader.Create(stream))
                return Load(reader, knownTypes);
        }

        /// <summary>
        /// Loads a FileBackingStore from the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        public T Load(XmlReader reader, IEnumerable<Type> knownTypes)
        {
            using (XmlDictionaryReader dictionaryReader = XmlDictionaryReader.CreateDictionaryReader(reader))
            {
                DataContractSerializer dcs = GetSerializer(knownTypes);
                return (T) dcs.ReadObject(dictionaryReader);
            }
        }

        /// <summary>
        /// Loads a FileBackingStore from the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public T Load(string str, IEnumerable<Type> knownTypes)
        {
            StringReader strReader = new StringReader(str);
            using (XmlReader reader = XmlReader.Create(strReader))
                return Load(reader, knownTypes);
        }
        #endregion

        /// <summary>
        /// Gets a serializer fot the FileBackingStore.
        /// </summary>
        /// <returns>Serializer.</returns>
        private static DataContractSerializer GetSerializer(IEnumerable<Type> knownTypes)
        {
            return new DataContractSerializer(typeof (T), knownTypes);
        }
    }
}