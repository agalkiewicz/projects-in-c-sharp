using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace Library
{
    [Serializable]
    [JsonObject()]
    public class Renting : ISerializable
    {
        public Reader ReaderWhoRented { get; set; }
        public Book RentalBook { get; set; }
        public DateTime DateOfRenting { get; set; }
        public DateTime DateOfReturn { get; set; }

        [JsonConstructor]
        public Renting(Reader readerWhoRented, Book rentalBook, DateTime dateOfRenting)
        {
            ReaderWhoRented = readerWhoRented;
            RentalBook = rentalBook;
            DateOfRenting = dateOfRenting;
            DateOfReturn = DateOfRenting.AddMonths(3);
        }

        private Renting(SerializationInfo info, StreamingContext context)
        {
            ReaderWhoRented = (Reader)info.GetValue("readerWhoRented", typeof(Reader));
            RentalBook = (Book)info.GetValue("book", typeof(Book));
            DateOfRenting = (DateTime)info.GetValue("dateOfRenting", typeof(DateTime));
            DateOfReturn = (DateTime)info.GetValue("dateOfReturn", typeof(DateTime));
        }

        public override string ToString()
        {
            return ReaderWhoRented.ToString() + " " + RentalBook.ToString() + " " +
                   DateOfRenting.ToString() + " " + DateOfReturn.ToString();
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("readerWhoRented", ReaderWhoRented, typeof(Reader));
            info.AddValue("book", RentalBook, typeof(Book));
            info.AddValue("dateOfRenting", DateOfRenting, typeof(DateTime));
            info.AddValue("dateOfReturn", DateOfReturn, typeof(DateTime));
        }

        public void Serialize(ref StringBuilder sb)
        {
            ReaderWhoRented.Serialize(ref sb);
            RentalBook.Serialize(ref sb);
            sb.Append(DateOfRenting);
            sb.AppendLine();
            sb.Append(DateOfReturn);
            sb.AppendLine();
            sb.Append("@");
            sb.AppendLine();
        }

        public void Deserialize(ref string s)
        {
            int index1 = 0, index2, length, option = 1;
            string tmp;
            while (option != 5)
            {
                index2 = s.IndexOf("\n", index1);
                length = index2 - index1;
                if (option == 1)
                {
                    tmp = s.Substring(index1, length);
                    ReaderWhoRented.Deserialize(ref tmp);
                }
                else if (option == 2)
                {
                    tmp = s.Substring(index1, length);
                    RentalBook.Deserialize(ref tmp);
                }
                else if (option == 3)
                    DateOfRenting = DateTime.Parse(s.Substring(index1, length));
                else if (option == 4)
                    DateOfReturn = DateTime.Parse(s.Substring(index1, length));
                index1 = index2 + 1;
                option++;
            }
        }
    }
}
