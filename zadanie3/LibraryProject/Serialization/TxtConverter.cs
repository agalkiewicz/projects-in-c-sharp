using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Collections.ObjectModel;

namespace Library.Serialization
{
    public class TxtConverter
    {
        StringBuilder sb;

        public void Serialize(string fileName, ObservableCollection<Renting> whatToSerialize)
        {
            fileName += ".txt";
            try
            {
                using (StreamWriter writer = File.CreateText(fileName))
                {
                    sb = new StringBuilder();
                    foreach (Renting record in whatToSerialize)
                        record.Serialize(ref sb);
                    writer.Write(sb);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Deserialize(string fileName, ref ObservableCollection<Renting> whereToDeserialize)
        {
            fileName += ".txt";
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string str = reader.ReadToEnd();
                    string line;
                    int index1 = 0, index2, length;
                    int year = 1992;
                    while (!str[index1].Equals(null))
                    {
                        index2 = str.IndexOf("@", index1);
                        length = index2 - index1;
                        line = str.Substring(index1, length);
                        Author author = new Author("", "");
                        Book book = new Book(author);
                        Reader r = new Reader();
                        DateTime date = new DateTime(year, 04, 12);
                        Renting whatToAdd = new Renting(r, book, date);
                        whatToAdd.Deserialize(ref line);
                        whereToDeserialize.Add(whatToAdd);
                        index1 = index2 + 3;;
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Serialize(string fileName, Dictionary<uint, Book> whatToSerialize)
        {
            fileName += ".txt";
            try
            {
                using (StreamWriter writer = File.CreateText(fileName))
                {
                    sb = new StringBuilder();
                    foreach (KeyValuePair<uint, Book> record in whatToSerialize)
                        record.Value.Serialize(ref sb);
                    writer.Write(sb);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Deserialize(string fileName, ref Dictionary<uint, Book> whereToDeserialize)
        {
            fileName += ".txt";
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string str = reader.ReadToEnd();
                    string line;
                    int index1 = 0, index2, length;
                    uint klucz = 1;
                    while (!str[index1].Equals(null))
                    {
                        index2 = str.IndexOf("\n", index1);
                        length = index2 - index1;
                        line = str.Substring(index1, length);
                        Author author = new Author("", "");
                        Book whatToAdd = new Book(author);
                        whatToAdd.Deserialize(ref line);
                        whereToDeserialize.Add(klucz, whatToAdd);
                        index1 = index2 + 1;
                        klucz++;
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Serialize(string fileName, List<Reader> whatToSerialize)
        {
            fileName += ".txt";
            try
            {
                using (StreamWriter writer = File.CreateText(fileName))
                {
                    sb = new StringBuilder();
                    foreach (Reader record in whatToSerialize)
                        record.Serialize(ref sb);
                    writer.Write(sb);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Deserialize(string fileName, ref List<Reader> whereToDeserialize)
        {
            fileName += ".txt";
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string str = reader.ReadToEnd();
                    string line;
                    int index1 = 0, index2 = 0, length = 0;
                    while (!str[index1].Equals(null))
                    {
                        index2 = str.IndexOf("\n", index1);
                        length = index2 - index1;
                        line = str.Substring(index1, length);
                        Reader whatToAdd = new Reader();
                        whatToAdd.Deserialize(ref line);
                        whereToDeserialize.Add(whatToAdd);
                        index1 = index2 + 1;
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
