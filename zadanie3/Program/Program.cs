using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library;
using Library.Serialization;

namespace Program
{
    class Program
    {
        public static void Print<T>(ICollection<T> collection)
        {
            foreach (T c in collection)
                Console.WriteLine(c.ToString());
        }

        public static void PrintD(ICollection<KeyValuePair<uint, Book>> collection)
        {
            foreach (KeyValuePair<uint, Book> book in collection)
                Console.WriteLine(book.Key.ToString() + " " + book.Value.ToString());
        }

        static void Main(string[] args)
        {
            string name = "serialized";
            string name1 = name + "1";
            string name2 = name + "2";
            string name3 = name + "3";
            IDataProvider provider = new SimpleDataProvider();
            DataRepository repo = new DataRepository(provider);

            ICollection<Reader> list = new List<Reader>();
            ICollection<KeyValuePair<uint, Book>> dictionary = new Dictionary<uint, Book>();
            ICollection<Renting> collection = new ObservableCollection<Renting>();

            IConverter converter = new BinaryConverter();
            
            Console.WriteLine("Deserializacja z pliku binarnego\n");

            converter.Serialize(name1, repo.ReadAllReaders());
            converter.Deserialize(name1, ref list);
            Print(list);
            Console.WriteLine("");
            
            converter.Serialize(name2, repo.ReadAllBooks());
            converter.Deserialize(name2, ref dictionary);
            PrintD(dictionary);
            Console.WriteLine("");

            converter.Serialize(name3, repo.ReadAllRentings());
            converter.Deserialize(name3, ref collection);
            Print(collection);
            Console.WriteLine("");

            Console.WriteLine("Deserializacja z pliku .json\n");

            JsonConverter converter2 = new JsonConverter();

            converter2.Serialize(name1, repo.ReadAllReaders());
            list = null;
            converter2.Deserialize(name1, ref list);
            Print(list);
            Console.WriteLine("");

            converter2.Serialize(name2, repo.ReadAllBooks());
            Dictionary<uint, Book> dictionary2 = new Dictionary<uint, Book>();
            converter2.Deserialize(name2, ref dictionary2);
            PrintD(dictionary2);
            Console.WriteLine("");

            converter2.Serialize(name3, repo.ReadAllRentings());
            collection = null;
            converter2.Deserialize(name3, ref collection);
            Print(collection);
            Console.WriteLine("");
            
            Console.WriteLine("Deserializacja z pliku .xml\n");

            IConverter converter1 = new XMLConverter();

            converter1.Serialize(name1, repo.ReadAllReaders());
            ICollection<Reader> list1 = new List<Reader>();
            converter1.Deserialize(name1, ref list1);
            Print(list1);
            Console.WriteLine("");
            
            converter1.Serialize(name2, repo.ReadAllBooks());
            dictionary = null;
            converter1.Deserialize(name2, ref dictionary);
            PrintD(dictionary);
            Console.WriteLine("");

            converter1.Serialize(name3, repo.ReadAllRentings());
            collection = null;
            converter1.Deserialize(name3, ref collection);
            Print(collection);
            Console.WriteLine("");
            
            string name4 = "text";
            string name4a = name4 + "a";
            string name4b = name4 + "b";
            string name4c = name4 + "c";

            Console.WriteLine("Własna deserializacja z pliku .txt\n");

            TxtConverter textConverter = new TxtConverter();
            List <Reader> list2= new List<Reader>();
            textConverter.Serialize(name4a, repo.ReadAllReaders());
            textConverter.Deserialize(name4a, ref list2);
            Print(list2);

            Console.WriteLine();

            Dictionary<uint, Book> dictionary3 = new Dictionary<uint, Book>();
            textConverter.Serialize(name4b, repo.ReadAllBooks());
            textConverter.Deserialize(name4b, ref dictionary3);
            PrintD(dictionary3);

            Console.WriteLine();

            ObservableCollection<Renting> collection2 = new ObservableCollection<Renting>();
            textConverter.Serialize(name4c, repo.ReadAllRentings());
            textConverter.Deserialize(name4c, ref collection2);
            Print(collection2);

            Console.ReadKey();
        }
    }
}
