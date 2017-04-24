using System;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace Library
{
    [Serializable()]
    [JsonObject()]
    public class Reader : ISerializable
    {
        private string name;

        private string surname;

        private uint idNumber;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public uint IdNumber
        {
            get { return idNumber; }
            set { idNumber = value; }
        }

        public Reader() { }

        [JsonConstructor]
        public Reader(string name, string surname, uint idNumber)
        {
            this.name = name;
            this.surname = surname;
            this.idNumber = idNumber;
        }
        
        protected Reader(SerializationInfo info, StreamingContext context)
        {
            name = info.GetString("name");
            surname = info.GetString("surname");
            idNumber = info.GetUInt32("id");  
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " + IdNumber;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", name, typeof(string));
            info.AddValue("surname", surname, typeof(string));
            info.AddValue("id", idNumber, typeof(uint));
        }

        public void Serialize(ref StringBuilder sb)
        {
            sb.Append(idNumber + "*");
            sb.Append(name + "*");
            sb.Append(surname + "*");
            sb.AppendLine();
        }
        
        public void Deserialize(ref String s)
        {
            int index1 = 0, index2 = 0, length = 0, option = 1;
            while (option != 4)
            {
                index2 = s.IndexOf("*", index1);
                length = index2 - index1;
                if (option == 1)
                    idNumber = uint.Parse(s.Substring(index1, length));
                else if (option == 2)
                    name = s.Substring(index1, length);
                else if (option == 3)
                    surname = s.Substring(index1, length);
                index1 = index2 + 1;
                option++;
            }
        }
    }
}
