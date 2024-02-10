namespace dojo.leetcode;

public class Q448_NumbersDisappearedInArray
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        var result = new List<int>();
        
        return result;
    }
}

public class Q448_NumbersDisappearedInArrayTestData: TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {4, 3, 2, 7, 8, 2, 3, 1}, new int[] {5, 6}],
        [new int[] {1, 1}, new int[] {2}],
    ];
}

public class Q448_NumbersDisappearedInArrayTest
{
    [Theory]
    [ClassData(typeof(Q448_NumbersDisappearedInArrayTestData))]
    public void OfficerTestCase(int[] input, int[] expected)
    {
        var sut = new Q448_NumbersDisappearedInArray();
        var actual = sut.FindDisappearedNumbers(input);
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}
