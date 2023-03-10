using System.Data;
using System.Text.RegularExpressions;

using DataReaders.Readers.Interfaces;

namespace DataReaders.Readers.RegexReaders
{
    public class UniqStringsRegexTableReader : BaseRegexTableReader<string>
    {
        public UniqStringsRegexTableReader(ITableReader<string> tableReader, string regex) : base(tableReader,
            regex) { }
        
        public override string[] ReadData(DataTable table)
        {
            var regex = new Regex(RegexPatten);

            return TableReader.ReadTableData(table, (rowIndex, columnIndex) =>
            {
                var results = regex.Matches(table.Rows[rowIndex][columnIndex].ToString() ?? string.Empty);

                var result = results.FirstOrDefault(x => x.Value != string.Empty)?.ToString();

                if (result != null) return result;
                
                return default!;
            });
        }
    }
}