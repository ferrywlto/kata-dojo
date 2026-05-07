public class Q3912_ValidElementsInArray
{
    public IList<int> FindValidElements(int[] nums)
    {
        return [];
    }

    public static TheoryData<int[], List<int>> TestData => new()
    {
        { [1, 2, 4, 2, 3, 2], [1, 2, 4, 3, 2] },
        { [5, 5, 5, 5], [5, 5, 5, 5] },
        { [1], [1] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, List<int> expected)
    {
        var actual = FindValidElements(input);
        Assert.Equal(expected, actual);
    }
}
