public class Q2169_CountOperationsToObtainZero
{
    // TC: O(log(min(num1,num2))) similar to the Euclidean algorithm for computing the GCD.
    // SC: O(1), space used does not scale with input
    public int CountOperations(int num1, int num2)
    {
        var ops = 0;
        while (num1 > 0 && num2 > 0)
        {
            if (num1 >= num2) num1 -= num2;
            else num2 -= num1;
            ops++;
        }
        return ops;
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
