public class Q2326_SpiralMatrixIV
{
    public int[][] SpiralMatrix(int m, int n, ListNode head) {
        return [];   
    }    
    public static TheoryData<int, int, ListNode, int[][]> TestData => new ()
    {
        {
            3, 5, 
            ListNode.FromArray([3,0,2,6,8,1,7,9,4,2,5,5,0])!, 
            [
                [3,0,2,6,8],
                [5,0,-1,-1,1],
                [5,2,4,9,7]
            ]
        },
        {
            1, 4, 
            ListNode.FromArray([0,1,2])!, 
            [[0,1,2,-1]]
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int m, int n, ListNode input, int[][] expected)
    {
        var actual = SpiralMatrix(m, n, input);
        Assert.Equal(expected, actual);
    }
}