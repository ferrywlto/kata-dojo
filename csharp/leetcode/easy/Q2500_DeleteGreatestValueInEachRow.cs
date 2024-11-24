public class Q2500_DeleteGreatestValueInEachRow
{
    public int DeleteGreatestValue(int[][] grid)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][]
            {
                [1,2,4],[3,3,1]
            }, 8
        ],
        [
            new int[][]
            {
                [10]
            }, 10
        ]
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = DeleteGreatestValue(input);
        Assert.Equal(expected, actual);
    }
}