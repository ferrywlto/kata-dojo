namespace dojo.leetcode;

public class Q674_LongestContinuousIncreasingSubSequence
{
    public int FindLengthOfLCIS(int[] nums) 
    {
        return 0;    
    }
}

public class Q674_LongestContinuousIncreasingSubSequenceTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {1,3,5,4,7}, 3],
        [new int[] {2,2,2,2,2}, 1],
    ];
}

public class Q674_LongestContinuousIncreasingSubSequenceTest
{
    [Theory]
    [ClassData(typeof(Q674_LongestContinuousIncreasingSubSequenceTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q674_LongestContinuousIncreasingSubSequence();
        var actual = sut.FindLengthOfLCIS(input);
        Assert.Equal(expected, actual);
    }
}