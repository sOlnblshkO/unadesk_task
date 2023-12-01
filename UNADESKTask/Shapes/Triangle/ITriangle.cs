using UNADESKTask.Shapes.Triangle.Enum;

namespace UNADESKTask.Shapes.Triangle;

public interface ITriangle : IShape
{
    #region Стороны треугольника

    public decimal A { get; init; }
    public decimal B { get; init; }
    public decimal C { get; init; }

    #endregion

    public TriangleTypeEnum GetTriangleType();
}