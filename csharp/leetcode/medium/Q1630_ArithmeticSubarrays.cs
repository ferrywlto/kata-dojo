public class Q1630_ArithmeticSubarrays
{
    // TC: O(l * n * n log n)
    // SC: O(l) for storing result
    public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
    {
        var result = new bool[l.Length];
        for (var i = 0; i < l.Length; i++)
        {
            result[i] = CheckDiff(nums[l[i]..(r[i] + 1)]);
        }
        return result;
    }
    // TC: O(n * n log n)
    // SC: O(1)
    private bool CheckDiff(int[] input)
    {
        Array.Sort(input);
        var diff = input[1] - input[0];
        for (var i = 2; i < input.Length; i++)
        {
            if (input[i] - input[i - 1] != diff)
            {
                return false;
            }
        }
        return true;
    }
    // if we can get the min and max, then the expected sequence will be:
    // min, min + diff, min + diff * 2 + ... , max
    private bool CheckDiff2(int[] input)
    {
        var len = input.Length;
        int max = int.MinValue, min = int.MaxValue;
        for (var i = 0; i < len; i++)
        {
            max = Math.Max(max, input[i]);
            min = Math.Min(min, input[i]);
        }
        // var expectedSequence = new int[len];
        var diff = (max - min) / (len - 1);
        var seen = new HashSet<int>(input);
        for (var j = 0; j < len; j++)
        {
            // expectedSequence[j] = min + (j*diff);
            if (!seen.Contains(min + (j * diff))) return false;
        }

        // output.WriteLine("input: {0}, seq:{1}, diff:{2}", string.Join(',', input), string.Join(',', expectedSequence), diff);
        return true;
    }
    public static TheoryData<int[], int[], int[], bool[]> TestData => new()
    {
        {[4,6,5,9,3,7], [0,0,2], [2,3,5], [true,false,true]},
        {[-12,-9,-3,-12,-6,15,20,-25,-20,-15,-10], [0,1,6,4,8,7], [4,4,9,7,9,10], [false,true,false,false,true,true]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] n, int[] l, int[] r, bool[] expected)
    {
        var actual = CheckArithmeticSubarrays(n, l, r);
        Assert.Equal(expected, actual);
    }
}