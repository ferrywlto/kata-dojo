using System.Text;

public class Q3877_MinRemovalsToAchiveTargetXor(ITestOutputHelper output)
{
    public int MinRemovals(int[] nums, int target)
    {
        // solution
        // rotation sequence
        // since XOR is associative, the order of XOR does not matters
        // only need to do XOR nums.Length times
        // 1. 1,2,3,4
        // 2. 2,3,4,1
        // 3. 3,4,1,2
        // 4. 4,1,2,3
        var len = nums.Length;

        if (len == 1) return 0;

        var max = nums[0];
        for (var i = 1; i < len; i++)
        {
            max ^= nums[i];
        }

        if (max == target) return 0;

        // initialize matrix
        var matrix = new int[nums.Length];
        for(var i = 0; i < matrix.Length; i++)
        {
            matrix[i] = max;
        }
        // [6, 12, 5, 14]
        // 0110
        // 1100
        // 0101
        // 1110
        output.WriteLine($"max = {max}");

        for (var i = 0; i < len; i++)
        {
            for (var j = 0; j < matrix.Length; j++)
            {
                var numIdx = (i+j) % len;
                matrix[j] ^= nums[numIdx];
                output.WriteLine($"matrix[{j}] ^= nums[{numIdx}] = {matrix[j]}");
                if (matrix[j] == target) return i + 1;
            }

            // var temp = max;
            // sb.Clear();
            // for (var j = i; j < i+len; j++)
            // {
                // sb.Append(j%len);
                // temp ^= nums[j%len];

                // var removed = (j - i + 1);
                // output.WriteLine($"removed: {removed}");
                // if (temp == target) return removed;
                // {
                //     return result;
                // }

                // set.Add(newVal);
                // 1 2 3 4
                // 2 1 3 4
                //   2 3 4
            // }
            // Console.WriteLine(sb.ToString());
        }
        return -1;
    }

    public static TheoryData<int[], int, int> TestData => new()
    {
        { [1, 2, 3], 2, 1 }, { [2, 4], 2, 1 }, { [7], 7, 0 }, {[0,6], 0, 1}, {[6, 12, 5, 14], 3, 2}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int target, int expected)
    {
        var actual = MinRemovals(input, target);
        Assert.Equal(expected, actual);
    }
}
