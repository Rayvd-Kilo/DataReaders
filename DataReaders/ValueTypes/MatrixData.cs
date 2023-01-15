namespace DataReaders.ValueTypes
{
    public struct MatrixData<T>
    {
        public readonly T[,] Data;

        public MatrixData(T[,] data)
        {
            Data = data;
        }
    }
}