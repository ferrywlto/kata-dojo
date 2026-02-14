public class Q3200_MaxHeightOfTriangle
{
    // TC: O(n), n scale with larger of red and blue
    // SC: O(1), space used does not scale with input
    public int MaxHeightOfTriangle(int red, int blue)
    {
        return Math.Max(Cal(red, blue), Cal(blue, red));
    }
    private int Cal(int r, int b)
    {
        var step = 1;
        while (true)
        {
            if (step % 2 == 1)
            {
                if (step <= r)
                {
                    r -= step;
                    step++;
                }
                else
                {
                    return step - 1;
                }
            }
            else
            {
                if (step <= b)
                {
                    b -= step;
                    step++;
                }
                else
                {
                    return step - 1;
                }
            }
        }
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {2, 4, 3},
        {2, 1, 2},
        {1, 1, 1},
        {10, 1, 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int expected)
    {
        var actual = MaxHeightOfTriangle(input1, input2);
        Assert.Equal(expected, actual);
    }
}
