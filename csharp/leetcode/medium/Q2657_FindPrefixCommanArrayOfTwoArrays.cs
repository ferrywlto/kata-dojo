public class Q2657_FindPrefixCommanArrayOfTwoArrays
{
    public int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
        var setA = new HashSet<int>();
        var setB = new HashSet<int>();
        var result = new int[A.Length];
        for (var i = 0; i < A.Length; i++)
        {
            setA.Add(A[i]);
            setB.Add(B[i]);
            var commonCount = 0;
            foreach (var n in setB)
            {
                if (setA.Contains(n))
                {
                    commonCount++;
                }
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