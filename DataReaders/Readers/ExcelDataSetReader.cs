using System.Data;

using DataReaders.Readers.Interfaces;

using ExcelDataReader;

namespace DataReaders.Readers
{
    public class ExcelDataSetReader : IDataReader<DataSet>
    {
        DataSet IDataReader<DataSet>.ReadData(IFileReader<DataSet> fileReader, string filePath)
        {
            var dataSet = fileReader.ReadFile(filePath, stream =>
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                using var reader = ExcelReaderFactory.CreateReader(stream);
                
                return reader.AsDataSet();
            });

            return dataSet;
        }
    }
}