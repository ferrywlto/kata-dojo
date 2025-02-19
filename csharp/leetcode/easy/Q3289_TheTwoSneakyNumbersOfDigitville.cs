public class Q3289_TheTwoSneakyNumbersOfDigitville
{
    public int[] GetSneakyNumbers(int[] nums)
    {
        return [];
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[0,1,1,0], [0,1]},
        {[0,3,2,1,3,2], [2,3]},
        {[7,1,5,4,3,4,6,0,9,5,8,2], [4,5]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = GetSneakyNumbers(input);
        Assert.Equal(expected, actual);
    }
}