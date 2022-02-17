using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace CIFER.Tech.Utils
{
    /// <summary>
    /// XML関連のUtils
    /// </summary>
    public static class CiferTechXmlUtils
    {
        // シリアライズ
        public static T Serialize<T>(string path, T data)
        {
            CiferTechUtils.CreateDirectory(path);

            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                var serializer = new XmlSerializer(typeof(T));
                var streamWriter = new StreamWriter(stream, System.Text.Encoding.UTF8);
                serializer.Serialize(streamWriter, data);
                streamWriter.Close();
            }

            return data;
        }

        // デシリアライズ
        public static T Deserialize<T>(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T) serializer.Deserialize(stream);
            }
        }
    }
}