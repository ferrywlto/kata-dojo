class Q1399_CountLargestGroup
{
    public int CountLargestGroup(int n)
    {
        return 0;
    }
}
class Q1399_CountLargestGroupTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [13, 4],
        [2, 2],
    ];
}
public class Q1399_CountLargestGroupTests
{
    [Theory]
    [ClassData(typeof(Q1399_CountLargestGroupTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q1399_CountLargestGroup();
        var actual = sut.CountLargestGroup(input);
        Assert.Equal(expected, actual);
    }
}