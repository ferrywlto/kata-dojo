class Q1588_SumOfAllOddLengthSubarrays
{
    // TC: O(n*m*k), where n is length of arr n * group size m * number of groups k
    // SC: O(1), space used is fixed 
    public int SumOddLengthSubarrays(int[] arr)
    {
        if (arr.Length == 1) return arr[0];

        var result = arr.Sum();
        if (arr.Length % 2 == 1) result *= 2;

        for (var groupSize = 3; groupSize < arr.Length; groupSize += 2)
        {
            var last = 0;
            for (var j = 0; j < groupSize; j++) last += arr[j];

            result += last;

            for (var i = 1; i < arr.Length - groupSize + 1; i++)
            {
                // sliding window, save the repeat add in between, espcially in large group size 
                var temp = last - arr[i - 1] + arr[i + groupSize - 1];
                result += temp;
                last = temp;
            }
        }
        return result;
    }
}
class Q1588_SumOfAllOddLengthSubarraysTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,4,2,5,3}, 58],
        [new int[] {1,2}, 3],
        [new int[] {10,11,12}, 66],
    ];
}
public class Q1588_SumOfAllOddLengthSubarraysTests
{
    [Theory]
    [ClassData(typeof(Q1588_SumOfAllOddLengthSubarraysTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1588_SumOfAllOddLengthSubarrays();
        var actual = sut.SumOddLengthSubarrays(input);
        Assert.Equal(expected, actual);
    }
}
