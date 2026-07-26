public class Q894_AllPossibleFullBinaryTrees(ITestOutputHelper output) : TreeNodeTest(output)
{
    public IList<TreeNode> AllPossibleFBT(int n)
    {
        if (n % 2 == 0) return [];

        if (n == 1)
            return [new TreeNode(0)];

        var results = new List<TreeNode>();

        // full binary tree must be in the following pair of subtrees:
        // n=3 left:1, right:1
        // n=5 left:3, right:1 or left:1, right:3
        // n=7 left:1, right:5 or left:3, right:3 or left:5, right:1...

        // 1,3,5...n
        for (var leftSize = 1; leftSize < n; leftSize += 2)
        {
            // n..5,3,1
            var rightSize = n - 1 - leftSize;

            // Generate the pair of trees
            var leftTrees = AllPossibleFBT(leftSize);
            var rightTrees = AllPossibleFBT(rightSize);

            // left trees X right trees to form all possible subtree pairs
            foreach (var left in leftTrees)
                foreach (var right in rightTrees)
                    // Create a new root node foreach subtree pair
                    results.Add(new TreeNode(0, left, right));
        }

        return results;
    }

    public static TheoryData<int, IList<TreeNode>> TestData => new()
    {
        {
            7,
            [
                TreeNode.FromLevelOrderingIntArray([0, 0, 0, null, null, 0, 0, null, null, 0, 0])!,
                TreeNode.FromLevelOrderingIntArray([0, 0, 0, null, null, 0, 0, 0, 0])!,
                TreeNode.FromLevelOrderingIntArray([0, 0, 0, 0, 0, 0, 0])!,
                TreeNode.FromLevelOrderingIntArray([0, 0, 0, 0, 0, null, null, null, null, 0, 0])!,
                TreeNode.FromLevelOrderingIntArray([0, 0, 0, 0, 0, null, null, 0, 0])!,
            ]
        },
        {
            3, [TreeNode.FromLevelOrderingIntArray([0, 0, 0])!]
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, IList<TreeNode> expected)
    {
        var actual = AllPossibleFBT(n);
        for (var i = 0; i < actual.Count; i++)
        {
            AssertTreeNodeEqual(expected[i], actual[i]);
        }
    }
}
