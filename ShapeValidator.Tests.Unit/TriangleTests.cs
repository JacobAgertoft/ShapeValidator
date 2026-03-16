namespace ShapeValidator.Tests.Unit;

[TestFixture]
public class TriangleTests
{
    [TestCase(0, 1, 1)]
    [TestCase(1, 0, 1)]
    [TestCase(1, 1, 0)]
    [TestCase(-1, 2, 2)]
    [TestCase(2, -1, 2)]
    [TestCase(2, 2, -1)]
    public void NonPositiveSideLengthsTest(double a, double b, double c)
    {
        var result = Triangle.TryCreateTriangle(a, b, c);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Error, Is.Not.Null.And.Not.Empty);
    }

    [TestCase(1, 2, 10)]
    [TestCase(1, 10, 2)]
    [TestCase(10, 1, 2)]
    [TestCase(1, 1, 2)]
    public void TriangleInequalityViolatedTest(double a, double b, double c)
    {
        var result = Triangle.TryCreateTriangle(a, b, c);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Error, Is.Not.Null.And.Not.Empty);
    }

    [TestCase(3, 4, 5)]
    [TestCase(5, 5, 5)]
    [TestCase(5, 5, 3)]
    [TestCase(0.1, 0.1, 0.1)]
    public void ValidSidesTest(double a, double b, double c)
    {
        var result = Triangle.TryCreateTriangle(a, b, c);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Value, Is.Not.Null);
    }

    [TestCase(5, 5, 5)]
    [TestCase(1, 1, 1)]
    [TestCase(100, 100, 100)]
    public void CreateEquilateralTest(double a, double b, double c)
    {
        var triangle = Triangle.TryCreateTriangle(a, b, c).Value;

        Assert.That(triangle.Classify(), Is.EqualTo(TriangleType.Equilateral));
    }

    [TestCase(5, 5, 3)]
    [TestCase(5, 3, 5)]
    [TestCase(3, 5, 5)]
    public void CreateIsoscelesTest(double a, double b, double c)
    {
        var triangle = Triangle.TryCreateTriangle(a, b, c).Value;

        Assert.That(triangle.Classify(), Is.EqualTo(TriangleType.Isosceles));
    }

    [TestCase(3, 4, 5)]
    [TestCase(6, 7, 8)]
    [TestCase(5, 12, 13)]
    public void CreateScaleneTest(double a, double b, double c)
    {
        var triangle = Triangle.TryCreateTriangle(a, b, c).Value;

        Assert.That(triangle.Classify(), Is.EqualTo(TriangleType.Scalene));
    }

    [Test]
    public void FailureThrowsInvalidOperationExceptionTest()
    {
        var result = Triangle.TryCreateTriangle(-1, -1, -1);

        Assert.That(() => result.Value, Throws.InvalidOperationException);
    }
}
