public class Q1752_CheckIfArrayIsSortedAndRotated
{
    public bool Check(int[] nums)
    {
        return false;
    }
    public static TheoryData<int[], bool> TestData => new()
    {
        {[3,4,5,1,2], true},
        {[2,1,3,4], false},
        {[1,2,3], true},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = Check(input);
        Assert.Equal(expected, actual);
    }
}