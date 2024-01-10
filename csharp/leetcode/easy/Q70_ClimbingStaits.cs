namespace dojo.leetcode;

public class Q70_ClimbingStairsTests
{
    [Theory]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 5)]
    [InlineData(5, 8)]
    [InlineData(45, 1836311903)]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q70_ClimbingStairs();
        Assert.Equal(expected, sut.ClimbStairs(input));
    }
}
// From other developers this question is about the fibonacci sequence that "each number is the sum of the two preceding ones, starting from 0 and 1"
public class Q70_ClimbingStairs
{

    // Using memorization technique can make TC from O(2^n) down to O(n)
    Dictionary<int, int> dict = new() { { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 5 }, { 5, 8 } };
    // TC: O(n), SC: O(n)
    public int ClimbStairs(int n)
    {
        if (dict.TryGetValue(n, out int value))
        {
            return value;
        }
        var sum = ClimbStairs(n - 1) + ClimbStairs(n - 2);
        dict.Add(n, sum);
        return sum;
    }
}