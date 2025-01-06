public class Q2843_CountSymmetricIntegers
{
    // TC: O(n), n scale with difference between low and high
    // SC: O(1), space used does not scale with input
    public int CountSymmetricIntegers(int low, int high)
    {
        var result = 0;
        for (var i = low; i <= high; i++)
        {
            if (i >= 10 && i <= 99 && i % 10 != 0)
            {
                var lhs = i / 10;
                var rhs = i % 10;
                if (lhs == rhs) result++;
            }
            else if (i >= 1000 && i <= 9999 && i % 100 != 0)
            {
                var lhs = i / 100;
                var rhs = i % 100;

                var lhsSum = (lhs / 10) + (lhs % 10);
                var rhsSum = (rhs / 10) + (rhs % 10);

                if (lhsSum == rhsSum) result++;
            }
        }
        return result;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {1, 100, 9},
        {1200, 1230, 4},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int expected)
    {
        var actual = CountSymmetricIntegers(input1, input2);
        Assert.Equal(expected, actual);
    }
}