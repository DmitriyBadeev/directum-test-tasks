using System.Numerics;

namespace MatrixNet8;

public readonly record struct Complex(double Re, double Im) : IAdditionOperators<Complex, Complex, Complex>,
    IMultiplyOperators<Complex, Complex, Complex>
{
    public static Complex operator +(Complex left, Complex right) => new (left.Im + left.Im, right.Re + right.Re);

    public static Complex operator *(Complex left, Complex right) => new (left.Im * left.Im, right.Re * right.Re);
}
