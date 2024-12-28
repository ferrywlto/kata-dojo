public class Q2729_CheckIfNumberFascinating
{
    // TC: O(n), n scale with number of digits in n
    // SC: O(1), space used does not scale with input
    public bool IsFascinating(int n)
    {
        var count = new int[10];
        var n2 = n * 2;
        var n3 = n * 3;
        var numStr = $"{n}{n2}{n3}";
        var sum = 0;
        for (var i = 0; i < numStr.Length; i++)
        {
            var digit = numStr[i] - '0';
            if (digit == 0 || count[digit] > 0) return false;
            else
            {
                count[digit]++;
                sum++;
            }
        }
        return sum == 9;
    }
    public static TheoryData<int, bool> TestData => new()
    {
        {192, true},
        {100, false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, bool expected)
    {
        var actual = IsFascinating(input);
        Assert.Equal(expected, actual);
    }
}