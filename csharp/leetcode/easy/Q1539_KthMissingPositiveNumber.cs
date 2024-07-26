class Q1539_KthMissingPositiveNumber
{
    // TC: O(n), where n is length of arr + k
    // SC: O(m), where m is length of arr
    public int FindKthPositive(int[] arr, int k)
    {
        var totalNum = arr.Length + k;
        // expect 1..totalNum
        var missingFound = 0;
        var set = arr.ToHashSet();

        for(var i=1; i<=totalNum; i++)
        {
            if (!set.Contains(i)) missingFound++;
            if (missingFound == k) return i;
        }
        return 0;
    }
}
class Q1539_KthMissingPositiveNumberTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {2,3,4,7,11}, 5, 9],
        [new int[] {1,2,3,4}, 2, 6],
    ];
}
public class Q1539_KthMissingPositiveNumberTests
{
    [Theory]
    [ClassData(typeof(Q1539_KthMissingPositiveNumberTestData))]
    public void OfficialTestCases(int[] input, int k, int expected)
    {
        var sut = new Q1539_KthMissingPositiveNumber();
        var actual = sut.FindKthPositive(input, k);
        Assert.Equal(expected, actual);
    }
}