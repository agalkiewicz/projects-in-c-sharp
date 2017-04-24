using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Security.Permissions;
using System.Text;

namespace Library
{
    [Serializable]
    [JsonObject()]
    public class Book : IComparable<Book>, ISerializable
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "author")]
        public Author Author { get; set; }

        [JsonProperty(PropertyName = "yearOfRelease")]
        public uint YearOfRelease { get; set; }

        [JsonProperty(PropertyName = "publisher")]
        public string Publisher { get; set; }

        [JsonProperty(PropertyName = "id")]
        public uint Id { get; set; }

        public Book(Author author)
        {
            Author = author;
        }

        [JsonConstructor]
        public Book(string title, Author author, uint yearOfRelease, string publisher, uint id)
        {
            Title = title;
            Author = author;
            YearOfRelease = yearOfRelease;
            Publisher = publisher;
            Id = id;
        }
        
        private Book(SerializationInfo info, StreamingContext context)
        {
            Title = info.GetString("title");
            Author = (Author)info.GetValue("author", typeof(Author));
            YearOfRelease = info.GetUInt32("yearOfRelease");
            Publisher = info.GetString("publisher");
            Id = info.GetUInt32("id");
        }

        public override string ToString()
        {
            return Title + " " + Author.ToString() + " " + YearOfRelease + " " + Publisher
                   + " " + Id;
        }

        public int CompareTo(Book other)
        {
            int authorCompare = this.Author.CompareTo(other.Author);
            if (authorCompare != 0)
            {
                return authorCompare;
            }
            else
            {
                return this.Title.CompareTo(other.Title);
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("title", Title, typeof(string));
            info.AddValue("author", Author, typeof(Author));
            info.AddValue("yearOfRelease", YearOfRelease, typeof(uint));
            info.AddValue("publisher", Publisher, typeof(string));
            info.AddValue("id", Id, typeof(uint));
        }

        public void Serialize(ref StringBuilder sb)
        {
            sb.Append(Title + "*");
            sb.Append(Author.Name + " ");
            sb.Append(Author.Surname + "*");
            sb.Append(YearOfRelease + "*");
            sb.Append(Publisher + "*");
            sb.Append(Id + "*");
            sb.AppendLine();
        }

        public void Deserialize(ref string s)
        {
            int index1 = 0, index2, length, option = 1;
            while (option != 6)
            {
                index2 = s.IndexOf("*", index1);
                length = index2 - index1;
                if (option == 1)
                    Title = s.Substring(index1, length);
                else if (option == 2)
                {
                    int option1 = 1;
                    while (option1 != 3)
                    {
                        if (option1 == 1)
                            index2 = s.IndexOf(" ", index1);
                        if (option1 == 2)
                            index2 = s.IndexOf("*", index1);
                        length = index2 - index1;
                        if (option1 == 1)
                            Author.Name = s.Substring(index1, length);
                        else if (option1 == 2)
                            Author.Surname = s.Substring(index1, length);
                        index1 = index2 + 1;
                        option1++;
                    }
                }
                else if (option == 3)
                    YearOfRelease = uint.Parse(s.Substring(index1, length));
                else if (option == 4)
                    Publisher = s.Substring(index1, length);
                else if (option == 5)
                    Id = uint.Parse(s.Substring(index1, length));
                index1 = index2 + 1;
                option++;
            }
        }
    }
}
