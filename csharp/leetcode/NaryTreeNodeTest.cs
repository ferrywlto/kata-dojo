public abstract class NaryTreeTest : BaseTest
{
    public NaryTreeTest() {}
    public NaryTreeTest(ITestOutputHelper output) : base(output) {}

    protected void DebugTree(NaryTreeNode root)
    {
        if (Output == null) 
            throw new Exception("Pass ITestOutputHelper in constructor first!");

        var queue = new Queue<NaryTreeNode>();
        queue.Enqueue(root);
        while(queue.Count > 0)
        {
            var node = queue.Dequeue();   
            string childStr = (node.children == null || node.children.Count == 0)
                ? "No child"
                : string.Join(',', node.children.Select(x => x.val));
            Output!.WriteLine($"node:{node.val}, children({node.children!.Count}): {childStr}");

            if (node.children.Count > 0)
            {
                for (var j = 0; j < node.children.Count; j++)
                {
                    queue.Enqueue(node.children[j]);
                }
            }
        }
    }
}