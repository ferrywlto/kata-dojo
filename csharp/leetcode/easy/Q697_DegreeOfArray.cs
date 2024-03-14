
namespace dojo.leetcode;

public class Q697_DegreeOfArray
{
    public int FindShortestSubArray(int[] nums)
    {
        return 0;
    }
}

public class Q697_DegreeOfArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1, 2, 2, 3, 1}, 2],
        [new int[]{1, 2, 2, 3, 1, 4, 2}, 6],
        [new int[]{1, 5, 2, 3, 5, 4, 5, 6}, 6],
    ];
}

public class Q697_DegreeOfArrayTests 
{
    [Theory]
    [ClassData(typeof(Q697_DegreeOfArrayTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q697_DegreeOfArray();
        var actual = sut.FindShortestSubArray(input);
        Assert.Equal(expected, actual);
    }
}