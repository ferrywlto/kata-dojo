
using System.Reflection.Metadata.Ecma335;

namespace dojo.leetcode;

public class Q108_SortedArrayToBST
{
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return CreateNode(nums);
    }
    
    // since the input is sorted, it should be height balanced when constructed 
    // recursively create node from middle, then split the left elements from middle to create left subtree, to the same for the right
    public TreeNode CreateNode(int[] nums)
    {
        if (nums.Length == 3)
        {
            return new TreeNode(nums[1], new TreeNode(nums[0]), new TreeNode(nums[2]));
        }
        else if (nums.Length == 2)
        {
            return new TreeNode(nums[1], new TreeNode(nums[0]));
        }
        else if (nums.Length == 1)
        {
            return new TreeNode(nums[0]);
        }

        var middleIdx = nums.Length / 2;
        var middle = nums[middleIdx];
        var leftArray = nums[..middleIdx];
        var rightArray = nums[(middleIdx + 1)..];
        
        return new TreeNode(middle, CreateNode(leftArray), CreateNode(rightArray));
    }
}

public class Q108_SortedArrayToBSTTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{-10,-3,0,5,9}, new int?[]{0,-3,9,-10,null,5}],
        [new int[]{1,3}, new int?[]{3,1}],
    ];
}

public class Q108_SortedArrayToBSTTests(ITestOutputHelper output): TreeNodeTests(output)
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