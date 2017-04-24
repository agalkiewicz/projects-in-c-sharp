using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace Library
{
    [Serializable]
    [JsonObject()]
    public class Author : IComparable<Author>, ISerializable
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }

        [JsonConstructor]
        public Author(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        private Author(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetString("name");
            Surname = (string)info.GetString("surname");
        }

        public override string ToString()
        {
            return Name + " " + Surname;
        }

        public static bool operator ==(Author a, Author b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return (a.Name == b.Name) && (a.Surname == b.Surname);
        }

        public static bool operator !=(Author a, Author b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            Author author = obj as Author;

            if (author == null)
            {
                return false;
            }

            return (this == author);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Surname.GetHashCode();
        }

        public int CompareTo(Author other)
        {
            int compareSurname = this.Surname.CompareTo(other.Surname);
            if (compareSurname != 0)
            {
                return compareSurname;
            }
            else
            {
                return this.Name.CompareTo(other.Name);
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name, typeof(string));
            info.AddValue("surname", Surname, typeof(string));
        }
    }
}
