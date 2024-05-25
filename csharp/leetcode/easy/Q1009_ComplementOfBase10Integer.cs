
class Q1009_ComplementOfBase10Integer
{
    public int BitwiseComplement(int n) {
        return 0;        
    }    
}

class Q1009_ComplementOfBase10IntegerTestData : TestData
{
    protected override List<object[]> Data =>
    [
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