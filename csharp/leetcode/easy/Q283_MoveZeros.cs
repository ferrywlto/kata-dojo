
namespace dojo.leetcode;

public class Q283_MoveZeros
{
    public void MoveZeroes(int[] nums)
    {

    }
}

public class Q283_MoveZerosTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{0,1,0,3,12}, new int[]{1,3,12,0,0}],
        [new int[]{0}, new int[]{0}],
    ];
}

public class Q283_MoveZerosTests(ITestOutputHelper output): TestBase(output)
{
    [Theory]
    [ClassData(typeof(Q283_MoveZerosTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q283_MoveZeros();
        sut.MoveZeroes(input);
        Assert.True(Enumerable.SequenceEqual(expected, input));
    }
}