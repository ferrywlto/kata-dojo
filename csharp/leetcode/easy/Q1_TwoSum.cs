namespace dojo.leetcode;

public class TwoSumTestData : TestData
{
    protected override List<object[]> Data()
    {
        return
        [
            [new int[]{2, 7, 11, 15}, 9, new int[]{0, 1}],
            [new int[]{3, 2, 4}, 6, new int[]{1, 2}],
            [new int[]{3, 3, 5, 5}, 6, new int[]{0, 1}],
            [new int[]{3, 5, 3, -5}, 6, new int[]{0, 2}],
            [new int[]{-1,-2,-3,-4,-5}, -8, new int[]{2, 4}],
        ];
    }
}

public class TwoSumTests
{

    [Theory]
    [ClassData(typeof(TwoSumTestData))]
    public void TwoSumTest(int[] nums, int target, int[] expected)
    {
        var subject = new TwoSum();
        var actual = subject.Solve(nums, target);
        Assert.Equal(expected, actual);
    }
}

// Speed: 118ms (99.30%), Memory: 44.5MB (46.24%)
public class TwoSum
{
    // Best in speed, average in memory
    public int[] Solve(int[] input, int target)
    {
        if (input.Length < 2 || input.Length > 10000)
        {
            return [0];
        }
        int[] sorted = new int[input.Length];
        Array.Copy(input, sorted, input.Length);
        Array.Sort(sorted);

        for (var i = 0; i < sorted.Length - 1; i++)
        {
            var lookingFor = target - sorted[i];
            if (lookingFor < 0 && lookingFor < sorted[0]) continue;
            else if (lookingFor > sorted[^1]) continue;

            for (int j = i + 1; j < sorted.Length; j++)
            {
                if (sorted[j] == lookingFor)
                {
                    var result = new int[] { Array.IndexOf(input, sorted[i]), Array.LastIndexOf(input, sorted[j]) };
                    Array.Sort(result);
                    return result;
                }
            }
        }
        return [0];
    }
}
