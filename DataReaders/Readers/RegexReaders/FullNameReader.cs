using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

using DataReaders.Readers.Interfaces;

namespace DataReaders.Readers.RegexReaders
{
    public class FullNameReader : BaseReader<string>
    {
        public FullNameReader(ITableReader<string> tableReader) : base(tableReader,
            "[А-ЯЁ][а-яё]*.[А-ЯЁ][.][А-ЯЁ][.]") { }
        
        public override string[] ReadData(DataTable table)
        {
            var regex = new Regex(RegexPatten);

            return TableReader.ReadTableData(table, (rowIndex, columnIndex) =>
            {
                var results = regex.Matches(table.Rows[rowIndex][columnIndex].ToString() ?? string.Empty);

                var result = results.FirstOrDefault(x => x.Value != string.Empty)?.ToString();

                return result;
            });
        }
    }
}