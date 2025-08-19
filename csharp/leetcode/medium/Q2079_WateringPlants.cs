public class Q2079_WateringPlants
{
    // TC: O(n), n scale with length of plants
    // SC: O(1), space used does not scale with input.
    public int WateringPlants(int[] plants, int capacity)
    {
        var currentWater = capacity;
        var result = 0;

        for (var i = 0; i < plants.Length; i++)
        {
            if (currentWater >= plants[i])
            {
                result++;
                currentWater -= plants[i];
            }
            else
            {
                result += i + i + 1;
                currentWater = capacity - plants[i];
            }
        }
        return result;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[2,2,3,3], 5, 14},
        {[1,1,1,4,2,3], 4, 30},
        {[7,7,7,7,7,7,7], 8, 49},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] plants, int capacity, int expected)
    {
        var result = WateringPlants(plants, capacity);
        Assert.Equal(expected, result);
    }
}
