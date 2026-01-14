public class Q427_ConstructQuadTree(ITestOutputHelper output)
{
    public class Node
    {
        public bool val;
        public bool isLeaf;
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
        if (grid.Length == 1)
            return new Node(grid[0][0] == 1, true);

        var result = Spilt(grid);

        var isLeaf = result.oneCount == 0 || result.zeroCount == 0;
        var val = !isLeaf;

        if (isLeaf)
            return new Node(result.zeroCount == 0, isLeaf);

        var n = new Node
        {
            isLeaf = isLeaf,
            val = val,
            topLeft = Construct(result.topLeft),
            topRight = Construct(result.topRight),
            bottomLeft = Construct(result.bottomLeft),
            bottomRight = Construct(result.bottomRight)
        };

        return n;
    }

    public record X(int[][] topLeft, int[][] topRight, int[][] bottomLeft, int[][] bottomRight, int oneCount, int zeroCount);

    private X Spilt(int[][] input)
    {
        var size = input.Length;
        var halfSize = size / 2;
        var oneCount = 0;
        var zeroCount = 0;
        var topLeft = new int[halfSize][];
        var topRight = new int[halfSize][];
        var bottomLeft = new int[halfSize][];
        var bottomRight = new int[halfSize][];

        for (var row = 0; row < halfSize; row++)
        {
            topLeft[row] = new int[halfSize];
            for (var col = 0; col < halfSize; col++)
            {
                if (input[row][col] == 0)
                    zeroCount++;
                else
                    oneCount++;

                topLeft[row][col] = input[row][col];
            }
            topRight[row] = new int[halfSize];
            for (var col = halfSize; col < size; col++)
            {
                if (input[row][col] == 0)
                    zeroCount++;
                else
                    oneCount++;

                var colOffset = col - halfSize;

                topRight[row][colOffset] = input[row][col];
            }
        }

        for (var row = halfSize; row < size; row++)
        {
            var rowOffset = row - halfSize;
            bottomLeft[rowOffset] = new int[halfSize];
            for (var col = 0; col < halfSize; col++)
            {
                if (input[row][col] == 0)
                    zeroCount++;
                else
                    oneCount++;

                bottomLeft[rowOffset][col] = input[row][col];
            }

            bottomRight[rowOffset] = new int[halfSize];
            for (var col = halfSize; col < size; col++)
            {
                if (input[row][col] == 0)
                    zeroCount++;
                else
                    oneCount++;

                var colOffset = col - halfSize;
                bottomRight[rowOffset][colOffset] = input[row][col];
            }
        }

        return new X(topLeft, topRight, bottomLeft, bottomRight, oneCount, zeroCount);
    }

    public static TheoryData<int[][], Node?> TestData => new()
    {
        {
            [[0,1],[1,0]],
            FromLevelOrderingIntArray([[0,1],[1,0],[1,1],[1,1],[1,0]])
        },
        // {
        //     [
        //         [1,1,1,1,0,0,0,0],
        //         [1,1,1,1,0,0,0,0],
        //         [1,1,1,1,1,1,1,1],
        //         [1,1,1,1,1,1,1,1],
        //         [1,1,1,1,0,0,0,0],
        //         [1,1,1,1,0,0,0,0],
        //         [1,1,1,1,0,0,0,0],
        //         [1,1,1,1,0,0,0,0]
        //     ],
        //     FromLevelOrderingIntArray([[0,1],[1,1],[0,1],[1,1],[1,0],null,null,null,null,[1,0],[1,0],[1,1],[1,1]])
        // }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, Node? expected)
    {
        var actual = Construct(input);

        AssertQuadTreeEqual(expected, actual);
    }

    private void DebugNode(Node node)
    {
        var queue = new Queue<Node?>();
        queue.Enqueue(node);

        var list = new List<string>();

        while (queue.Count > 0)
        {
            var n = queue.Dequeue();
            if (n == null)
                list.Add("null");
            else
            {
                var valValue = n.val ? "1" : "0";
                var leafValue = n.isLeaf ? "1" : "0";
                list.Add($"[{leafValue}, {valValue}]");

                queue.Enqueue(n.topLeft);

                queue.Enqueue(n.topRight);

                queue.Enqueue(n.bottomLeft);

                queue.Enqueue(n.bottomRight);
            }
        }
        output.WriteLine(string.Join(',', list));
    }

    private static Node CreateNode(int[] input)
    {
        var isLeaf = input[0] == 1;
        var val = input[1] == 1;
        return new Node(val, isLeaf);
    }

    private static Node? FromLevelOrderingIntArray(int[]?[] input)
    {
        if (input[0] == null || input.Length == 0)
            return null;

        var root = CreateNode(input[0]!);

        if (input.Length == 1)
            return root;

        // Using queue is critical
        var queue = new Queue<Node>();
        queue.Enqueue(root);

        // Construct the tree from root
        var idx = 0;
        while (idx < input.Length && queue.Count > 0)
        {
            var parent = queue.Dequeue();

            if (++idx < input.Length && input[idx] != null)
            {
                parent.topLeft = CreateNode(input[idx]!);
                queue.Enqueue(parent.topLeft);
            }

            if (++idx < input.Length && input[idx] != null)
            {
                parent.topRight = CreateNode(input[idx]!);
                queue.Enqueue(parent.topRight);
            }

            if (++idx < input.Length && input[idx] != null)
            {
                parent.bottomLeft = CreateNode(input[idx]!);
                queue.Enqueue(parent.bottomLeft);
            }

            if (++idx < input.Length && input[idx] != null)
            {
                parent.bottomRight = CreateNode(input[idx]!);
                queue.Enqueue(parent.bottomRight);
            }
        }
        return root;
    }

    private void AssertQuadTreeEqual(Node? expected, Node? actual)
    {
        if (expected == null && actual == null) return;

        Assert.Equal(expected!.val, actual!.val);
        Assert.Equal(expected.isLeaf, actual.isLeaf);

        AssertQuadTreeEqual(expected.topLeft, actual.topLeft);
        AssertQuadTreeEqual(expected.topRight, actual.topRight);
        AssertQuadTreeEqual(expected.bottomLeft, actual.bottomLeft);
        AssertQuadTreeEqual(expected.bottomRight, actual.bottomRight);
    }
}
