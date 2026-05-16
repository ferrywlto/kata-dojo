public class Q3890_IntegersWithMultipleSumOfTwoCubes
{
    public IList<int> FindGoodIntegers(int n)
    {
        return [];
    }

    public static TheoryData<int, List<int>> TestData => new()
    {
        { 4104, [1729, 4104] },
        { 578, [] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, List<int> expected)
    {
        var actual = FindGoodIntegers(input);
        Assert.Equal(expected, actual);
    }
}
