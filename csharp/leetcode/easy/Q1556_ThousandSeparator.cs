using System.Text;

class Q1556_ThousandSeparator
{
    // TC: O(n), where n is number of digits of n
    // SC: O(n+m), where n is the digits of n and m number of separator added to hold the result
    public string ThousandSeparator(int n)
    {
        var sb = new StringBuilder(n.ToString());
        var count = 0;
        for (var i = sb.Length - 1; i > 0; i--)
        {
            count++;
            if (count == 3)
            {
                sb.Insert(i, ".");
                count = 0;
            }
        }
        return sb.ToString();
    }
}
class Q1556_ThousandSeparatorTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [987, "987"],
        [1234, "1.234"],
        [12345, "12.345"],
        [123456, "123.456"],
        [1234567, "1.234.567"],
    ];
}
public class Q1556_ThousandSeparatorTests
{
    [Theory]
    [ClassData(typeof(Q1556_ThousandSeparatorTestData))]
    public void OfficialTestCases(int input, string expected)
    {
        var sut = new Q1556_ThousandSeparator();
        var actual = sut.ThousandSeparator(input);
        Assert.Equal(expected, actual);
    }
}
