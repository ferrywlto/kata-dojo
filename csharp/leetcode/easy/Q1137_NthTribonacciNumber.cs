
class Q1137_NthTribonaacciNumber
{
    // TC: O(n), n is how large input number is
    // SC: O(n), the larger the input number, the more steps to cache to prevent recalculation
    private Dictionary<int, int> dict = new() {
        {0,0},
        {1,1},
        {2,1},
    };

    public int Tribonacci(int n)
    {
        if (dict.TryGetValue(n, out var value))
            return value;
        else
        {
            var result = Tribonacci(n - 3) + Tribonacci(n - 2) + Tribonacci(n - 1);
            dict.Add(n, result);
            return result;
        }
    }
}
class Q1137_NthTribonaacciNumberTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [4,4],
        [25,1389537],
    ];
}
public class Q1137_NthTribonaacciNumberTests
{
    [Theory]
    [ClassData(typeof(Q1137_NthTribonaacciNumberTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q1137_NthTribonaacciNumber();
        var actual = sut.Tribonacci(input);
        Assert.Equal(expected, actual);
    }
}
