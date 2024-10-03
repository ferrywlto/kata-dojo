public class Q2037_MinNUmMovesToSeatEveryone
{
    public int MinMovesToSeat(int[] seats, int[] students)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {3,1,5}, new int[] {2,7,4}, 4],
        [new int[] {4,1,5,9}, new int[] {1,3,2,6}, 7],
        [new int[] {2,2,6,6}, new int[] {1,3,2,6}, 4],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int expected)
    {
        var actual = MinMovesToSeat(input1, input2);
        Assert.Equal(expected, actual);
    }
}