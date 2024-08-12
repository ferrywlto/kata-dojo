
class Q1646_GetMaxInGeneratedArray
{
    public int GetMaximumGenerated(int n)
    {
        return 0;
    }
}
class Q1646_GetMaxInGeneratedArrayTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [7,3],
        [2,1],
        [3,2],
    ];
}
public class Q1646_GetMaxInGeneratedArrayTests
{
    [Theory]
    [ClassData(typeof(Q1646_GetMaxInGeneratedArrayTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q1646_GetMaxInGeneratedArray();
        var actual = sut.GetMaximumGenerated(input);
        Assert.Equal(expected, actual);
    }
}