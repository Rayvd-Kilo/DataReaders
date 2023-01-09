namespace DataReaders.Readers.Interfaces
{
    public interface IDataReader<T>
    {
        T ReadData(IFileReader<T> fileReader, string filePath);
    }
}