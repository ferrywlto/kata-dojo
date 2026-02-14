class Q961_NRepeatedElementIn2NArray
{
    // TC: O(n), worst case nums length / 2
    // SC: O(n), worst case need to store all unique number if the repeated one is all packed at the end
    public int RepeatedNTimes(int[] nums)
    {
        // since in an array of 2N size that have a N+1 unique elements and one of them repearted N times
        // 2N = N(repeated num) + (N - 1 + 1 remaining unique elements)
        // that means the only repeated element is the answer

        var hashset = new HashSet<int>();
        foreach (var n in nums)
        {
            if (!hashset.Add(n)) return n;
        }
        return 0;
    }
}

class Q961_NRepeatedElementIn2NArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,2,3,3}, 3],
        [new int[] {2,1,2,5,3,2}, 2],
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
