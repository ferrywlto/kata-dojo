public class Q1442_CountTripletsThatCanFormTwoArraysOfEqualXor(ITestOutputHelper output)
{
    // TC: O(n^3)
    // SC: O(n^2)
    public int CountTriplets(int[] arr)
    {
        var len = arr.Length;
        var forward = new int[len][];

        var forwardXor = arr[0];
        // do triangular prefix xor

        forward[0] = new int[len];
        forward[0][0] = forwardXor;

        for (var i = 1; i < len; i++)
        {
            forward[0][i] = forward[0][i - 1] ^ arr[i];
        }

        for (var i = 1; i < len; i++)
        {
            forward[i] = new int[len];
            for (var j=i; j< len; j++)
            {
                forward[i][j] = forward[i-1][j] ^ arr[i-1];
            }
        }

        var debugLines = forward.Select(row => $"[{string.Join(',', row)}]");
        output.WriteLine($"{string.Join(Environment.NewLine, debugLines)}");

        var result = 0;
        for (var i = 0; i < arr.Length-1; i++)
        {
            for (var j = i + 1; j < arr.Length; j++)
            {
                for (var k = j; k < arr.Length; k++)
                {
                    if (forward[i][j-1] == forward[j][k]) result++;
                }
            }
        }

        return result;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        {[2,3,1,6,7], 4},
        {[1,1,1,1,1], 10},
        {[218,218], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountTriplets(input);
        Assert.Equal(expected, actual);
    }
}
