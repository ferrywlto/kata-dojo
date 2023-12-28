public class Q70_ClimbingStairsTests {
    [Theory]
    [InlineData(2,2)]
    [InlineData(3,3)]
    public void OfficialTestCases(int input, int expected) {
        var sut = new Q70_ClimbingStairs();
        Assert.Equal(expected, sut.ClimbStairs(input));
    }
}

public class Q70_ClimbingStairs {
    public int ClimbStairs(int n) {
        return 0;
    }
}