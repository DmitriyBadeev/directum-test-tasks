namespace Matrix;

public readonly record struct Vector(int X, int Y);

public class VectorMatrix : IMatrix
{
    private readonly Vector[][] _matrixValues;

    public int RowsCount { get; }
    public int ColsCount { get; }
    
    public VectorMatrix(int rows, int cols)
    {
        var intList = new Vector[rows][];
        
        for (var i = 0; i < rows; i++)
        {
            var subArray = new Vector[cols];
            for (var j = 0; j < cols; j++)
            {
                subArray[j] = default;
            }
            intList[i] = subArray;
        }

        _matrixValues = intList;
        RowsCount = rows;
        ColsCount = cols;
    }

    public Vector this[int rowIndex, int columnIndex]
    {
        get => _matrixValues[rowIndex][columnIndex];
        set => _matrixValues[rowIndex][columnIndex] = value;
    }

    public VectorMatrix Multiply(VectorMatrix otherMatrix)
    {
        var resultMatrix = new VectorMatrix(RowsCount, otherMatrix.ColsCount);
        
        for (var i = 0; i < RowsCount; i++)
        for (var j = 0; j < otherMatrix.ColsCount; j++)
        for (var k = 0; k < otherMatrix.RowsCount; k++)
        {
            var x1 = this[i, k].X;
            var x2 = otherMatrix[k, j].X;
            
            var y1 = this[i, k].Y;
            var y2 = otherMatrix[k, j].Y;

            var vector = resultMatrix[i, j];
            
            var newX = vector.X + x1 * x2;
            var newY = vector.Y + y1 * y2;

            resultMatrix[i, j] = new Vector(newX, newY);
        }

        return resultMatrix;
    }
}
