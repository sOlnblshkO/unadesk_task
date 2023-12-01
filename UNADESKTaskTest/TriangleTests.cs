using UNADESKTask.Shapes.Triangle;
using UNADESKTask.Shapes.Triangle.Enum;
using Xunit;

namespace UNADESKTaskTest;

public class TriangleTests
{
    [Theory]
    [InlineData(2, 3, -4)]
    [InlineData(2, -3, 4)]
    [InlineData(-2, 3, 4)]
    [InlineData(-2, -3, 4)]
    [InlineData(2, -3, -4)]
    [InlineData(-2, -3, -4)]
    public void Should_Throw_Exception_On_Negative_Values(decimal a, decimal b, decimal c)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }
    
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(3, 2, 1)]
    [InlineData(2, 3, 1)]
    [InlineData(2, 3, 0.99)]
    [InlineData(2, 1.99, 4.01)]
    public void Should_Throw_Exception_On_Does_Not_Exists_Triangle(decimal a, decimal b, decimal c)
    {
        var triangle = new Triangle(a, b, c);
        Assert.Throws<ArgumentException>(() => triangle.GetTriangleType());
    }

    [Theory]
    [InlineData(9, 5, 6)]
    [InlineData(5, 9, 6)]
    [InlineData(5, 6, 9)]
    [InlineData(9, 6, 5)]
    public void Should_Return_Obtuse_Result(decimal a, decimal b, decimal c)
    {
        var triangle = new Triangle(a, b, c);
        Assert.Equal(TriangleTypeEnum.Obtuse, triangle.GetTriangleType());
    }
    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(3, 5, 4)]
    [InlineData(4, 3, 5)]
    [InlineData(4, 5, 3)]
    public void Should_Return_Rectangular_Result(decimal a, decimal b, decimal c)
    {
        var triangle = new Triangle(a, b, c);
        Assert.Equal(TriangleTypeEnum.Rectangular, triangle.GetTriangleType());
    }
    
    [Theory]
    [InlineData(5, 5, 6)]
    [InlineData(5, 6, 5)]
    [InlineData(6, 5, 5)]
    [InlineData(6.01, 5, 5)]
    [InlineData(3.01, 4.01, 5.01)]
    public void Should_Return_AcuteAngled_Result(decimal a, decimal b, decimal c)
    {
        var triangle = new Triangle(a, b, c);
        Assert.Equal(TriangleTypeEnum.AcuteAngled, triangle.GetTriangleType());
    }
}