namespace dojo.leetcode;

public class Q268_MissingNumber
{
    public int MissingNumber(int[] nums)
    {
        return 0;
    }
}

public class Q268_MissingNumberTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{3,0,1}, 2],    
        [new int[]{0,1}, 2],    
        [new int[]{9,6,4,2,3,5,7,0,1}, 8],
    ];
}

public class Q268_MissingNumberTests(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q268_MissingNumberTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q268_MissingNumber();
        var actual = sut.MissingNumber(input);
        Assert.Equal(expected, actual);
    }
}