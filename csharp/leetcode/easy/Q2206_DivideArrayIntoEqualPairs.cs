public class Q2206_DivideArrayIntoRqualPairs
{
    public bool DivideArray(int[] nums)
    {
        return false;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {3,2,3,2,2,2}, true],
        [new int[] {1,2,3,4}, false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = DivideArray(input);
        Assert.Equal(expected, actual);
    }
}