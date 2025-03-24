class Q206_ReverseLinkedList
{
    // TC: O(n), SC:O(1)
    public ListNode? ReverseList(ListNode? head)
    {
        if (head == null) return null;
        if (head._next == null) return head;
        if (head._next._next == null)
        {
            var tail = head._next;
            tail._next = head;
            head._next = null;
            head = tail;
            return head;
        }

        var prev = head;
        var curr = prev._next;
        var next = curr._next;
        // important, end the loop
        prev._next = null;

        while (next != null)
        {
            curr!._next = prev;
            prev = curr;
            curr = next;
            next = next?._next;
        }
        curr!._next = prev;
        head = curr;
        return head;
    }

    public ListNode? ReveseListRecursive(ListNode? head)
    {
        if (head == null) return null;
        if (head._next == null) return head;

        var prev = head;
        var curr = prev._next;
        var next = curr._next;
        // important, end the loop
        prev._next = null;

        return Reverse(prev, curr, next);
    }

    public ListNode? Reverse(ListNode? prev, ListNode? curr, ListNode? next)
    {
        if (next == null)
        {
            curr!._next = prev;
            return curr;
        }

        curr!._next = prev;
        prev = curr;
        curr = next;
        next = next._next;

        return Reverse(prev, curr, next);
    }
}

class Q206_ReverseLinkedListTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[]{ 1, 2, 3, 4, 5 },
            new int[]{ 5, 4, 3, 2, 1 }
        ],
        [
            new int[] { 1, 2 },
            new int[] { 2, 1 }
        ],
        [
            Array.Empty<int>(),
            Array.Empty<int>(),
        ]
    ];
}

public class Q206_ReverseLinkedListTests(ITestOutputHelper output) : ListNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q206_ReverseLinkedListTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var expectedList = ListNode.FromArray(expected);
        var inputList = ListNode.FromArray(input);
        var sut = new Q206_ReverseLinkedList();
        var actualList = sut.ReveseListRecursive(inputList);

        AssertListNodeEquals(expectedList, actualList);
    }
}