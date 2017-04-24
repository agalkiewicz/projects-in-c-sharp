using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System;

namespace Library.Serialization
{
    public class JsonConverter : IConverter
    {   
        public void Deserialize(string fileName, ref Dictionary<uint, Book> whereToDeserialize)
        {
            fileName += ".json";
            try
            {
                whereToDeserialize = JsonConvert.DeserializeObject<Dictionary<uint, Book>>(File.ReadAllText(@fileName),
                    new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (JsonException e)
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
        
        public void Deserialize<T>(string fileName, ref ICollection<T> whereToDeserialize)
        {
            fileName += ".json";
            try
            {
                whereToDeserialize = JsonConvert.DeserializeObject<ICollection<T>>(File.ReadAllText(@fileName),
                    new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (JsonException e)
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

        public void Serialize<T>(string fileName, ICollection<T> whatToSerialize)
        {
            fileName += ".json";
            try
            {
                File.WriteAllText(@fileName, JsonConvert.SerializeObject(whatToSerialize, Formatting.Indented));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (JsonException e)
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
