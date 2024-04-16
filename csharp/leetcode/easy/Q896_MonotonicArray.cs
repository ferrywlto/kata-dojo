public class Q896_MonotonicArray
{
    public bool IsMonotonic(int[] nums) 
    {
        return false;    
    }    
}

public class Q896_MonotonicArrayTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,2,2,3}, true],
        [new int[]{6,5,4,4}, true],
        [new int[]{1,3,2}, false],
        [new int[]{-1,-2,-2,-3}, true],
        [new int[]{-6,-5,-4,-4}, true],
        [new int[]{-1,-3,-2}, false],
        [new int[]{-1,0,1}, true],
        [new int[]{0,0,0}, true],
    ];
}

public class Q896_MonotonicArrayTests
{
    [Theory]
    [ClassData(typeof(Q896_MonotonicArrayTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q896_MonotonicArray();
        var actual = sut.IsMonotonic(input);
        Assert.Equal(expected, actual);
    }
}