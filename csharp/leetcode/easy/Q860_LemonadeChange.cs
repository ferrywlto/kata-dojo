
namespace dojo.leetcode;

public class Q860_LemonadeChange
{
    public bool LemonadeChange(int[] bills) 
    {
        return false;    
    }
}

public class Q860_LemonadeChangeTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {5,5,5,10,20}, true],
        [new int[] {5,5,10,10,20}, false],
    ];
}

public class Q860_LemonadeChangeTests
{
    [Theory]
    [ClassData(typeof(Q860_LemonadeChangeTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q860_LemonadeChange();
        var actual = sut.LemonadeChange(input);
        Assert.Equal(expected, actual);
    }
}