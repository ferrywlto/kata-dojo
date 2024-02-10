namespace dojo.leetcode;

public class Q448_NumbersDisappearedInArray
{
    // TC: O(n), SC: O(n)
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        var disappeared = Enumerable.Range(1, nums.Length).ToHashSet();
        for(var i=0; i<nums.Length; i++)
        {
            disappeared.Remove(nums[i]);
        }         
        return disappeared.ToList();
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
