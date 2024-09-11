class Q1848_MinDistanceToTargetElement
{
    // TC: O(n), where n is length of nums, it has to iterate all elements as there could be multiple elements equals to target
    // SC: O(1), space used does not scale with input
    public int GetMinDistance(int[] nums, int target, int start)
    {
        var min = int.MaxValue;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target)
            {
                var distance = Math.Abs(i - start);
                if (distance < min) min = distance;
            }
        }
        return min;
    }
}
class Q1848_MinDistanceToTargetElementTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,2,3,4,5}, 5, 3, 1],
        [new int[] {1}, 1, 0, 0],
        [new int[] {1,1,1,1,1,1,1,1,1,1}, 1, 0, 0],
    ];
}
public class Q1848_MinDistanceToTargetElementTests
{
    [Theory]
    [ClassData(typeof(Q1848_MinDistanceToTargetElementTestData))]
    public void OfficialTestCases(int[] input, int target, int start, int expected)
    {
        var sut = new Q1848_MinDistanceToTargetElement();
        var actual = sut.GetMinDistance(input, target, start);
        Assert.Equal(expected, actual);
    }
}