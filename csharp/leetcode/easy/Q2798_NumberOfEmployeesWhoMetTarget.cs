public class Q2798_NumberOfEmployeesWhoMetTarget
{
    // TC: O(n), n scale with length of hours
    // SC: O(1), space used does not scale with input
    public int NumberOfEmployeesWhoMetTarget(int[] hours, int target)
    {
        var result = 0;
        foreach (var h in hours)
        {
            if (h >= target) result++;
        }
        return result;
    }

    public static TheoryData<int[], int, int> TestData => new()
    {
        {[0,1,2,3,4], 2, 3},
        {[5,1,4,2,2], 6, 0},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int t, int expected)
    {
        var actual = NumberOfEmployeesWhoMetTarget(input, t);
        Assert.Equal(expected, actual);
    }
}
