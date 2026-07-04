public class Q3978_UniqueMiddleElement
{
    public bool IsMiddleElementUnique(int[] nums)
    {
        return false;
    }

    public static TheoryData<int[], bool> TestData => new()
    {
        { [1, 2, 3], true },
        { [1, 2, 2], false },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = IsMiddleElementUnique(input);
        Assert.Equal(expected, actual);
    }
}
