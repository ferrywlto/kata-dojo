
class Q1431_KidsWithGreatestNumberOfCandies
{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) 
    {
        return [];    
    }
}
class Q1431_KidsWithGreatestNumberOfCandiesTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {2,3,5,1,3}, 3, new bool[] {true,true,true,false,true}],
        [new int[] {4,2,1,1,2}, 1, new bool[] {true,false,false,false,false}],
        [new int[] {12,1,12}, 3, new bool[] {true,false,true}],
    ];
}
public class Q1431_KidsWithGreatestNumberOfCandiesTests
{
    [Theory]
    [ClassData(typeof(Q1431_KidsWithGreatestNumberOfCandiesTestData))]
    public void OfficialTestCases(int[] input, int k, bool[] expected)
    {
        var sut = new Q1431_KidsWithGreatestNumberOfCandies();
        var actual = sut.KidsWithCandies(input, k);
        Assert.Equal(expected, actual);
    }
}
