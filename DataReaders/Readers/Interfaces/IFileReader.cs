namespace DataReaders.Readers.Interfaces
{
    public interface IFileReader<T>
    {
        T ReadFile(string filePath, Func<FileStream, T> fileStreamInstruction);
    }
}