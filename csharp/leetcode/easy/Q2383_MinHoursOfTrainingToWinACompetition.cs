public class Q2383_MinHoursOfTrainingToWinACompetition
{
    // TC: O(n), n scale with length of energy
    // SC: O(1), space used does not scale with input
    public int MinNumberOfHours(int initialEnergy, int initialExperience, int[] energy, int[] experience)
    {
        var hoursTraining = 0;

        for (var i = 0; i < energy.Length; i++)
        {
            var targetEng = energy[i] + 1;
            var targetExp = experience[i] + 1;

            if (initialEnergy > energy[i])
            {
                initialEnergy -= energy[i];
            }
            else
            {
                hoursTraining += targetEng - initialEnergy;
                initialEnergy = 1;
            }

            if (initialExperience > experience[i])
            {
                initialExperience += experience[i];
            }
            else
            {
                var expDiff = targetExp - initialExperience;
                initialExperience += experience[i] + expDiff;
                hoursTraining += expDiff;
            }

        }
        return hoursTraining;
    }
    public static TheoryData<int, int, int[], int[], int> TestData => new()
    {
        {5, 3, [1,4,3,2], [2,6,3,1], 8},
        {2, 4, [1], [3], 0},
        {1, 1, [1,1,1,1], [1,1,1,50], 51},
        {
            11, 23,
            [69,22,93,68,57,76,54,72,8,78,88,15,58,61,25,70,58,91,79,22,91,74,90,75,31,53,31,7,51,96,76,17,64,89,83,54,28,33,32,45,20],
            [51,81,46,80,56,7,46,74,64,20,84,66,13,91,49,30,75,43,74,88,82,51,72,4,80,30,10,19,40,27,21,71,24,94,79,13,40,28,63,85,70],
            2323
        },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int[] input3, int[] input4, int expected)
    {
        var actual = MinNumberOfHours(input1, input2, input3, input4);
        Assert.Equal(expected, actual);
    }
}
