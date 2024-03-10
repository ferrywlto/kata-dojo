namespace dojo.leetcode;

public class NaryTreeNode {
    public int val;
    public IList<NaryTreeNode> children = [];

    public NaryTreeNode() {}

    public NaryTreeNode(int _val) 
    {
        val = _val;
    }

    public NaryTreeNode(int _val, IList<NaryTreeNode> _children) 
    {
        val = _val;
        children = _children;
    }

    public static NaryTreeNode? FromLevelOrderIntArray(int?[] input)
    {
        if (input.Length == 0) return null;
        if (input.Length == 1 && input[0] == null) return null;
        
        var root = new NaryTreeNode(input[0] ?? int.MinValue);
        var queue = new Queue<NaryTreeNode>();
        queue.Enqueue(root);

        var i = 1;
        while(i < input.Length && queue.Count > 0)
        {
            var parent = queue.Dequeue();

            if(input[i] == null)
            {
                i++;
                var childList = new List<NaryTreeNode>();
                while(i < input.Length && input[i] != null)
                {
                    var childNode = new NaryTreeNode(input[i] ?? int.MinValue);
                    childList.Add(childNode);
                    queue.Enqueue(childNode);
                    i++;
                }
                parent.children = childList;
            }
        }

        return root;
    }
}
