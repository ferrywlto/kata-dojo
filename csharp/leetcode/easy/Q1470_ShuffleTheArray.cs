class Q1470_ShuffleTheArray
{
    // TC: O(n), where n is the length of nums, all elements need to copy to result array
    // SC: O(n), where n is the length of nums to hold the result, as this cannot be done in-place.
    public int[] Shuffle(int[] nums, int n)
    {
        var result = new List<int>();
        for (var i = 0; i < n; i++)
        {
            var x = nums[i];
            var y = nums[i + n];
            result.Add(x);
            result.Add(y);
        }
        return result.ToArray();
    }
}
class Q1470_ShuffleTheArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {2,5,1,3,4,7}, 3, new int[] {2,3,5,4,1,7}],
        [new int[] {1,2,3,4,4,3,2,1}, 4, new int[] {1,4,2,3,3,2,4,1}],
        [new int[] {1,1,2,2}, 2, new int[] {1,2,1,2}],
    ];
}
public class Q1470_ShuffleTheArrayTests
{
    [Theory]
    [ClassData(typeof(Q1470_ShuffleTheArrayTestData))]
    public void OfficialTestCases(int[] input, int n, int[] expected)
    {
        var sut = new Q1470_ShuffleTheArray();
        var actual = sut.Shuffle(input, n);
        Assert.Equal(expected, actual);
    }
}