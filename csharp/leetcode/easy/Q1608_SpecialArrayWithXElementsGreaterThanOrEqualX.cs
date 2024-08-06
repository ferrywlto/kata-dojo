
class Q1608_SpecialArrayWithXElementsGreaterThanOrEqualX
{
    public int SpecialArray(int[] nums)
    {
        return 0;
    }
}
class Q1608_SpecialArrayWithXElementsGreaterThanOrEqualXTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {3,5}, 2],
        [new int[] {0,0}, -1],
        [new int[] {0,4,3,0,4}, 3],
    ];
}
public class Q1608_SpecialArrayWithXElementsGreaterThanOrEqualXTests
{
    [Theory]
    [ClassData(typeof(Q1608_SpecialArrayWithXElementsGreaterThanOrEqualXTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1608_SpecialArrayWithXElementsGreaterThanOrEqualX();
        var actual = sut.SpecialArray(input);
        Assert.Equal(expected, actual);
    }
}