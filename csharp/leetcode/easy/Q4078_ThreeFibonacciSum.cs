public class Q4078_ThreeFibonacciSum
{
    public bool ThreeFibonacciSum(int n)
    {
        return false;
    }

    public static TheoryData<int, bool> TestData => new()
    {
        {16, false},
        {8, true},
        {2, true},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, bool expected)
    {
        var actual = ThreeFibonacciSum(input);
        Assert.Equal(expected, actual);
    }
}
