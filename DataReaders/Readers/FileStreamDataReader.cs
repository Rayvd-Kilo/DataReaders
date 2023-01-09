using DataReaders.Readers.Interfaces;

namespace DataReaders.Readers
{
    public class FileStreamDataReader<T> : IFileReader<T>
    {
        T IFileReader<T>.ReadFile(string filePath, Func<FileStream, T> fileStreamInstruction)
        {
            using var reader = File.Open(filePath, FileMode.Open, FileAccess.Read);
            
            var data = fileStreamInstruction.Invoke(reader);
                
            reader.Close();

            return data;
        }
    }
}