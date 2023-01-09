using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using DataReaders.Readers.Interfaces;

namespace DataReaders.Readers.DataSetReader
{
    public class TableReader<T> : ITableReader<T>
    {
        private readonly IEqualityComparer<T> _comparer = EqualityComparer<T>.Default;
        
        public T[] ReadTableData(DataTable table, Func<int,int,T> readerFunc)
        {
            var data = new HashSet<T>();

            for (int i = 0; i < table.Columns.Count; i++)
            {
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    var value = readerFunc.Invoke(j, i);

                    if (value != null && !IsDefault(value))
                    {
                        data.Add(value);
                    }
                }
            }

            return data.ToArray();
        }
        
        private bool IsDefault(T t) {
            return _comparer.Equals(t, default);
        }
    }
}