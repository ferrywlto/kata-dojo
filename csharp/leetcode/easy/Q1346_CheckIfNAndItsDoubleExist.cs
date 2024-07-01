class Q1346_CheckIfNAndItsDoubleExist
{
    public bool CheckIfExist(int[] arr)
    {
        return false;
    }
}
class Q1346_CheckIfNAndItsDoubleExistTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {10,2,5,3}, true],
        [new int[] {3,1,7,11}, true],
    ];
}
public class Q1346_CheckIfNAndItsDoubleExistTests
{
    [Theory]
    [ClassData(typeof(Q1346_CheckIfNAndItsDoubleExistTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q1346_CheckIfNAndItsDoubleExist();
        var actual = sut.CheckIfExist(input);
        Assert.Equal(expected, actual);
    }
}
