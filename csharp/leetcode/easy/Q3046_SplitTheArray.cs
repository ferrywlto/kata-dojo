public class Q3046_SplitTheArray
{
    public bool IsPossibleToSplit(int[] nums)
    {
        return false;
    }
    public static TheoryData<int[], bool> TestData => new()
    {
        {[1,1,2,2,3,4], true},
        {[1,1,1,1], false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = IsPossibleToSplit(input);
        Assert.Equal(expected, actual);
    }
}