using System.Numerics;

namespace MatrixNet8;

public class Matrix<TValue> where TValue : IAdditionOperators<TValue, TValue, TValue>, IMultiplyOperators<TValue, TValue, TValue>
{
    private readonly int[][] _matrixValues;

    public int RowsCount { get; }
    public int ColsCount { get; }

    public Matrix(int rows, int cols)
    {
        var intList = new int[rows][];
        
        for (var i = 0; i < rows; i++)
        {
            var subArray = new int[cols];
            for (var j = 0; j < cols; j++)
            {
                subArray[j] = 0;
            }
            intList[i] = subArray;
        }
        
        _matrixValues = intList;
        RowsCount = rows;
        ColsCount = cols;
    }

    public int this[int rowIndex, int columnIndex]
    {
        get => _matrixValues[rowIndex][columnIndex];
        set => _matrixValues[rowIndex][columnIndex] = value;
    }
    
    public Matrix<TValue> Multiply(Matrix<TValue> otherMatrix)
    {
        var resultMatrix = new Matrix<TValue>(RowsCount, otherMatrix.ColsCount);
        
        for (var i = 0; i < RowsCount; i++)
        for (var j = 0; j < otherMatrix.ColsCount; j++)
        for (var k = 0; k < otherMatrix.RowsCount; k++)
        {
            resultMatrix[i, j] += this[i, k] * otherMatrix[k, j];
        }

        return resultMatrix;
    }
}