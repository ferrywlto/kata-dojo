class Q1037_ValidBoomerang
{
    public bool IsBoomerang(int[][] points) {
        return false;   
    }    
}
class Q1037_ValidBoomerangTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[][]{[1,1],[2,3],[3,2]}, true],
        [new int[][]{[1,1],[2,2],[3,3]}, false],
    ];
}
public class Q1037_ValidBoomerangTests
{
    [Theory]
    [ClassData(typeof(Q1037_ValidBoomerangTestData))]
    public void OfficialTestCases(int[][] input, bool expected)
    {
        var sut = new Q1037_ValidBoomerang();
        var actual = sut.IsBoomerang(input);
        Assert.Equal(expected, actual);
    }
}