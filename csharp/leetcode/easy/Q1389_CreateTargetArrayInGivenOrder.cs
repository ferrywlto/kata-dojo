class Q1389_CreateTargetArrayInGivenOrder
{
    // TC: O(n^2), n is length of nums, ^2 due to list.Insert() is not O(1)
    // SC: O(n), n is length of nums
    public int[] CreateTargetArray(int[] nums, int[] index)
    {
        var list = new List<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            list.Insert(index[i], nums[i]);
        }
        return list.ToArray();
    }
}
class Q1389_CreateTargetArrayInGivenOrderTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {0,1,2,3,4}, new int[] {0,1,2,2,1}, new int[] {0,4,1,3,2}],
        [new int[] {1,2,3,4,0}, new int[] {0,1,2,3,0}, new int[] {0,1,2,3,4}],
        [new int[] {1}, new int[] {0}, new int[] {1}],
    ];
}
public class Q1389_CreateTargetArrayInGivenOrderTests
{
    [Theory]
    [ClassData(typeof(Q1389_CreateTargetArrayInGivenOrderTestData))]
    public void OfficialTestCases(int[] input, int[] index, int[] expected)
    {
        var sut = new Q1389_CreateTargetArrayInGivenOrder();
        var actual = sut.CreateTargetArray(input, index);
        Assert.Equal(expected, actual);
    }
}
