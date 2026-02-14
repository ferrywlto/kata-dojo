class Q1346_CheckIfNAndItsDoubleExist
{
    // TC: O(n), n scale with length of arr
    // SC: O(n), n scale with distinct numbers in arr
    public bool CheckIfExist(int[] arr)
    {
        var hashset = new HashSet<int>();
        foreach (var num in arr)
        {
            if (hashset.Contains(num * 2) || (num % 2 == 0 && hashset.Contains(num / 2))) return true;
            hashset.Add(num);
        }
        return false;
    }
}
class Q1346_CheckIfNAndItsDoubleExistTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {10,2,5,3}, true],
        [new int[] {3,1,7,11}, false],
        [new int[] {7,1,14,11}, true],
    ];
}
public class Q1346_CheckIfNAndItsDoubleExistTests
{
    [Theory]
    [ClassData(typeof(Q1346_CheckIfNAndItsDoubleExistTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q1346_CheckIfNAndItsDoubleExist();
        var actual = sut.CheckIfExist(input);
        Assert.Equal(expected, actual);
    }
}
