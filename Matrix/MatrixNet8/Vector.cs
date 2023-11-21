using System.Numerics;

namespace MatrixNet8;

public readonly record struct Vector(int X, int Y) : IAdditionOperators<Vector, Vector, Vector>, IMultiplyOperators<Vector, Vector, Vector>
{
    public static Vector operator +(Vector left, Vector right) => new (left.X + left.X, right.Y + right.Y);

    public static Vector operator *(Vector left, Vector right) => new(left.X * left.X, right.Y * right.Y);
}