class Q1103_DistributeCandiesToPeople
{

    // TC: O(n), n is num_people
    // SC: O(n), n is num_people to store the result 
    public int[] DistributeCandies(int candies, int num_people)
    {
        if (num_people == 1) return [candies];
        var result = new int[num_people];
        var give = 1;
        while (candies > 0)
        {
            for (var i = 0; i < result.Length; i++)
            {
                if (give <= candies)
                {
                    result[i] += give;
                    candies -= give;
                    give++;
                }
                else
                {
                    result[i] += candies;
                    candies = 0;
                }
            }
        }
        return result;
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
