using UNADESKTask.Shapes.Triangle.Enum;

namespace UNADESKTask.Shapes.Triangle;

public class Triangle : ITriangle
{
    public Triangle(decimal a, decimal b, decimal c)
    {
        A = a;
        B = b;
        C = c;
    }

    private readonly decimal _a;

    public decimal A
    {
        get => _a;
        init
        {
            if (value <= 0)
            {
                throw new ArgumentException("Нельзя поставить отрицательное число");
            }

            _a = value;
        }
    }

    private readonly decimal _b;

    public decimal B
    {
        get => _b;
        init
        {
            if (value <= 0)
            {
                throw new ArgumentException("Нельзя поставить отрицательное число");
            }

            _b = value;
        }
    }

    private readonly decimal _c;

    public decimal C
    {
        get => _c;
        init
        {
            if (value <= 0)
            {
                throw new ArgumentException("Нельзя поставить отрицательное число");
            }

            _c = value;
        }
    }

    public TriangleTypeEnum GetTriangleType()
    {
        if (_a + _b <= _c || _a + _c <= _b || _b + _c <= _a)
        {
            throw new ArgumentException(
                "Введенные стороны некорректны. Такое может случиться, если треугольника не существует");
        }

        return IsTriangleObtuse(_a, _b, _c)
            ? TriangleTypeEnum.Obtuse
            : IsTriangleAcuteAngled(_a, _b, _c)
                ? TriangleTypeEnum.AcuteAngled
                : TriangleTypeEnum.Rectangular;
    }

    private bool IsTriangleObtuse(decimal a, decimal b, decimal c)
    {
        var tempArr = new List<decimal> { a, b, c };
        tempArr.Sort();
        return tempArr[0] * tempArr[0] + tempArr[1] * tempArr[1] < tempArr[2] * tempArr[2];
    }

    private bool IsTriangleAcuteAngled(decimal a, decimal b, decimal c)
    {
        var tempArr = new List<decimal> { a, b, c };
        tempArr.Sort();
        return tempArr[0] * tempArr[0] + tempArr[1] * tempArr[1] > tempArr[2] * tempArr[2];
    }
}