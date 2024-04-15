public class Q492_ConstructTheRectangle
{
    public int[] ConstructRectangle(int area)
    {
        var sqrt = Math.Sqrt(area);
        var sqrt_int = (int)sqrt;

        if (sqrt_int * sqrt_int == area) 
            return [sqrt_int, sqrt_int];
        
        for(var i=sqrt_int; i>0; i--)
        {
            if(area % i == 0) return [area / i, i];
        }

        return [area, 1];
    }
}

public class Q492_ConstructTheRectangleTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [2, new int[] { 2, 1 }],
        [4, new int[] { 2, 2 }],
        [6, new int[] { 3, 2 }],
        [37, new int[] { 37, 1 }],
        [122122, new int[] { 427, 286 }],
    ];
}

public class Q492_ConstructTheRectangleTests
{
    [Theory]
    [ClassData(typeof(Q492_ConstructTheRectangleTestData))]
    public void OfficialTestCases(int input, int[] expected)
    {
        var sut = new Q492_ConstructTheRectangle();
        var actual = sut.ConstructRectangle(input);
        Assert.Equal(expected, actual);
    }
}