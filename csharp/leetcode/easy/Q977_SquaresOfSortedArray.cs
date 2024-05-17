class Q977_SquaresOfSortedArray
{
    // TC: O(n^2), n is length of nums, worst case each node need to goes to bottom for skewed tree.
    // SC: O(n*h), n is length of nums, n tree nodes + h tree height for stack 
    public int[] SortedSquares(int[] nums)
    {
        if (nums.Length == 1) return [nums[0] * nums[0]];

        var root = new TreeNode(nums[0] * nums[0]);

        for(var i=1; i<nums.Length; i++)
        {
            var node = root;
            while(node!=null)
            {
                var square = nums[i] * nums[i];
                if(square >= node.val)
                {
                    if (node.right == null)
                    {
                        node.right = new TreeNode(square);
                        break;
                    }
                    else node = node.right;
                }
                else 
                {
                    if (node.left == null)
                    {
                        node.left = new TreeNode(square);
                        break;
                    }
                    else node = node.left;
                }
            }
        }
        
        // Inorder traversal to get sorted result
        var stack = new Stack<TreeNode>();
        TreeNode? current = root;
        var result = new int[nums.Length];
        var idx = 0;
        while (current != null || stack.Count > 0)
        {
            // Down to deepest left first
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }
            current = stack.Pop();
            result[idx++] = current.val;
            current = current.right;
        }

        return result;
    }

    // The concept is, since the array already sorted, the head and tails must be the largest
    // THerefore can use a two-pointers approach to fill from largest to smallest to target array
    // TC: O(n)
    // SC: O(n)
    public int[] SortedSquares_TwoPointers(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];
        int left = 0, right = n - 1;
        for (int i = n - 1; i >= 0; i--)
        {
            if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
            {
                result[i] = nums[left] * nums[left];
                left++;
            }
            else
            {
                result[i] = nums[right] * nums[right];
                right--;
            }
        }
        return result;
    }
}

class Q977_SquaresOfSortedArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{-4,-1,0,3,10}, new int[] {0,1,9,16,100}],
        [new int[]{-7,-3,2,3,11}, new int[] {4,9,9,49,121}],
    ];
}

public class Q977_SquaresOfSortedArrayTests
{
    [Theory]
    [ClassData(typeof(Q977_SquaresOfSortedArrayTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q977_SquaresOfSortedArray();
        var actual = sut.SortedSquares_TwoPointers(input);
        Assert.Equal(expected, actual);
    }
}
