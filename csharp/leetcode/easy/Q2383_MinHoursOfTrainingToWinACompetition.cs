public class Q2383_MinHoursOfTrainingToWinACompetition
{
    public int MinNumberOfHours(int initialEnergy, int initialExperience, int[] energy, int[] experience)
    {
        return 0;
    }
    public static TheoryData<int, int, int[], int[], int> TestData => new()
    {
        {5, 3, [1,4,3,2], [2,6,3,1], 8},
        {2, 4, [1], [3], 0},
        {1, 1, [1,1,1,1], [1,1,1,50], 51},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int[] input3, int[] input4, int expected)
    {
        var actual = MinNumberOfHours(input1, input2, input3, input4);
        Assert.Equal(expected, actual);
    }
}