using System.Text;

using DataReaders.Readers.Interfaces;

using Newtonsoft.Json;

namespace DataReaders.Readers.JSONReaders
{
    public class JsonReader<T> : IDataReader<T>
    {
        public T ReadData(IFileReader<T> fileReader, string filePath)
        {
            var jsonData = fileReader.ReadFile(filePath, stream =>
            {
                var buffer = new byte[stream.Length];

                stream.Read(buffer, 0, buffer.Length);

                var data = Encoding.Default.GetString(buffer);

                return DeserializeFile(data) ?? throw new InvalidOperationException();
            });

            return jsonData;
        }
        
        private T? DeserializeFile(string filePath)
        {
            return JsonConvert.DeserializeObject<T>(filePath);
        }
    } 
}

