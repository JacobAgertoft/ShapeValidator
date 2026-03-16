namespace ShapeValidator;

/// <summary>
/// Classifies a triangle by the relationship between its side lengths.
/// </summary>
public enum TriangleType
{
    /// All three sides are equal.
    Equilateral,

    /// Exactly two sides are equal.
    Isosceles,

    /// All three sides are different lengths.
    Scalene
}
