public class Q2164_SortEvenAndOddIndicesIndependently
{
    public int[] SortEvenOdd(int[] nums)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [new int[] {4,1,2,3}, new int[] {2,3,4,1}],
        [new int[] {2,1}, new int[] {2,1}],
        [new int[] {1}, new int[] {1}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = SortEvenOdd(input);
        Assert.Equal(expected, actual);
    }
}