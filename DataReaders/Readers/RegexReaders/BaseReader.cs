using System.Data;

using DataReaders.Readers.Interfaces;

namespace DataReaders.Readers.RegexReaders
{
    public abstract class BaseReader<T>
    {
        protected readonly string RegexPatten;
        
        protected readonly ITableReader<T> TableReader;

        protected BaseReader(ITableReader<T> tableReader, string regexPatten)
        {
            TableReader = tableReader;
            
            RegexPatten = regexPatten;
        }

        public abstract T[] ReadData(DataTable table);
    }
}