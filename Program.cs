using System.Globalization;
using ShapeValidator;

Console.WriteLine("Triangle Type Classifier");

IShape<TriangleType> triangle = ReadTriangle();

Console.WriteLine($"\nResult: {triangle.Classify()}");

/// <summary>
/// Prompts the user for three side lengths and repeats until a valid triangle
/// is formed.
/// </summary>
static IShape<TriangleType> ReadTriangle()
{
    while (true)
    {
        double a = ReadSide("Enter length of side A: ");
        double b = ReadSide("Enter length of side B: ");
        double c = ReadSide("Enter length of side C: ");

        var result = Triangle.TryCreateTriangle(a, b, c);

        if (result.IsSuccess)
        {
            return result.Value;
        }

        Console.WriteLine($"\nInvalid triangle: {result.Error}");
        Console.WriteLine("Please re-enter all three sides.\n");
    }
}

/// <summary>
/// Prompts the user until they enter a valid number. Non-numeric input is rejected here.
/// </summary>
static double ReadSide(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
            return value;

        Console.WriteLine("Please enter a valid number.");
    }
}
