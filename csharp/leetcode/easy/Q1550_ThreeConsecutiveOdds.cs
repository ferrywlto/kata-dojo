class Q1550_ThreeConsecutiveOdds
{
    // TC: O(n), where n is the length of arr, as it have to iterate all items once
    // SC: O(1), space used is fixed
    public bool ThreeConsecutiveOdds(int[] arr)
    {
        var count = 0;
        for (var i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 0) count = 0;
            else
            {
                count++;
                if (count == 3) return true;
            }
        }
        return false;
    }
}
class Q1550_ThreeConsecutiveOddsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {2,6,4,1}, false],
        [new int[] {1,2,34,3,4,5,7,23,12}, true],
    ];
}
public class Q1550_ThreeConsecutiveOddsTests
{
    [Theory]
    [ClassData(typeof(Q1550_ThreeConsecutiveOddsTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q1550_ThreeConsecutiveOdds();
        var actual = sut.ThreeConsecutiveOdds(input);
        Assert.Equal(expected, actual);
    }
}
