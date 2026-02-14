class Q888_FairCandySwap
{
    // This use one pass instead of nested n^2 approach
    // TC: O(n)
    // SC: O(n), n is distinct values from both Alice and Bob 
    public int[] FairCandySwap(int[] aliceSizes, int[] bobSizes)
    {
        var aliceSum = aliceSizes.Sum();
        var bobSum = bobSizes.Sum();
        var avg = (bobSum + aliceSum) / 2;
        var aliceDiffFromAvg = avg - aliceSum;

        var bobSet = new HashSet<int>(bobSizes);
        var aliceSet = new HashSet<int>(aliceSizes);
        foreach (var size in aliceSet)
        {
            if (bobSet.Contains(size + aliceDiffFromAvg))
            {
                return [size, size + aliceDiffFromAvg];
            }
        }

        return [0, 0];
    }
}

class Q888_FairCandySwapTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,1}, new int[] {2,2}, new int[] {1,2}],
        [new int[]{1,2}, new int[] {2,3}, new int[] {1,2}],
        [new int[]{2}, new int[] {1,3}, new int[] {2,3}],
        [new int[]{1,3}, new int[] {2}, new int[] {3,2}],
    ];
}

public class Q888_FairCandySwapTests
{
    [Theory]
    [ClassData(typeof(Q888_FairCandySwapTestData))]
    public void OfficialTestCases(int[] input1, int[] input2, int[] expected)
    {
        var sut = new Q888_FairCandySwap();
        var actual = sut.FairCandySwap(input1, input2);
        Assert.Equal(expected, actual);
    }
}
