using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Relax.FileBackingStore.Services.Interfaces
{
    public interface ISerializer<T>
    {
        T Load(Stream stream, IEnumerable<Type> knownTypes);
        T Load(XmlReader reader, IEnumerable<Type> knownTypes);

        void Save(Stream stream, T model, IEnumerable<Type> knownTypes);
        void Save(XmlWriter writer, T model, IEnumerable<Type> knownTypes);
    }
}