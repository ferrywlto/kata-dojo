public class Q3784_MinDeletionCostToMakeAllCharactersEqual
{
    public long MinCost(string s, int[] cost)
    {
        
        return 0;
    }
    public static TheoryData<string, int[], int> TestData => new()
    {
        {"aabaac", [1,2,3,4,1,10], 11},
        {"abc", [10,5,8], 13},
        {"zzzzz", [67,67,67,67,67], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int[] cost, int expected)
    {
        var actual = MinCost(input, cost);
        Assert.Equal(expected, actual);
    }
}
