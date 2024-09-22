class Q108_SortedArrayToBST
{
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return CreateNode(nums, 0, nums.Length - 1);
    }

    // since the input is sorted, it should be height balanced when constructed 
    // recursively create node from middle, then split the left elements from middle to create left subtree, to the same for the right
    public TreeNode CreateNode(int[] nums, int startIdx, int endIdx)
    {
        if (endIdx == startIdx + 2)
        {
            return new TreeNode(nums[startIdx+1], new TreeNode(nums[startIdx]), new TreeNode(nums[endIdx]));
        }
        else if (endIdx == startIdx + 1)
        {
            return new TreeNode(nums[endIdx], new TreeNode(nums[startIdx]));
        }
        else if (startIdx == endIdx)
        {
            return new TreeNode(nums[startIdx]);
        }

        var middleIdx = (startIdx + endIdx) / 2;
        
        return new TreeNode(nums[middleIdx], CreateNode(nums, startIdx, middleIdx-1), CreateNode(nums, middleIdx+1, endIdx));
    }
}

class Q108_SortedArrayToBSTTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{-10,-3,0,5,9}, new int?[]{0,-3,9,-10,null,5}],
        [new int[]{1,3}, new int?[]{3,1}],
        [new int[]{3,5,8}, new int?[]{5,3,8}],
    ];
}

public class Q108_SortedArrayToBSTTests(ITestOutputHelper output) : TreeNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q108_SortedArrayToBSTTestData))]
    public void OfficialTestCases(int[] input, int?[] expected)
    {
        var sut = new Q108_SortedArrayToBST();
        var expectedTree = TreeNode.FromLevelOrderingIntArray(expected);
        var actualTree = sut.SortedArrayToBST(input);
        AssertTreeNodeEqual(expectedTree, actualTree);
    }
}