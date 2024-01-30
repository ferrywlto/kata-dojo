
namespace dojo.leetcode;

public class Q27_RemoveElement
{
    // whenever hit nums[i] == val
    // will try 2 versions
    // 1. mark the idx which nums[idx] == val in stack, then start from end of list swap element with nums[idx]
    // 2. swap nums[i] with int.Max if == val, then sort 
    public int RemoveElement(int[] nums, int val)
    {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0] == val ? 0 : 1;

        return RemoveElement_Sort(nums, val);
    }

    // TC:O(n), SC:O(n)
    public int RemoveElement_Swap(int[] nums, int val)
    {
        var stack = new Stack<int>();
        var end = 0;
        for(var i=0; i<nums.Length; i++) 
        {
            if (nums[i] == val)
            {
                stack.Push(i);
            }
            else 
            {
                end = i;
            }
        }
        if (stack.Count == nums.Length) return 0;
        if (stack.Count == 0) return nums.Length;

        var result = nums.Length - stack.Count;
        
        
        while(stack.Count > 0) 
        {
            if (nums[end] != val)
            {
                nums[stack.Pop()] = nums[end];
                nums[end] = val;
            }
            end--;
        }

        return result;
    }

    // TC:O(n log n), SC:O(1)
    public int RemoveElement_Sort(int[] nums, int val)
    {
        var hit = 0;
        for(var i=0; i<nums.Length; i++) 
        {
            if (nums[i] == val)
            {
                nums[i] = int.MaxValue;
                hit++;
            } 
        }
        Array.Sort(nums);
        return nums.Length - hit;
    }
}

public class Q27_RemoveElementTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{3,2,2,3}, 3, 2],
        [new int[]{0,1,2,2,3,0,4,2}, 2, 5],
    ];
}

public class Q27_RemoveElementTests: BaseTest
{
    [Theory]
    [ClassData(typeof(Q27_RemoveElementTestData))]
    public void OfficialTestCases(int[] input, int val, int expected)
    {
        var sut = new Q27_RemoveElement();
        
        var actual = sut.RemoveElement(input, val);
        Assert.Equal(expected, actual);
        AssertFirstKElementsNotEqualToVal(input, actual, val);
    }

    private void AssertFirstKElementsNotEqualToVal(int[] input, int k, int val)
    {
        for(var i=0; i<k; i++)
        {
            Assert.NotEqual(input[i], val);
        }
    }
}