namespace Matrix;

public class IntegerMatrix : IMatrix
{
    private readonly int[][] _matrixValues;

    public int RowsCount { get; }
    public int ColsCount { get; }
    
    public IntegerMatrix(int rows, int cols)
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
    
    public IntegerMatrix Multiply(IntegerMatrix otherMatrix)
    {
        var resultMatrix = new IntegerMatrix(RowsCount, otherMatrix.ColsCount);
        
        for (var i = 0; i < RowsCount; i++)
        for (var j = 0; j < otherMatrix.ColsCount; j++)
        for (var k = 0; k < otherMatrix.RowsCount; k++)
        {
            resultMatrix[i, j] += this[i, k] * otherMatrix[k, j];
        }

        return resultMatrix;
    }
}