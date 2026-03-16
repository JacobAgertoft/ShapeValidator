namespace ShapeValidator;

/// <summary>
/// Represents a shape that can classify itself into a well-defined type.
/// </summary>
public interface IShape<TShapeType> where TShapeType : Enum
{
    /// <summary>
    /// Classifies the current instance and returns the resulting classification value.
    /// </summary>
    /// <returns> The classification result. </returns>
    TShapeType Classify();
}