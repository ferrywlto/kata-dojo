public class Q1441_BuildArrayWithStackOperations
{
    public IList<string> BuildArray(int[] target, int n)
    {
        return [];
    }
    public static TheoryData<int[], int, string[]> TestData => new()
    {
        {[1,3], 3, ["Push","Push","Pop","Push"]},
        {[1,2,3], 3, ["Push","Push","Push"]},
        {[1,2], 4, ["Push","Push"]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int n, string[] expected)
    {
        var actual = BuildArray(input, n);
        Assert.Equal(expected, actual);
    }
}
