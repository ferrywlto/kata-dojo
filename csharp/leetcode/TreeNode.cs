using System.Transactions;

public class TreeNode {
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int val=0, TreeNode? left=null, TreeNode? right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    // After doing Q101 Symmetric Tree it will become easier to implement the tree constrtuction algo.
    // From Q100 & Q101, actually the input is in level order.
    // That means from top-to-down, left-to-right
    // [root, left, right, left-of-left. right-of-right, left-of-right, right-of-right, ...]
    // [1,null,2,3] => 
    //    1 
    //   / \ 
    // null 2
    //     / \
    //    3  null
    //   / \
    // null null 

    public static TreeNode FromLevelOrderingIntArray(int?[] input) {
        if(input.Length == 0 || input[0] == null) {
            return new TreeNode();
        } 
        var root = new TreeNode(input[0] ?? int.MinValue);
        if (input.Length == 1) {
            return root;
        }

        // This line is critical of using queue
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        // Construct the tree from root
        int idx = 1;
        while (idx < input.Length) {
            var parent = queue.Dequeue();

            // Assign left child
            if (++idx < input.Length && input[idx] != null) {
                parent.left = new TreeNode(input[idx] ?? int.MinValue);
                queue.Enqueue(parent.left);
            }
            // idx++;

            // Assign right child
            if (++idx < input.Length && input[idx] != null) {
                parent.right = new TreeNode(input[idx] ?? int.MinValue);
                queue.Enqueue(parent.right);
            }
            // idx++;
        }
        return root;
    }
}
