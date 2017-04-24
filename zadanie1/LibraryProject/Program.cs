using System;
using System.Collections.Generic;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleDataProvider provider = new SimpleDataProvider();
            //RandomDataProvider provider = new RandomDataProvider(10, 20, 16);
            DataRepository data = new DataRepository(provider);
            DataService service = new DataService(data);
            
            Console.WriteLine("Czytelnicy");
            foreach (Reader reader in service.GetAllReaders())
                Console.WriteLine(reader.ToString());
            Console.WriteLine("");
            Console.WriteLine("Ksiazki");
            foreach (Book book in service.GetAllBooks())
                Console.WriteLine(book.ToString());
            Console.WriteLine("");
            Console.WriteLine("Wypozyczenia");
            foreach (Renting rent in service.GetAllRentings())
                Console.WriteLine(rent.ToString());
            Console.WriteLine("");
            Console.WriteLine("Czytelnicy i ich wypozyczenia");
            foreach (Reader reader in service.GetAllReaders())
                foreach (Renting renting in service.GetRentingsOfReader(reader))
                {
                    Console.WriteLine(reader.ToString());
                    Console.WriteLine(renting.ToString());
                }

            Reader reader1 = new Reader("Alicja", "Delicja", 192837);
            service.AddReader(reader1);
            Console.WriteLine("");
            Console.WriteLine("Czytelnicy po dodaniu");
            foreach (Reader reader in service.GetAllReaders())
                Console.WriteLine(reader.ToString());

            service.DeleteReader(reader1);
            Console.WriteLine("");
            Console.WriteLine("Czytelnicy po usunieciu");
            foreach (Reader reader in service.GetAllReaders())
                Console.WriteLine(reader.ToString());

            Console.ReadKey();
        }
    }
}
