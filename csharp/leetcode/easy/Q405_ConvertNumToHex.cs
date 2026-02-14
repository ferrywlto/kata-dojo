class Q405_ConvertNumToHex
{
    const string hex = "0123456789abcdef";
    // TC: O(1), SC: O(1)
    public string ToHex(int num)
    {
        if (num == 0) return "0";
        int x = num;
        var result = new Stack<char>();
        while ((x & 0xffffffff) != 0)
        {
            var temp = hex[x & 0xf];
            result.Push(temp);
            x = x >>> 4;
        }

        return string.Join(string.Empty, result);
    }
}

class Q405_ConvertNumToHexTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [26, "1a"],
        [-1, "ffffffff"],
        [0, "0"],
    ];
}

public class Q405_ConvertNumToHexTests
{
    [Theory]
    [ClassData(typeof(Q405_ConvertNumToHexTestData))]
    public void OfficialTestCases(int input, string expected)
    {
        var sut = new Q405_ConvertNumToHex();
        var actual = sut.ToHex(input);
        Assert.Equal(expected, actual);
    }
}
