using System.Collections.Generic;

namespace Library.Serialization
{
    public interface IConverter
    {
        void Deserialize<T>(string fileName, ref ICollection<T> whereToDeserialize);
        void Serialize<T>(string fileName, ICollection<T> whatToSerialize);
    }
}
