
class Q1009_ComplementOfBase10Integer
{
    public int BitwiseComplement(int n)
    {
        // 0 is special case which has no significant bit
        if (n == 0) return 1;
        var bitsOfNum = (int)Math.Log(n, 2) + 1;
        var bitMask = (int)Math.Pow(2, bitsOfNum) - 1;
        return n ^ bitMask;
    }
}

class Q1009_ComplementOfBase10IntegerTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [0, 1],
        [5, 2],
        [7, 0],
        [10, 5],
    ];
}

public class Q1009_ComplementOfBase10IntegerTests
{
    [Theory]
    [ClassData(typeof(Q1009_ComplementOfBase10IntegerTestData))]
    public void OfficialTestCase(int input, int expected)
    {
        var sut = new Q1009_ComplementOfBase10Integer();
        var actual = sut.BitwiseComplement(input);
        Assert.Equal(expected, actual);
    }
}
