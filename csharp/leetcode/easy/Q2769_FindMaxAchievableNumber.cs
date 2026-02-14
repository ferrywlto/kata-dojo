public class Q2769_FindMaxAchievableNumber
{
    // TC: O(1), obviously
    // SC: O(1), same as time
    public int TheMaximumAchievableX(int num, int t)
    {
        return num + 2 * t;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {4, 1, 6},
        {3, 2, 7}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int expected)
    {
        var actual = TheMaximumAchievableX(input1, input2);
        Assert.Equal(expected, actual);
    }
}
