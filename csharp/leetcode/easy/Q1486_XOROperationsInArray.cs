class Q1486_XOROperationsInArray
{
    // TC: O(n), where n is the size of n, it will perform XOR n times
    // SC: O(1), the space used are fixed to 2 integer variables
    public int XorOperation(int n, int start)
    {
        var result = start;
        var current = start;
        for (var i = 0; i < n - 1; i++)
        {
            current += 2;
            result ^= current;
        }
        return result;
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
