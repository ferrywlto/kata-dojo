
class Q1460_MakeTwoArraysEqualByReversingSubarrays
{
    // TC: O(n log n), where n log n from Array.Sort() dominates n from SequenceEqual()
    // SC: O(1), no space used in operation 
    public bool CanBeEqual(int[] target, int[] arr)
    {
        // if we break down the question to keep reversing 2 elements only, this is literally a sort 
        Array.Sort(target);
        Array.Sort(arr);
        return target.SequenceEqual(arr);
    }
}
class Q1460_MakeTwoArraysEqualByReversingSubarraysTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,2,3,4}, new int[] {2,4,1,3}, true],
        [new int[] {7}, new int[] {7}, true],
        [new int[] {3,7,9}, new int[] {3,7,11}, false],
        [new int[] {392,360}, new int[] {392,360}, true],
    ];
}
public class Q1460_MakeTwoArraysEqualByReversingSubarraysTests
{
    [Theory]
    [ClassData(typeof(Q1460_MakeTwoArraysEqualByReversingSubarraysTestData))]
    public void OfficialTestCases(int[] target, int[] input, bool expected)
    {
        var sut = new Q1460_MakeTwoArraysEqualByReversingSubarrays();
        var actual = sut.CanBeEqual(target, input);
        Assert.Equal(expected, actual);
    }
}
