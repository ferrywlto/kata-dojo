public class Q3477_FruitsIntoBasketsII
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        return 0;
    }
    public static TheoryData<int[], int[], int> TestData => new()
    {
        {[4,2,5], [3,5,4], 1},
        {[3,6,1], [6,4,7], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int expected)
    {
        var actual = NumOfUnplacedFruits(input1, input2);
        Assert.Equal(expected, actual);
    }
}