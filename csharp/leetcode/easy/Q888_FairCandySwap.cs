public class Q888_FairCandySwap
{
    public int[] FairCandySwap(int[] aliceSizes, int[] bobSizes) 
    {
        return [0,0];    
    }
}

public class Q888_FairCandySwapTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,1}, new int[] {2,2}, new int[] {1,2}],
        [new int[]{1,2}, new int[] {2,3}, new int[] {1,2}],
        [new int[]{2}, new int[] {1,3}, new int[] {2,3}],
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