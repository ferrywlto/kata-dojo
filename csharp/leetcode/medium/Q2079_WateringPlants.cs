public class Q2079_WateringPlants
{
    public int WateringPlants(int[] plants, int capacity)
    {

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
