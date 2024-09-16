class Q1886_DetermineMatrixCanBeObtainedByRotation
{
    public bool FindRotation(int[][] mat, int[][] target)
    {
        return false;
    }
}
class Q1886_DetermineMatrixCanBeObtainedByRotationTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][]
            {
                [0,1],
                [1,0],
            },
            new int[][]
            {
                [1,0],
                [0,1],
            },
            true
        ],
        [
            new int[][]
            {
                [0,1],
                [1,1],
            },
            new int[][]
            {
                [1,0],
                [0,1],
            },
            false
        ],
        [
            new int[][]
            {
                [0,0,0],
                [0,1,0],
                [1,1,1],
            },
            new int[][]
            {
                [1,1,1],
                [0,1,0],
                [0,0,0],
            },
            true
        ]
    ];
}
public class Q1886_DetermineMatrixCanBeObtainedByRotationTests
{
    [Theory]
    [ClassData(typeof(Q1886_DetermineMatrixCanBeObtainedByRotationTestData))]
    public void OfficialTestCases(int[][] input, int[][] target, bool expected)
    {
        var sut = new Q1886_DetermineMatrixCanBeObtainedByRotation();
        var actual = sut.FindRotation(input, target);
        Assert.Equal(expected, actual);
    }
}