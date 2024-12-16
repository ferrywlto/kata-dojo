public class Q2660_DetermineWinnerOfBowlingGame
{
    public int IsWinner(int[] player1, int[] player2)
    {
        return -1;
    }
    public static TheoryData<int[], int[], int> TestData => new()
    {
        {[5,10,3,2], [6,5,7,3], 1},
        {[3,5,7,6], [8,10,10,2], 2},
        {[2,3], [4,1], 0},
        {[1,1,1,10,10,10,10], [10,10,10,10,1,1,1], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int expected)
    {
        var actual = IsWinner(input1, input2);
        Assert.Equal(expected, actual);
    }
}
