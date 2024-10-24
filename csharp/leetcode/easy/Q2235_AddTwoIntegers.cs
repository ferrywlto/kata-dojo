public class Q2235_AddTwoIntegers
{
    public int Sum(int num1, int num2)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [12,5,17],
        [-10,4],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int expected)
    {
        var actual = Sum(input1, input2);
        Assert.Equal(expected, actual);
    }
}