
namespace dojo.leetcode;

public class Q292_NimGame
{
    public bool CanWinNim(int n) {
        // do something
        // if reminder <= 3, I win, else I cannot win
        // combinations: [1,1], [1,2], [1,3], [2,1], [2,2], [2,3], [3,1], [3,2], [3,3]
        // outcome: 2, 3, 3, 4, 4, 4, 5, 5, 6 
        // count: 1, 2, 3, 2, 1
        //   
        return false;
    }
}

public class Q292_NimGameTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [4, false],
        [1, true],
        [2, true],
    ];
}

public class Q292_NimGameTests(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q292_NimGameTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q292_NimGame();
        var actual = sut.CanWinNim(input);
        Assert.Equal(expected, actual);
    }
}