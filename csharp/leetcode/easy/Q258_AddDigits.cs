namespace dojo.leetcode;

public class Q258_AddDigits
{
    
    public int AddDigits(int num)
    {
        if (num <= 0) return 0;
        if (num < 10) return num;

        var result = num % 9;
        return result == 0 ? 9 : result;
    }
}

public class Q258_AddDigitsTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [38, 2],
        [0, 0],
        [10,1],
        [11,2],
        [12,3],
        [13,4],
        [14,5],
        [15,6],
        [16,7],
        [17,8],
        [18,9],
        [19,1],
        [20,2],
        [21,3],
        [22,4],
        [23,5],
        [24,6],
        [25,7],
        [26,8],
        [27,9],
        [28,1],
        [29,2],
        [30,3],
        [40,4],
        [50,5],
        [60,6],
        [70,7],
        [80,8],
        [90,9],
        [91,1],
        [92,2],
        [93,3],
        [94,4],
        [95,5],
        [96,6],
        [97,7],
        [98,8],
        [99,9],
    ];
}

public class Q258_AddDigitsTest(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q258_AddDigitsTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q258_AddDigits();
        var actual = sut.AddDigits(input);
        Assert.Equal(expected, actual);
    }
}