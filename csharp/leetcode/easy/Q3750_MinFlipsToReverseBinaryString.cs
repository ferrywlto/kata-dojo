public class Q3750_MinFlipsToReverseBinaryString
{
    // TC: O(d), d is number of digits in binary representation, worse case d = 32
    // SC: O(d)
    public int MinimumFlips(int n)
    {
        var listForward = new List<int>();
        var listBackward = new List<int>();
        while (n > 0)
        {
            var digit = n & 1;
            listForward.Add(digit);
            listBackward.Insert(0, digit);
            n >>= 1;
        }

        var flips = 0;
        for (var i = 0; i < listForward.Count; i++)
        {
            if (listForward[i] != listBackward[i])
                flips++;
        }
        return flips;
    }
    public static TheoryData<int, int> TestData => new()
    {
        { 7, 0 },
        { 10, 4 },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int expected)
    {
        var result = MinimumFlips(n);
        Assert.Equal(expected, result);
    }
}
