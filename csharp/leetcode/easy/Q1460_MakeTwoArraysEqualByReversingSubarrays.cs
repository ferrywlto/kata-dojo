
class Q1460_MakeTwoArraysEqualByReversingSubarrays
{
    public bool CanBeEqual(int[] target, int[] arr) 
    {
        return false;
    }     
}
class Q1460_MakeTwoArraysEqualByReversingSubarraysTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {1,2,3,4}, new int[] {2,4,1,3}, true],
        [new int[] {7}, new int[] {7}, true],
        [new int[] {3,7,9}, new int[] {3,7,11}, false],
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
