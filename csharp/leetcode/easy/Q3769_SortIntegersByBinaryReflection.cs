namespace Leetcode.Easy;

// TC: O(n log n), n is the length of nums, n log n from Array.Sort()
// SC: O(n), space used to store the data structure for sorting, which is the same as the input nums
public class Q3769_SortIntegersByBinaryReflection
{
    public record Item(int Val, int Reflection);

    public int[] SortByReflection(int[] nums)
    {
        var items = ToReflectionItems(nums);

        Array.Sort(items, (a, b) =>
        {
            if (a.Reflection == b.Reflection) return a.Val - b.Val;
            return a.Reflection - b.Reflection;
        });
        return items.Select(i => i.Val).ToArray();
    }

    public Item[] ToReflectionItems(int[] nums)
    {
        var result = new Item[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            result[i] = new Item(nums[i], ToReflection(nums[i]));
        }

        return result;
    }

    public int ToReflection(int val)
    {
        var temp = val;
        var result = 0;
        while (temp > 0)
        {
            var digit = temp & 1;
            if (digit == 1) result += 1;
            result <<= 1;
            temp >>= 1;
        }

        return result;
    }

    public static TheoryData<int[], int[]> TestData = new()
    {
        { [8, 2], [2, 8] }, { [4, 5, 4], [4, 4, 5] }, { [3, 6, 5, 8], [8, 3, 6, 5] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int[] expected)
    {
        var actual = SortByReflection(nums);
        Assert.Equal(expected, actual);
    }
}
