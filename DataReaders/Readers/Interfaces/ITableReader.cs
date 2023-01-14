using System.Data;

namespace DataReaders.Readers.Interfaces
{
    public interface ITableReader<T>
    {
        T[] ReadTableData(DataTable table, Func<int, int, T> readerFunc);
    }
}