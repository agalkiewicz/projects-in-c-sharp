using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Collections.Generic;

namespace Library.Serialization
{
    public class XMLConverter : IConverter
    {
        private FileStream fs;
        private XmlDictionaryReader reader;
        private XmlDictionaryWriter writer;

        public void Deserialize<T>(string fileName, ref ICollection<T> whereToDeserialize)
        {
            fileName += ".xml";
            try
            {
                fs = new FileStream(fileName, FileMode.Open);
                reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                NetDataContractSerializer ser = new NetDataContractSerializer();
                whereToDeserialize = (ICollection<T>)ser.ReadObject(reader, true);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SerializationException e)
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
            finally
            {
                if (reader != null) reader.Dispose();
                if (fs != null) fs.Dispose();
            }
        }

        public void Serialize<T>(string fileName, ICollection<T> whatToSerialize)
        {
            fileName += ".xml";
            try
            {
                fs = new FileStream(fileName, FileMode.OpenOrCreate);
                writer = XmlDictionaryWriter.CreateTextWriter(fs);
                NetDataContractSerializer ser = new NetDataContractSerializer();
                ser.WriteObject(writer, whatToSerialize);
            }
            catch (SerializationException e)
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
            finally
            {
                if (reader != null) writer.Dispose();
                if (fs != null) fs.Dispose();
            }
        }
    }
}
