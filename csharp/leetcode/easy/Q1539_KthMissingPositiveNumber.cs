class Q1539_KthMissingPositiveNumber
{
    public int FindKthPositive(int[] arr, int k)
    {
        return 0;
    }
}
class Q1539_KthMissingPositiveNumberTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {2,3,4,7,11}, 5, 9],
        [new int[] {1,2,3,4}, 2, 6],
    ];
}
public class Q1539_KthMissingPositiveNumberTests
{
    [Theory]
    [ClassData(typeof(Q1539_KthMissingPositiveNumberTestData))]
    public void OfficialTestCases(int[] input, int k, int expected)
    {
        var sut = new Q1539_KthMissingPositiveNumber();
        var actual = sut.FindKthPositive(input, k);
        Assert.Equal(expected, actual);
    }
}