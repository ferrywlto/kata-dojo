public class Q3151_SpecialArrayI
{
    public bool IsArraySpecial(int[] nums)
    {
        return false;
    }
    public static TheoryData<int[], bool> TestData => new()
    {
        {[1], true},
        {[2,1,4], true},
        {[4,3,1,6], false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = IsArraySpecial(input);
        Assert.Equal(expected, actual);
    }
}