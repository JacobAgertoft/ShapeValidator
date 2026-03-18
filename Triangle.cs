namespace ShapeValidator;

/// <summary>
/// Represents a triangle defined by the lengths of its three sides.
/// </summary>
public sealed class Triangle : IShape<TriangleType>
{
    // Epsilon for floating-point comparisons.
    // This handles cases like 1.0000000001 vs 1.0 caused by floating-point arithmetic.
    private const double Epsilon = 1e-9;

    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;

    /// <summary>
    /// ctor.
    /// </summary>
    private Triangle(double sideA, double sideB, double sideC)
    {
        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
    }

    /// <inheritdoc/>
    public TriangleType Classify()
    {
        if (AreEqual(_sideA, _sideB) && AreEqual(_sideB, _sideC))
            return TriangleType.Equilateral;

        if (AreEqual(_sideA, _sideB) || AreEqual(_sideB, _sideC) || AreEqual(_sideA, _sideC))
            return TriangleType.Isosceles;

        return TriangleType.Scalene;
    }

    /// <summary>
    /// Attempts to create a valid triangle from three side lengths.
    /// </summary>
    /// <returns> A Result containing the Triangle if successful, or an error message if validation fails.</returns>
    public static Result<Triangle> TryCreateTriangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            return Result<Triangle>.Failure("All sides must be positive numbers.");
        }

        if (!SatisfiesTriangleInequality(sideA, sideB, sideC))
        {
            return Result<Triangle>.Failure(
                "The given sides do not form a valid triangle. " +
                "The sum of any two sides must be greater than the third.");
        }

        return Result<Triangle>.Success(new Triangle(sideA, sideB, sideC));
    }

    /// <summary>
    /// The triangle inequality: the sum of any two sides must be greater than the third side.
    /// </summary>
    private static bool SatisfiesTriangleInequality(double a, double b, double c)
    {
        if (a + b <= c)
            return false;

        else if (a + c <= b)
            return false;

        else if (b + c <= a)
            return false;

        return true;
    }

    /// <summary>
    /// Compares two lengths using an epsilon to avoid false negatives.
    /// </summary>
    private static bool AreEqual(double x, double y)
    {
        return Math.Abs(x - y) < Epsilon;
    }
}
