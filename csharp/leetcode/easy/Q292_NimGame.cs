public class Q292_NimGame
{
    public bool CanWinNim(int n) {
        // if reminder <= 3, I win, else I cannot win
        // combinations: [1,1], [1,2], [1,3], [2,1], [2,2], [2,3], [3,1], [3,2], [3,3]
        // outcome: 2, 3, 3, 4, 4, 4, 5, 5, 6 
        // count: 1, 2, 3, 2, 1
        // if minus the combination the reminder is 5, it is sure I will win 
        // therefore it becomes a recursion of minus 2,3,4,5,6 from input, 5^n times  

        // actually the above is not important because it is an exhaustive search
        // only one case friend will definitely win, n % 4 == 0
        return n % 4 != 0;
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

public class Q292_NimGameTests
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