class Q594_LongestHarmoniousSubsequence
{
    // TC: O(n)
    // SC: O(n)
    public int FindLHS(int[] nums) 
    {
        var dict = nums
            .GroupBy(n => n)
            .ToDictionary(group => group.Key, group => group.Count());

        var maxLength = 0;
        foreach(var pair in dict)
        {
            // find it's +1 exists, no need to check -1 as starting from the minimum all pairs will be bound in the 2 number sliding window
            // suppose in -1, 0, 1, 2, 3, at last 3 doesn't need to check 2 but 4 instead. However it won't find 4
            if(dict.TryGetValue(pair.Key+1, out var plusOneCount))
            {
                var pairLength = pair.Value + plusOneCount;
                if(pairLength > maxLength)
                {
                    maxLength = pairLength;
                }
            }    
        }

        return maxLength;
    }
}

class Q594_LongestHarmoniousSubsequenceTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{2,2,2,2,2,2,2,3,1,0,0,0,3,1,-1,0,1,1,0,0,1,1,2,2,2,0,1,2,2,3,2}, 20],
        [new int[]{1,2,1,3,0,0,2,2,1,3,3}, 6],
        [new int[]{1,3,2,2,5,2,3,7}, 5],
        [new int[]{1,2,3,4}, 2],
        [new int[]{1,1,1,1}, 0],
    ];
} 

public class Q594_LongestHarmoniousSubsequenceTests
{
    [Theory]
    [ClassData(typeof(Q594_LongestHarmoniousSubsequenceTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q594_LongestHarmoniousSubsequence();
        var actual = sut.FindLHS(input);
        Assert.Equal(expected, actual);
    }

}