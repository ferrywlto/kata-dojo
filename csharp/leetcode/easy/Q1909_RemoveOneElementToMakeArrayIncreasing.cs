class Q1909_RemoveOneElementToMakeArrayIncreasing
{
    public bool CanBeIncreasing(int[] nums)
    {
        return false;
    }
}
class Q1909_RemoveOneElementToMakeArrayIncreasingTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,2,10,5,7}, true],
        [new int[] {2,3,1,2}, false],
        [new int[] {1,1,1}, false],
    ];
}
public class Q1909_RemoveOneElementToMakeArrayIncreasingTests
{
    [Theory]
    [ClassData(typeof(Q1909_RemoveOneElementToMakeArrayIncreasingTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q1909_RemoveOneElementToMakeArrayIncreasing();
        var actual = sut.CanBeIncreasing(input);
        Assert.Equal(expected, actual);
    }
}