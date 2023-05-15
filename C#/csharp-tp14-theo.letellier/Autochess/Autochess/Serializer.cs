using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace Autochess
{
    public static class Serializer
    {
        public static class Xml
        {
            /// <summary>
            /// Writes the given object instance to an XML file.
            /// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
            /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [XmlIgnore] attribute.</para>
            /// <para>Object type must have a parameter less constructor.</para>
            /// </summary>
            /// <typeparam Name="T">The type of object being written to the file.</typeparam>
            /// <param Name="path">The file path to write the object instance to.</param>
            /// <param Name="objectToWrite">The object instance to write to the file.</param>
            /// <param Name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
            public static void ToFile<T>(string filePath, T objectToWrite, bool append = false)
            {
                TextWriter writer = null;
                try
                {
                    var serializer = new XmlSerializer(typeof(T));
                    writer = new StreamWriter(filePath, append);
                    serializer.Serialize(writer, objectToWrite);
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }
            }

            /// <summary>
            /// Reads an object instance from an XML file.
            /// <para>Object type must have a parameter less constructor.</para>
            /// </summary>
            /// <typeparam Name="T">The type of object to read from the file.</typeparam>
            /// <param Name="path">The file path to read the object instance from.</param>
            /// <returns>Returns a new instance of the object read from the XML file.</returns>
            public static T FromFile<T>(string path)
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException($"{path}: File not found.");
                
                TextReader reader = null;
                T obj = default;
                
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    reader = new StreamReader(path);
                    obj = (T) serializer.Deserialize(reader);
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }

                return obj;
            }
        }

        public static class Json
        {
            public static readonly DataContractJsonSerializerSettings Settings =
                new DataContractJsonSerializerSettings
                    {UseSimpleDictionaryFormat = true};

            public static void ToFile<T>(T obj, string path, bool append = false) where T : new()
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T), Settings);
                using (FileStream file = new FileStream(path, append ? FileMode.Append : FileMode.Create))
                {
                    using (var writer =
                        JsonReaderWriterFactory.CreateJsonWriter(file, Encoding.UTF8, true, true, "    "))
                    {
                        serializer.WriteObject(writer, obj);
                        writer.Flush();
                    }
                }
            }

            public static T FromFile<T>(string path)
            {
                if (!File.Exists(path))
                    return default;
                
                T obj = default;
                FileStream reader = null;
                try
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer((typeof(T)));
                    reader = new FileStream(path, FileMode.Open);
                    obj = (T) serializer.ReadObject(reader);
                }
                catch (FileNotFoundException e)
                {
                    
                    Console.WriteLine($"{path}: File not found.");
                    Environment.Exit(2);
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }

                return obj;
            }
        }
    }
}
