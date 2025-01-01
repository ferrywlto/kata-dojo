public class Q2784_CheckIfArrayIsGood
{
    public bool IsGood(int[] nums)
    {
        return false;
    }
    public static TheoryData<int[], bool> TestData => new()
    {
        {[2, 1, 3], false},
        {[1, 3, 3, 2], true},
        {[1, 1], true},
        {[3, 4, 4, 1, 2, 1], false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = IsGood(input);
        Assert.Equal(expected, actual);
    }
}