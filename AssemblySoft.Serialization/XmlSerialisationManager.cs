using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace AssemblySoft.Serialization
{

    public class XmlSerialisationManager<T>
    {
        /// <summary>
        /// Serializes a a collection of objects as xml formatted
        /// </summary>
        /// <param name="items"></param>
        /// <param name="fileName"></param>
        public static void SerializeObjects(List<T> items, string fileName)
        {
            var path = Path.GetDirectoryName(fileName);
            if (path != null && !Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var serializer = new XmlSerializer(typeof(List<T>));
            using (var stream = File.Create(fileName))
            {
                serializer.Serialize(stream, items);
            }
        }

        /// <summary>
        /// Deserialises a collection of objects stored as an xml file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<T> DeserializeObjects(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            using (var stream = File.OpenRead(fileName))
            {
                try
                {
                    var items = (List<T>)(serializer.Deserialize(stream));
                    return items;
                }
                catch (Exception)
                {
                    throw;
                }                
            }
        }
        
        /// <summary>
        /// Deserialises a collection of string objects
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<T> DeserializeStringObjects(string objectData)
        {
            var serializer = new XmlSerializer(typeof(List<T>));

            try
            {
                using (TextReader reader = new StringReader(objectData))
                {
                    var items = (List<T>)(serializer.Deserialize(reader));
                    return items;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }  
    }

}
