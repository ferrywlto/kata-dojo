
class Q922_SortArrayByParityII
{
    public int[] SortArrayByParityII(int[] nums)
    {
        return [];
    }
}

class Q922_SortArrayByParityIITestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{4,2,5,7}, new int[]{4,5,2,7}],
        [new int[]{2,3}, new int[]{2,3}],
    ];
}

public class Q922_SortArrayByParityIITests
{
    [Theory]
    [ClassData(typeof(Q922_SortArrayByParityIITestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q922_SortArrayByParityII();
        var actual = sut.SortArrayByParityII(input);
        Assert.Equal(expected, actual);
    }
}