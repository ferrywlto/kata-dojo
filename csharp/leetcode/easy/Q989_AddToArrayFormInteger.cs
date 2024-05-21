class Q989_AddToArrayFormInteger
{
    public IList<int> AddToArrayForm(int[] num, int k)
    {
        return [];
    }
}

class Q989_AddToArrayFormIntegerTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,2,0,0}, 34, new int[]{1,2,3,4}],
        [new int[]{2,7,4}, 181, new int[]{4,5,5}],
        [new int[]{2,1,5}, 806, new int[]{1,0,2,1}],
    ];
}

public class Q989_AddToArrayFormIntegerTests
{
    [Theory]
    [ClassData(typeof(Q989_AddToArrayFormIntegerTestData))]
    public void OfficialTestCases(int[] input, int k, int[] expected)
    {
        var sut = new Q989_AddToArrayFormInteger();
        var actual = sut.AddToArrayForm(input, k);
        Assert.Equal(expected, actual);
    }
}