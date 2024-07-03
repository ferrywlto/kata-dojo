class Q1365_HowManyNumbersAreSmallerThanTheCurrentNumber
{
    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        return [];
    }
}
class Q1365_HowManyNumbersAreSmallerThanTheCurrentNumberTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {8,1,2,2,3}, new int[]{4,0,1,1,3}],
        [new int[] {6,5,4,8}, new int[]{2,1,0,3}],
        [new int[] {7,7,7,7}, new int[]{0,0,0,0}],
    ];
}
public class Q1365_HowManyNumbersAreSmallerThanTheCurrentNumberTests
{
    [Theory]
    [ClassData(typeof(Q1365_HowManyNumbersAreSmallerThanTheCurrentNumberTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q1365_HowManyNumbersAreSmallerThanTheCurrentNumber();
        var actual = sut.SmallerNumbersThanCurrent(input);
        Assert.Equal(expected, actual);
    }
}