public class Q2657_FindPrefixCommanArrayOfTwoArrays
{
    // TC: O(n^2), n scale with length of A
    // SC: O(n), n scale with length of A
    public int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
        var len = A.Length;
        var result = new int[len];
        for (var i = 0; i < len; i++)
        {
            var freq = new int[51];
            var commonCount = 0;
            for (var j = 0; j <= i; j++)
            {
                if (A[j] != B[j])
                {
                    if (++freq[A[j]] == 2) commonCount++;
                    if (++freq[B[j]] == 2) commonCount++;
                }
                else commonCount++;
            }

            result[i] = commonCount;
        }
        return result;
    }
    public static TheoryData<int[], int[], int[]> TestData => new()
    {
        {
            [1,3,2,4],
            [3,1,2,4],
            [0,2,3,4]
        },
        {[2,3,1], [3,1,2], [0,1,3]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int[] expected)
    {
        var actual = FindThePrefixCommonArray(input1, input2);
        Assert.Equal(expected, actual);
    }
}