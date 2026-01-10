

public class Q427_ConstructQuadTree
{
    public class Node
    {
        public bool? val;
        public bool? isLeaf;
        public Node? topLeft;
        public Node? topRight;
        public Node? bottomLeft;
        public Node? bottomRight;

        public Node()
        {
            val = false;
            isLeaf = false;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }
    public Node Construct(int[][] grid)
    {
        return new();
    }

    public static TheoryData<int[][], int[]?[]> TestData => new()
    {
        {[[0,1],[1,0]], [[0,1],[1,0],[1,1],[1,1],[1,0]]},
        {
            [
                [1,1,1,1,0,0,0,0],
                [1,1,1,1,0,0,0,0],
                [1,1,1,1,1,1,1,1],
                [1,1,1,1,1,1,1,1],
                [1,1,1,1,0,0,0,0],
                [1,1,1,1,0,0,0,0],
                [1,1,1,1,0,0,0,0],
                [1,1,1,1,0,0,0,0]
            ],
            [[0,1],[1,1],[0,1],[1,1],[1,0],null,null,null,null,[1,0],[1,0],[1,1],[1,1]]
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[][] expected)
    {
        var actual = Construct(input);
        // actual to array

        Assert.Equal(expected, []);
    }
}
