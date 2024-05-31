class Q1046_LastStoneWeight
{

    public int LastStoneWeight(int[] stones)
    {
        return 0;
    }
}

class Q1046_LastStoneWeightTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{2,7,4,1,8,1}, 1],
        [new int[]{1}, 1],
    ];
}

public class Q1046_LastStoneWeightTests
{
    [Theory]
    [ClassData(typeof(Q1046_LastStoneWeightTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1046_LastStoneWeight();
        var actual = sut.LastStoneWeight(input);
        Assert.Equal(expected, actual);
    }
}