class Q961_NRepeatedElementIn2NArray
{
    public int RepeatedNTimes(int[] nums)
    {
        return 0;
    }
}

class Q961_NRepeatedElementIn2NArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,2,3,3}, 3],
        [new int[] {2,1,2,5,3,2}, 0],
        [new int[] {5,1,5,2,5,3,5,4}, 5],
    ];
}

public class Q961_NRepeatedElementIn2NArrayTests
{
    [Theory]
    [ClassData(typeof(Q961_NRepeatedElementIn2NArrayTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q961_NRepeatedElementIn2NArray();
        var actual = sut.RepeatedNTimes(input);
        Assert.Equal(expected, actual);
    }
}