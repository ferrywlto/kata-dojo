public class Q3827_CountMonobitIntegers
{
    // The constraints are small, n < 1000
    // The answer maximum is 9 because 2^10 = 1024
    // Monobits means all 0 or all 1 in bits
    private readonly int[] _mul = [1, 3, 7, 15, 31, 63, 127, 255, 511, 1023];
    public int CountMonobit(int n)
    {
        for (var i = 0; i < _mul.Length; i++)
        {
            if (_mul[i] > n) return i + 1;
        }
        return 1;
    }

    public static TheoryData<int, int> TestData => new()
    {
        {0, 1},
        {1, 2},
        {4, 3},
        {7, 4},
        {15, 5},
        {31, 6},
        {511, 10}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = CountMonobit(input);
        Assert.Equal(expected, actual);
    }
}
