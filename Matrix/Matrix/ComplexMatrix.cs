namespace Matrix;

public readonly record struct Complex(double Re, double Im);

public class ComplexMatrix : IMatrix
{
    private readonly Complex[][] _matrixValues;

    public int RowsCount { get; }
    public int ColsCount { get; }
    
    public ComplexMatrix(int rows, int cols)
    {
        var intList = new Complex[rows][];
        
        for (var i = 0; i < rows; i++)
        {
            var subArray = new Complex[cols];
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
    
    public Complex this[int rowIndex, int columnIndex]
    {
        get => _matrixValues[rowIndex][columnIndex];
        set => _matrixValues[rowIndex][columnIndex] = value;
    }

    public ComplexMatrix Multiply(ComplexMatrix otherMatrix)
    {
        var resultMatrix = new ComplexMatrix(RowsCount, otherMatrix.ColsCount);

        for (var i = 0; i < RowsCount; i++)
        for (var j = 0; j < otherMatrix.ColsCount; j++)
        for (var k = 0; k < otherMatrix.RowsCount; k++)
        {
            var r1 = this[i, k].Re;
            var r2 = otherMatrix[k, j].Re;
            var i1 = this[i, k].Im;
            var i2 = otherMatrix[k, j].Im;

            var newRe = resultMatrix[i, j].Re + r1 * r2;
            var newIm = resultMatrix[i, j].Im + i1 * i2;

            resultMatrix[i, j] = new Complex(newRe, newIm);
        }

        return resultMatrix;
    }
}