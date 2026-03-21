public class Q3870_CountCommasInRange
{
    // TC: O(1)
    // SC: O(1)
    public int CountCommas(int n)
    {
        // Since n <= 100000, result = n - 999 
        return n >= 1000 ? n - 999 : 0;
    }

    public static TheoryData<int, int> TestData => new()
    {
        { 1002, 3 }, { 998, 0 }, { 1000, 1 }, { 100000, 99001 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = CountCommas(input);
        Assert.Equal(expected, actual);
    }
}
