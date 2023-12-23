public class Q26_RemoveDuplicatesTests
{
    [Theory]
    [InlineData(new int[] { 1, 1, 2 }, 2)]
    [InlineData(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)]
    public void OfficialTestCases(int[] nums, int expected)
    {
        var sut = new Q26_RemoveDuplicates();
        var actual = sut.RemoveDuplicates(nums);
        Assert.Equal(expected, actual);
    }
}
public class Q26_RemoveDuplicates
{
    public int RemoveDuplicates(int[] nums)
    {
        return 0;
    }
}