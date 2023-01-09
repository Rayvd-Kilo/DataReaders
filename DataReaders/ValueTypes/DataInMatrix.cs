using System.Numerics;

namespace DataReaders.ValueTypes
{
    public struct DataInMatrix<T>
    {
        public T DataValue;
        public Vector2 MatrixIndexes;

        public DataInMatrix(T value, Vector2 matrixIndexes)
        {
            DataValue = value;
            MatrixIndexes = matrixIndexes;
        }
    }
}