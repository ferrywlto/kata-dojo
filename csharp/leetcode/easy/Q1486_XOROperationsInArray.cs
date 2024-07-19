
class Q1486_XOROperationsInArray
{
    public int XorOperation(int n, int start)
    {
        return 0;
    }
}
class Q1486_XOROperationsInArrayTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [5, 0, 8],
        [4, 3, 8],
    ];
}
public class Q1486_XOROperationsInArrayTests
{
    [Theory]
    [ClassData(typeof(Q1486_XOROperationsInArrayTestData))]
    public void OfficialTestCases(int input, int start, int expected)
    {
        var sut = new Q1486_XOROperationsInArray();
        var actual = sut.XorOperation(input, start);
        Assert.Equal(expected, actual);
    }
}