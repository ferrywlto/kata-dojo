using System.Data;

public class Q70_ClimbingStairsTests {
    [Theory]
    [InlineData(2,2)]
    [InlineData(3,3)]
    [InlineData(4,5)]
    [InlineData(5,8)]
    [InlineData(45,1836311903)]
    public void OfficialTestCases(int input, int expected) {
        var sut = new Q70_ClimbingStairs();
        Assert.Equal(expected, sut.ClimbStairs(input));
    }
}

public class Q70_ClimbingStairs {
    
    Dictionary<int, int> dict = new() {{1,1}, {2,2}, {3,3} };
    // Speed:26ms (19.89%), Memory: 27.1MB (12.73%)
    public int ClimbStairs(int n) {

        if (dict.TryGetValue(n, out int value)) {
            return value;
        }
        var sum = ClimbStairs(n-1) + ClimbStairs(n-2);
        dict.Add(n, sum);
        return sum;
    }
}