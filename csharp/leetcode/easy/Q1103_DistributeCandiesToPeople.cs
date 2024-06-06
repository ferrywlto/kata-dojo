
class Q1103_DistributeCandiesToPeople
{
    public int[] DistributeCandies(int candies, int num_people) {
        return [];
    }    
}
class Q1103_DistributeCandiesToPeopleTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [7,4,new int[]{1,2,3,1}],
        [10,3,new int[]{5,2,3}],
    ];
}
public class Q1103_DistributeCandiesToPeopleTests
{
    [Theory]
    [ClassData(typeof(Q1103_DistributeCandiesToPeopleTestData))]
    public void OfficialTestCases(int candies, int people, int[] expected)
    {
        var sut = new Q1103_DistributeCandiesToPeople();
        var actual = sut.DistributeCandies(candies, people);
        Assert.Equal(expected, actual);
    }
}