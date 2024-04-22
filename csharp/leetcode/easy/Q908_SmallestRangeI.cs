
class Q908_SmallestRangeI
{
    public int SmallestRangeI(int[] nums, int k)
    {
        return 0;
    }
}

class Q908_SmallestRangeITestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{0}, 0, 0],
        [new int[]{0,10}, 2, 6],
        [new int[]{1,3,6}, 3, 0],
    ];
}

public class Q908_SmallestRangeITests
{
    [Theory]
    [ClassData(typeof(Q908_SmallestRangeITestData))]
    public void OfficialTestCases(int[] input, int k, int expected)
    {
        var sut = new Q908_SmallestRangeI();
        var actual = sut.SmallestRangeI(input, k);
        Assert.Equal(expected, actual);
    }
}