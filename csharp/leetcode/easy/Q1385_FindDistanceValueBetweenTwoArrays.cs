class Q1385_FindDistanceValueBetweenTwoArrays
{
    // TC: O(n log n), n log n for Array.Sort + for each n items in arr1 perform once log n binary search thus n * log n again
    // SC: O(1), operations are done in-place.
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
    {
        Array.Sort(arr2);
        var count = 0;
        foreach (var num in arr1)
        {
            if (AllDiffLargerThanTarget(arr2, num, d)) count++;
        }
        return count;
    }
    public bool AllDiffLargerThanTarget(int[] arr, int input, int target)
    {
        var start = 0;
        var end = arr.Length - 1;
        while (start <= end)
        {
            var mid = start + ((end - start) / 2);
            if (Math.Abs(input - arr[mid]) <= target) return false;
            if (arr[mid] > input) end = mid - 1;
            else start = mid + 1;
        }
        return true;
    }
}
class Q1385_FindDistanceValueBetweenTwoArraysTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {4,5,8}, new int[] {10,9,1,8}, 2, 2],
        [new int[] {1,4,2,3}, new int[] {-4,-3,6,10,20,30}, 3, 2],
        [new int[] {2,1,100,3}, new int[] {-5,-2,10,-3,7}, 6, 1],
    ];
}
public class Q1385_FindDistanceValueBetweenTwoArraysTests
{
    [Theory]
    [ClassData(typeof(Q1385_FindDistanceValueBetweenTwoArraysTestData))]
    public void OfficialTestCases(int[] input1, int[] input2, int d, int expected)
    {
        var sut = new Q1385_FindDistanceValueBetweenTwoArrays();
        var actual = sut.FindTheDistanceValue(input1, input2, d);
        Assert.Equal(expected, actual);
    }
}
