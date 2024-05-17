class Q977_SquaresOfSortedArray
{
    // This is non-trival solution required for O(n) time instead of O(n * n log n) time with direct squaring each element and then sort again
    // TC: O(2n), n is length of nums
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
}

class Q977_SquaresOfSortedArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        // [new int[]{-4,-1,0,3,10}, new int[] {0,1,9,16,100}],
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
        var actual = sut.SortedSquares(input);
        Assert.Equal(expected, actual);
    }
}
