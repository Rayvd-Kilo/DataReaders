using System.Data;
using System.Numerics;
using System.Text.RegularExpressions;

using DataReaders.Readers.Interfaces;
using DataReaders.ValueTypes;

namespace DataReaders.Readers.RegexReaders
{
    public class DateRegexTableReader : BaseRegexTableReader<DataInMatrix<string>>
    {
        public DateRegexTableReader(ITableReader<DataInMatrix<string>> tableReader) : base(tableReader,
            "^[А-Я]{5,999}[ ]*[–|-][ ]*[0-9]*[ ][А-Я]*") {}

        public override DataInMatrix<string>[] ReadData(DataTable table)
        {
            var regex = new Regex(RegexPatten);
            
            return TableReader.ReadTableData(table, (rowIndex, columnIndex) =>
            {
                var results = regex.Matches(table.Rows[rowIndex][columnIndex].ToString() ?? string.Empty);
                
                var value = new DataInMatrix<string?>(
                    results.FirstOrDefault(x => x.Value != string.Empty)?.Value,
                    new Vector2(rowIndex, columnIndex));

                return (value.DataValue == null ? default : value)!;
            });
        }
    }
}