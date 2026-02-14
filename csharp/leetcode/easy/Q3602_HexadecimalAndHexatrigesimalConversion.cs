using System.Text;

public class Q3602_HexadecimalAndHexatrigesimalConversion
{
    // TC: O(n)
    // SC: O(n), for the string builders
    const string x = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public string ConcatHex36(int n)
    {
        var sq = n * n;
        var cube = sq * n;
        var sb1 = new StringBuilder();
        while (sq > 0)
        {
            var reminder = sq % 16;
            var ch = x[reminder];

            sb1.Insert(0, ch);
            sq /= 16;
        }
        var sb2 = new StringBuilder();
        while (cube > 0)
        {
            var reminder = cube % 36;
            var ch = x[reminder];

            sb2.Insert(0, ch);
            cube /= 36;
        }
        return sb1.ToString() + sb2.ToString();
    }
    public static TheoryData<int, string> TestData => new()
    {
        {13, "A91P1"},
        {36, "5101000"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, string expected)
    {
        var actual = ConcatHex36(input);
        Assert.Equal(expected, actual);
    }
}
