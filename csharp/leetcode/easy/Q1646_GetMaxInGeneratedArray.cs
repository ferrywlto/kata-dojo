class Q1646_GetMaxInGeneratedArray
{
    // TC: O(n), scale with how large n is
    // SC: O(n), scale with how large n is, as have to cache value for fast calculation
    public int GetMaximumGenerated(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        var nums = new int[n + 1];
        nums[0] = 0;
        nums[1] = 1;
        var max = 1;
        
        for (var i = 2; i <= n; i++)
        {
            var temp = nums[i / 2];
            if (i % 2 != 0)
                temp += nums[i / 2 + 1];

            nums[i] = temp;
            if (temp > max) max = temp;
        }
        return max;
    }
}
class Q1646_GetMaxInGeneratedArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [7,3],
        [2,1],
        [3,2],
    ];
}
public class Q1646_GetMaxInGeneratedArrayTests
{
    [Theory]
    [ClassData(typeof(Q1646_GetMaxInGeneratedArrayTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q1646_GetMaxInGeneratedArray();
        var actual = sut.GetMaximumGenerated(input);
        Assert.Equal(expected, actual);
    }
}