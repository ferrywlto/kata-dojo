public class Q203_RemoveLinkeListElementsTests(ITestOutputHelper output) : ListNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q203_RemoveLinkeListElementsTestData))]
    public void OfficialTestCases(int[] input, int val, int[] expected)
    {
        var expectedList = ListNode.FromArray(expected);
        var head = ListNode.FromArray(input);
        var sut = new Q203_RemoveLinkeListElements();
        var actual = sut.RemoveElements(head, val);

        AssertListNodeEquals(expectedList, actual);
    }
}

public class Q203_RemoveLinkeListElementsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[]{1,2,6,3,4,5,6},
            6,
            new int[]{1,2,3,4,5}
        ],
        [
            new int[]{7,7,7,7},
            7,
            Array.Empty<int>()
        ],
        [
            Array.Empty<int>(),
            1,
            Array.Empty<int>()
        ],
        [
            new int[]{1,2},
            1,
            new int[]{2}
        ]
    ];
}

public class Q203_RemoveLinkeListElements
{
    // TC:O(n), SC:O(1)
    public ListNode? RemoveElements(ListNode? head, int val)
    {
        if (head == null) return null;

        var current = head;
        while(current != null)
        {
            while (current.next != null) 
            {
                if (current.next.val == val)
                {
                    current.next = current.next.next;
                    continue;
                }
                break;
            }
            current = current.next;
        }

        if (head.val == val)
        {
            if (head.next == null)
            {
                return null;
            }
            else 
            {
                head = head.next;
            }
        }
        return head;
    }
}