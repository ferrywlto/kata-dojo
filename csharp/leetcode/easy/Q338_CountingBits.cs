
namespace dojo.leetcode;

public class Q338_CountingBits
{
    public int[] CountBits(int n)
    {
        return [];
    }
}

public class Q338_CountingBitsTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [2, new int[] {0,1,1}],
        [5, new int[] {0,1,1,2,1,2}],
    ];
}

public class Q338_CountingBitsTests: BaseTest
{
    [Theory]
    [ClassData(typeof(Q338_CountingBitsTestData))]
    public void OfficialTestCases(int input, int[] expected)
    {
        var sut = new Q338_CountingBits();
        var actual = sut.CountBits(input);
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}