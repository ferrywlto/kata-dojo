public class Q3697_ComputeDecimalRepresentation
{
    public int[] DecimalRepresentation(int n)
    {
        return [];
    }
    public static TheoryData<int, int[]> TestData => new TheoryData<int, int[]>
    {
      {537, [500,30,7]},
      {102, [100,2]},
      {6, [6]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[] expected)
    {
        var result = DecimalRepresentation(n);
        Assert.Equal(expected, result);
    }
}
