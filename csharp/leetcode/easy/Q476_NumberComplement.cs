
namespace dojo.leetcode;

public class Q476_NumberComplement
{
    public int FindComplement(int num)
    {
        return ~num; ;
    }
}

public class Q476_NumberComplementTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [5, 2],
        [1, 0]
    ];
}

public class Q476_NumberComplementTest
{
    [Theory]
    [ClassData(typeof(Q476_NumberComplementTestData))]
    public void Test(int input, int expected)
    {
        var sut = new Q476_NumberComplement();
        var actual = sut.FindComplement(input);
        Assert.Equal(expected, actual);
    }
}