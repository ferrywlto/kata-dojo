public class Q2169_CountOperationsToObtainZero
{
    public int CountOperations(int num1, int num2)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [2,3,3],
        [10,10,1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int expected)
    {
        var actual = CountOperations(input1, input2);
        Assert.Equal(expected, actual);
    }
}