namespace dojo.leetcode;

public class Q206_ReverseLinkedList
{
    // TC: O(n), SC:O(1)
    public ListNode? ReverseList(ListNode? head)
    {
        if (head == null) return null;
        if (head.next == null) return head;
        if (head.next.next == null)
        {
            var tail = head.next;
            tail.next = head;
            head.next = null;
            head = tail;
            return head;
        }

        var prev = head;
        var curr = prev.next;
        var next = curr.next;
        // important, end the loop
        prev.next = null;

        while (next != null)
        {
            curr!.next = prev;
            prev = curr;
            curr = next;
            next = next?.next;
        }
        curr!.next = prev;
        head = curr;
        return head;
    }

    public ListNode? ReveseListRecursive(ListNode? head)
    {
        if (head == null) return null;
        if (head.next == null) return head;

        var prev = head;
        var curr = prev.next;
        var next = curr.next;
        // important, end the loop
        prev.next = null;

        return Reverse(prev, curr, next);
    }

    public ListNode? Reverse(ListNode? prev, ListNode? curr, ListNode? next)
    {
        if (next == null)
        {
            curr!.next = prev;
            return curr;
        }

        curr!.next = prev;
        prev = curr;
        curr = next;
        next = next.next;

        return Reverse(prev, curr, next);
    }
}

public class Q206_ReverseLinkedListTestData : TestData
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