using System.Text;

class Q1323_Maximum69Number
{
    public int Maximum69Number(int num)
    {
        var numStrSb = new StringBuilder(num.ToString());
        for (var i = 0; i < numStrSb.Length; i++)
        {
            if (numStrSb[i] == '6')
            {
                numStrSb[i] = '9';
                return int.Parse(numStrSb.ToString());
            }
        }
        return num;
    }
}
class Q1323_Maximum69NumberTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [9669, 9969],
        [9996, 9999],
        [9999, 9999],
    ];
}
public class Q1323_Maximum69NumberTests
{
    [Theory]
    [ClassData(typeof(Q1323_Maximum69NumberTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q1323_Maximum69Number();
        var actual = sut.Maximum69Number(input);
        Assert.Equal(expected, actual);
    }
}