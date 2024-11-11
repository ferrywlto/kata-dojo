public class Q2395_FindSubarraysWithEqualSum
{
    public bool FindSubarrays(int[] nums)
    {
        return false;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {4,2,4}, true],
        [new int[] {1,2,3,4,5}, false],
        [new int[] {0,0,0}, true],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = FindSubarrays(input);
        Assert.Equal(expected, actual);
    }
}